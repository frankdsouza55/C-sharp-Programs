using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Book_Store_MS
{
    public partial class Results : Form
    {
        public Results(String q)
        {
            InitializeComponent(); 
            String connection = "Provider=OraOLEDB.Oracle;Data Source=localhost;User Id=system;Password=system;OLEDB.NET=True";
            OleDbConnection obj1 = new OleDbConnection(connection);
            obj1.Open();
            try
            {
                OleDbCommand cm2 = new OleDbCommand(q, obj1);
                cm2.ExecuteNonQuery();
                OleDbDataAdapter da = new OleDbDataAdapter(q, obj1);
                DataTable d = new DataTable();
                da.Fill(d);
                dataGridView1.DataSource = d;
                obj1.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void Results_Load(object sender, EventArgs e)
        {

        }
    }
}
