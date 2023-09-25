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
    public partial class Form3 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form3()
        {
            InitializeComponent();
            BindGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "All Image File(*.*) | *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void sevantdetails_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into SV_DETAILS values (@id,@name,@email,@phonenumber,@workhour,@nidnumber,@address,@img)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox5.Text);
            cmd.Parameters.AddWithValue("@email", textBox2.Text);
            cmd.Parameters.AddWithValue("@phonenumber", textBox3.Text);
            cmd.Parameters.AddWithValue("@workhour", textBox7.Text);
            cmd.Parameters.AddWithValue("@nidnumber", textBox4.Text);
            cmd.Parameters.AddWithValue("@address", textBox6.Text);
            cmd.Parameters.AddWithValue("@img", SavePhoto());

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if(a>0)
            {
                MessageBox.Show("Data Inserted Successfully !");
                BindGridView();
                ResetControl();

            }
            else
            {
                MessageBox.Show("Data not inserted");
            }
        }

        private  byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();

        }

        void BindGridView()
        {
            //Connection between gridview
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from SV_DETAILS";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            
            //Data in gridview
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;


            //image column
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[7];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //Autosize Table column

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //image Row hight

            dataGridView1.RowTemplate.Height = 50;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResetControl();
        }

        void ResetControl()
        {
            textBox1.Clear();
            textBox5.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox7.Clear();
            textBox4.Clear();
            textBox6.Clear();
            pictureBox1.Image = Properties.Resources.Profile_pic;

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[7].Value);
        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update SV_DETAILS set id=@id,name=@name,email=@email,phone_number=@phonenumber,work_hour=@workhour,nid_number=@nidnumber,address=@address,picture=@img  where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox5.Text);
            cmd.Parameters.AddWithValue("@email", textBox2.Text);
            cmd.Parameters.AddWithValue("@phonenumber", textBox3.Text);
            cmd.Parameters.AddWithValue("@workhour", textBox7.Text);
            cmd.Parameters.AddWithValue("@nidnumber", textBox4.Text);
            cmd.Parameters.AddWithValue("@address", textBox6.Text);
            cmd.Parameters.AddWithValue("@img", SavePhoto());

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Updated Successfully !");
                BindGridView();
                ResetControl();

            }
            else
            {
                MessageBox.Show("Data not Updated");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "Delete from SV_DETAILS  where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
           
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Deleted Successfully !");
                BindGridView();
                ResetControl();

            }
            else
            {
                MessageBox.Show("Data not Deleted");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 d = new Form2();
            d.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form2 d = new Form2();
            d.Show();
        }
    }
}
