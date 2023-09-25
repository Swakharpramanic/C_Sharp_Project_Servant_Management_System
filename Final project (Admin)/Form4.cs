using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Final_project__Admin_
{
    public partial class Form4 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM SV_DETAILS";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            string query2 = "SELECT * FROM CL_DETAILS";
            SqlDataAdapter sd = new SqlDataAdapter(query2, con);


            //Data in gridview
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;


            DataTable data2 = new DataTable();
            sd.Fill(data2);
            dataGridView2.DataSource = data2;

            //image column
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[7];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            DataGridViewImageColumn dg = new DataGridViewImageColumn();
            dg = (DataGridViewImageColumn)dataGridView2.Columns[6];
            dg.ImageLayout = DataGridViewImageCellLayout.Stretch;



            //Autosize Table column

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //image Row hight

            dataGridView1.RowTemplate.Height = 50;
            dataGridView2.RowTemplate.Height = 50;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 d = new Form2();
            d.ShowDialog();
        }
    }
}
