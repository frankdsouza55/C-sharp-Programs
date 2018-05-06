using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Book_Store_MS
{
    public partial class Register : Form
    {
        public int id;
        public Register()
        {
            InitializeComponent();
        }
        public String encode(String pass)
        {
            String conv = "";
            int dec, rem;
            for (int i = 0; i < pass.Length; i++)       //convert input password
            {
                dec = pass[i];
                while (dec > 0)
                {
                    rem = dec % 16;
                    switch (rem)
                    {
                        case 1: conv += "1"; break;
                        case 2: conv += "2"; break;
                        case 3: conv += "3"; break;
                        case 4: conv += "4"; break;
                        case 5: conv += "5"; break;
                        case 6: conv += "6"; break;
                        case 7: conv += "7"; break;
                        case 8: conv += "8"; break;
                        case 9: conv += "9"; break;
                        case 0: conv += "0"; break;
                        case 10: conv += "A"; break;
                        case 11: conv += "B"; break;
                        case 12: conv += "C"; break;
                        case 13: conv += "D"; break;
                        case 14: conv += "E"; break;
                        case 15: conv += "F"; break;
                    }
                    dec = dec / 16;
                }
            }
            return conv;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            this.Close();
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String fetch = "select max(cid) as cid from customer1";
            int ph = Convert.ToInt32(textBox2.Text);
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=SYSTEM;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            try
            {
                obj1.Open();
                OleDbCommand cm2 = new OleDbCommand(fetch, obj1);
                OleDbDataReader reader = cm2.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    id = Convert.ToInt32(reader["CID"]);
                    //MessageBox.Show(id.ToString());
                }
                obj1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            id = id + 1; ;
            String insert = "insert into customer1 values(" + id + ",'" + textBox1.Text + "'," + ph + ",'" + textBox3.Text + "','" + encode(textBox4.Text) + "')";
            try
            {
                obj1.Open();
                OleDbCommand cm1 = new OleDbCommand(insert, obj1);
                cm1.ExecuteNonQuery();
                MessageBox.Show("Registration Successful!\n\nYour UserId is "+id);
                obj1.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            Login obj = new Login();
            this.Close();
            obj.Show();
        }
    }
}
