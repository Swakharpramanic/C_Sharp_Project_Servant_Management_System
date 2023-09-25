using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormDesign
{
    public partial class Form2 : Form
    {
        //string cs = ConfigurationManager.ConnectionStrings["Help Near You"].ConnectionString;
        //string id;
        //Thread th;

        private DataSet Data { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
       private void button1_Click(object sender, EventArgs e)
        {
                    }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (this.txtName.Text.Count() != 0 && this.txtMail.Text.Count() != 0  && this.txtPhone.Text.Count() != 0  && this.txtPassword.Text.Count() != 0  )
            {
                
               try{
                   sql = "Insert into servant_info values('" + this.txtName.Text + "','" + this.txtMail.Text + "','" + this.txtPhone.Text + "','" + this.txtPassword.Text + "');";

                            if (DataAccess.ExecuteUpdateQuerry(sql) == 1)
                                MessageBox.Show("Data Inserted Properly");
                            else MessageBox.Show("Data Insertion failed");
                        }

                catch (Exception exception)
                {
                    MessageBox.Show("An error occurred trying to perform the operation\n\n" + exception);
                }
          
                    
             }
            else 
            {
                MessageBox.Show("All fields must be filled");
            }
                

            }
        }

}

