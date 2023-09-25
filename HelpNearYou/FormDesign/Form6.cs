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
    public partial class Form6 : Form
    {
        private Form1 form1;
        private DataSet Data { get; set; }
        public Form6(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (this.txtId.Text.Count() != 0 && this.txtReport.Text.Count() != 0) 
            {
                sql = "select * from servant where id=" + this.txtId.Text + ";";
                 try
                    {
                        this.Data = DataAccess.ExecuteQuery(sql);
                    }

                    catch (Exception exception)
                    {
                        MessageBox.Show("An error occurred trying to search for the ID\n\n" + exception);
                    }


                 try
                 {
                     if (this.Data.Tables[0].Rows.Count == 1)
                     {


                         sql = "Insert into report values('" + this.txtId.Text + "','" + this.txtReport.Text + "');";

                         if (DataAccess.ExecuteUpdateQuerry(sql) == 1)
                             MessageBox.Show("Data Inserted Properly");
                         else MessageBox.Show("Data Insertion failed");
                     }



                     else
                     {
                         MessageBox.Show("There is no servant with this ID");
                     }
                 }
                 catch (Exception exception) 
                 {
                     MessageBox.Show("An error occurred trying to perform the operation\n\n" + exception);
                 }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.form1.Show();
            this.Close();
        }
    }
}
