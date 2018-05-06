using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Book_Store_MS
{
    public partial class Admin : Form
    {
        public Admin(String s)
        {
            InitializeComponent();
            label2.Text = s;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            this.Close();
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Results obj = new Results("select eid,ename,join_date from employee1");
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Results obj = new Results("select * from books");
            obj.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Results obj = new Results("select cid,cname,phone,city from customer1");
            obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=SYSTEM;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            String insert = "insert into employee1 values(" + id + ",'" + textBox2.Text + "',to_date('" + textBox3.Text + "','dd-mm-yy'),'pass')";
            try
            {
                obj1.Open();
                OleDbCommand cm1 = new OleDbCommand(insert, obj1);
                cm1.ExecuteNonQuery();
                MessageBox.Show("Employee added successfully");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                panel1.Enabled = false;
                obj1.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button8.Visible = true;
            panel1.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=SYSTEM;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            String del = "delete from employee1 where eid=" + id;
            try
            {
                obj1.Open();
                OleDbCommand cm1 = new OleDbCommand(del, obj1);
                cm1.ExecuteNonQuery();
                MessageBox.Show("Employee deleted successfully");
                textBox1.Clear();
                panel1.Enabled = false;
                obj1.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
