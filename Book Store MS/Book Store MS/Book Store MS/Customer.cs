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
    public partial class Customer : Form
    {
        public Customer(String s)
        {
            InitializeComponent();
            label2.Text = s;
            if (s == "Guest")
                panel1.Enabled = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            this.Close();
            obj.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Results obj = new Results("select * from books");
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String query = "select * from books where title like '%" + textBox1.Text + "%'";
            Results obj = new Results(query);
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String query = "select * from books where author like '%" + textBox1.Text + "%'";
            Results obj = new Results(query);
            obj.Show();
        }

        private void button6_Click(object sender, EventArgs e)      //buy button
        {
            MessageBox.Show(" Your book with id "+textBox2.Text+" is ready for purchase!\n\n Kindly meet an employee.");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kindly wait till an employee arrives to check the book ");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Your book with id " + textBox2.Text + " is ready for borrowing!\n\n Kindly meet an employee to proceed with the borrow process.");
        }
    }
}
