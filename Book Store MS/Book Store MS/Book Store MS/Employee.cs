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
    public partial class Employee : Form
    {
        public Employee(String s)
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

        private void button2_Click(object sender, EventArgs e)
        {
            Results obj = new Results("select * from books");
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id=Convert.ToInt32(textBox4.Text);
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=SYSTEM;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            String insert="insert into books values("+id+",1234567890123,'"+textBox1.Text+"','"+textBox2.Text+"',to_date('"+textBox3.Text+"','dd-mm-yy'),"+Convert.ToInt32(numericUpDown1.Value)+","+Convert.ToInt32(numericUpDown2.Value)+",'"+comboBox1.Text+"')";
            try
            {
                obj1.Open();
                OleDbCommand cm1 = new OleDbCommand(insert, obj1);
                cm1.ExecuteNonQuery();
                MessageBox.Show("Book added successfully");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
                panel1.Enabled = false;
                obj1.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button6.Visible = true;
            label5.Enabled = true;
            textBox4.Enabled = true;
            panel1.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox4.Text);
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=SYSTEM;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            String del = "delete from books where bkid=" + id;
            try
            {
                obj1.Open();
                OleDbCommand cm1 = new OleDbCommand(del, obj1);
                cm1.ExecuteNonQuery();
                MessageBox.Show("Book deleted successfully");
                textBox4.Clear();
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
