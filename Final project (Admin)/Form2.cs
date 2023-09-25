using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_project__Admin_
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 s1 = new Form3();
            s1.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 s2 = new Form3();
            s2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 s3 = new Form3();
            s3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 C1 = new Form5();
            C1.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 C2 = new Form5();
            C2.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form3 s4 = new Form3();
            s4.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form4 sh = new Form4();
            sh.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
