using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Random_Password_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String st1="";
            int length = Convert.ToInt32(numericUpDown1.Value);
            if (checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked)
                st1 = "abcdefghijklmnopqrstuvwxyz";
            else if (!checkBox1.Checked && checkBox2.Checked && !checkBox3.Checked)
                st1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            else if (!checkBox1.Checked && !checkBox2.Checked && checkBox3.Checked)
                st1 = "0123456789!@#$%^&*_-+=";
            else if (checkBox1.Checked && checkBox2.Checked && !checkBox3.Checked)
                st1 = "abcdefghijklmnopqrstuvwxyz" + "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            else if (checkBox1.Checked && !checkBox2.Checked && checkBox3.Checked)
                st1 = "abcdefghijklmnopqrstuvwxyz" + "0123456789!@#$%^&*_-+=";
            else if (!checkBox1.Checked && checkBox2.Checked && checkBox3.Checked)
                st1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + "0123456789!@#$%^&*_-+=";
            else if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked)
                st1 = "abcdefghijklmnopqrstuvwxyz" + "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + "0123456789!@#$%^&*_-+=";
            else if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked)
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Please select atleast one option!");
            }

            //Start generating the password
            if (st1 != "")
            {
                StringBuilder res = new StringBuilder();
                Random rnd = new Random();
                while (0 < length--)
                {
                    res.Append(st1[rnd.Next(st1.Length)]);
                }
                textBox1.Text = res.ToString();                  // Display password in textbox

                button2.Enabled = true;                         // Enable Copy to clipboard button
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
            System.Media.SystemSounds.Beep.Play();
            MessageBox.Show("Copied to Clipboard");
        }
    }
}
