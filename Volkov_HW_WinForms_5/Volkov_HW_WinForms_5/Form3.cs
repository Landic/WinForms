using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Volkov_HW_WinForms_5
{
    public partial class Form3 : Form
    {
        double cafe;
        public Form ParentForm1 { get; set; }
        public Form3()
        {
            InitializeComponent();
            textBox4.Text = Form1.HotDog.ToString();
            textBox5.Text = Form1.Coffee.ToString();
            textBox6.Text = Form1.CocaCola.ToString();
            textBox7.Text = Form1.Sendwich.ToString();
            textBox8.Text = "0";
            textBox9.Text = "0";
            textBox10.Text = "0";
            textBox11.Text = "0";
            cafe = 0;
            this.Text = "ОККО";
        }

        public double GetCafe
        {
            get
            {
                return cafe;
            }
        }

        public string HotDog
        {
            get
            {
                return textBox8.Text;
            }
        }

        public string Cafe
        {
            get
            {
                return textBox9.Text;
            }
        }

        public string CocaCola
        {
            get
            {
                return textBox10.Text;
            }
        }

        public string Sendwich
        {
            get
            {
                return textBox11.Text;
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox8.Enabled = true;
            }
            if (checkBox2.Checked)
            {
                textBox9.Enabled = true;
            }
            if (checkBox3.Checked)
            {
                textBox10.Enabled = true;
            }
            if (checkBox4.Checked)
            {
                textBox11.Enabled = true;
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            double temp = Convert.ToDouble(textBox7.Text);
            int temp2 = 0;
            if (int.TryParse(textBox11.Text, out temp2))
            {
                cafe += temp * temp2;
                label8.Text = cafe.ToString();
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            double temp = Convert.ToDouble(textBox6.Text);
            int temp2 = 0;
            if (int.TryParse(textBox10.Text, out temp2))
            {
                cafe += temp * temp2;
                label8.Text = cafe.ToString();
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            double temp = Convert.ToDouble(textBox5.Text);
            int temp2 = 0;
            if (int.TryParse(textBox9.Text, out temp2))
            {
                cafe += temp * temp2;
                label8.Text = cafe.ToString();
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            double temp = Convert.ToDouble(textBox4.Text);
            int temp2 = 0;
            if (int.TryParse(textBox8.Text, out temp2))
            {
                cafe += temp * temp2;
                label8.Text = cafe.ToString();
            }
        }
    }
}
