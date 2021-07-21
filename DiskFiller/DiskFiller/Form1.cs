using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiskFiller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
   

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" & textBox1.Text.Contains(":/"))
            {
                progressBar1.Value = 0;
                File.WriteAllBytes("E:/wuah.txt", Properties.Resources.New_Text_Document);
                foreach (int value in Enumerable.Range(1, trackBar1.Value))
                {
                    Console.Write(value + "  ");
                    File.WriteAllBytes(textBox1.Text + RandomString(20) + ".txt", Properties.Resources.New_Text_Document);
                    progressBar1.Maximum = trackBar1.Value;
                    progressBar1.Value += 1;
                }
                MessageBox.Show("Finished");
                progressBar1.Value = 0;
            }
            else
            {
                MessageBox.Show("Specify Drive Letter(Masukkan Huruf Drive)");
            }
            
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = ((trackBar1.Value).ToString()) + " MB";
        }

       
    }
}
