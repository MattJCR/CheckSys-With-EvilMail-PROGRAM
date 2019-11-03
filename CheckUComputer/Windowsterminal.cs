using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckUComputer
{
    class WindowsTerminal
    {
        //Ejecuta comandos de MSDOS
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void DisableProcessWindowsGhosting();
        public static String Execute(string command)
        {
            DisableProcessWindowsGhosting();
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd ", "/c " + command);
            System.Threading.Thread.Sleep(100);
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            string result = proc.StandardOutput.ReadToEnd();
            int errorlevel = proc.ExitCode;
            return result;
        }
    }
}
