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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public String encode(String pass)
        {
            String conv="";
            int dec,rem;
            for (int i = 0; i < pass.Length; i++)       //convert input password
            {
                dec = pass[i];
                while (dec > 0)
                {
                    rem = dec % 16;
                    switch (rem)
                    {
                        case 1: conv+="1"; break;
                        case 2: conv+="2"; break;
                        case 3: conv+="3"; break;
                        case 4: conv+="4"; break;
                        case 5: conv+="5"; break;
                        case 6: conv+="6"; break;
                        case 7: conv+="7"; break;
                        case 8: conv+="8"; break;
                        case 9: conv+="9"; break;
                        case 0: conv+="0"; break;
                        case 10: conv+="A"; break;
                        case 11: conv+="B"; break;
                        case 12: conv+="C"; break;
                        case 13: conv+="D"; break;
                        case 14: conv+="E"; break;
                        case 15: conv+="F"; break;
                    }
                    dec = dec / 16;
                }
            }
            return conv;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=SYSTEM;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);

            int id = Convert.ToInt32(numericUpDown1.Value);
            String pass = textBox2.Text , conv="" ;
            conv=encode(pass);      //converted password
            if (id == 0)        //admin user
            {
                String query = "select password from employee1 where eid=0" ,q2="select ename from employee1 where eid=0",name="", res="";
                try
                {
                    obj1.Open();
                    OleDbCommand cm2 = new OleDbCommand(query, obj1);
                    OleDbDataReader reader = cm2.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        res = reader.GetString(0);
                        //MessageBox.Show(res);
                    }
                    obj1.Close();
                    obj1.Open();
                    OleDbCommand cm3 = new OleDbCommand(q2, obj1);
                    OleDbDataReader read = cm3.ExecuteReader();
                    if (read.HasRows)
                    {
                        read.Read();
                        name = read.GetString(0);
                    }
                    obj1.Close();
                    if (res == conv)
                    {
                        Admin obj = new Admin(name);
                        this.Hide();
                        obj.Show();
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (id >= 5000)      //Customer login
            {
                String query = "select password from customer1 where cid="+id, q2 = "select cname from customer1 where cid="+id, name = "", res = "";
                try
                {
                    obj1.Open();
                    OleDbCommand cm2 = new OleDbCommand(query, obj1);
                    OleDbDataReader reader = cm2.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        res = reader.GetString(0);
                    }
                    obj1.Close();
                    obj1.Open();
                    OleDbCommand cm3 = new OleDbCommand(q2, obj1);
                    OleDbDataReader read = cm3.ExecuteReader();
                    if (read.HasRows)
                    {
                        read.Read();
                        name = read.GetString(0);
                    }
                    obj1.Close();
                    if (res == encode(textBox2.Text))
                    {
                        Customer obj = new Customer(name);
                        this.Hide();
                        obj.Show();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (id < 5000 && textBox2.Text=="pass")     //Employee login
            {
                String query = "select password from employee1 where eid=" + id, q2 = "select ename from employee1 where eid=" + id, name = "", res = "";
                try
                {
                    obj1.Open();
                    OleDbCommand cm2 = new OleDbCommand(query, obj1);
                    OleDbDataReader reader = cm2.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        res = reader.GetString(0);
                    }
                    obj1.Close();
                    obj1.Open();
                    OleDbCommand cm3 = new OleDbCommand(q2, obj1);
                    OleDbDataReader read = cm3.ExecuteReader();
                    if (read.HasRows)
                    {
                        read.Read();
                        name = read.GetString(0);
                    }
                    obj1.Close();
                    //if (res == conv)
                    {
                        Employee obj = new Employee(name);
                        this.Hide();
                        obj.Show();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password!");
                numericUpDown1.Value = 0;
                textBox2.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer obj = new Customer("Guest");
            this.Hide();
            obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Register obj = new Register();
            this.Hide();
            obj.Show();
        }
    }
}
