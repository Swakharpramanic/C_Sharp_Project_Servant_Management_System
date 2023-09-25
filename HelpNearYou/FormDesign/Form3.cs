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
    public partial class Form3 : Form
    {        

        public Form3()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String sql = "";
            if (this.txtName.Text.Count() != 0 && this.txtPhone.Text.Count() != 0 && this.txtLocation.Text.Count() != 0 && this.txtInfo.Text.Count() != 0 )
            {
                try
                {

                    sql = "insert into servant values('" + this.txtName.Text + "','" + this.txtLocation.Text + "','" + this.txtPhone.Text + "','" + this.txtInfo.Text + "');";

                    if (DataAccess.ExecuteUpdateQuerry(sql) == 1)
                        MessageBox.Show("Data Inserted Properly");
                    else MessageBox.Show("Data Insertion failed");
                }
                catch (Exception exception)
                {
                    MessageBox.Show("An error occurred trying to perform the operation\n\n" + exception);
                }
            }
            else {
                MessageBox.Show("All fields have to be filled");
            }
        }
    }
}
