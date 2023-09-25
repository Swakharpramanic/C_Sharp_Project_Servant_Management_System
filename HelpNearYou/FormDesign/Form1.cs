using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormDesign
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            try
            {
                DataAccess.Connect();
            }
            catch (Exception exception)
            {
                MessageBox.Show("An error occured during connecing to the database\n\n" + exception);
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            /*  this.Close();
              th = new Thread(opennewfrom);
              this.SetApartmentState(Apartmenttstate.STA);
              th.Start();*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(this);
            f6.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataAccess.Disconnect();
        }
        /*  private void opennewform()
              Application.Run(new form7());

       
      }*/
    }
}
