using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Volkov_HW_WinForms_5
{
    public partial class Form5 : Form
    {
        public Form ParentForm1 { get; set; }

        public Form5()
        {
            InitializeComponent();
            comboBox1.Items.Add("А-95");
            comboBox1.Items.Add("A-95+");
            comboBox1.Items.Add("ДП");
            comboBox1.Items.Add("Газ");
            textBox1.Text = "0";
            textBox2.Text = Form1.HotDog.ToString();
            textBox3.Text = Form1.Coffee.ToString();
            textBox4.Text = Form1.CocaCola.ToString();
            textBox5.Text = Form1.Sendwich.ToString();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            object obj = comboBox1.SelectedItem;
            switch (obj)
            {
                case "А-95":
                    textBox1.Text = Form1.priceA95.ToString();
                    break;
                case "A-95+":
                    textBox1.Text = Form1.priceA952.ToString();
                    break;
                case "ДП":
                    textBox1.Text = Form1.diesel.ToString();
                    break;
                case "Газ":
                    textBox1.Text = Form1.Gaz.ToString();
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            object obj = comboBox1.SelectedItem;
            switch (obj)
            {
                case "А-95":
                    if (double.TryParse(textBox1.Text, out double temp))
                    {
                        Form1.priceA95 = temp;
                    }
                    break;
                case "A-95+":
                    if (double.TryParse(textBox1.Text, out double temp2))
                    {
                        Form1.priceA952 = temp2;
                    }
                    break;
                case "ДП":
                    if (double.TryParse(textBox1.Text, out double temp3))
                    {
                        Form1.diesel = temp3;
                    }
                    break;
                case "Газ":
                    if (double.TryParse(textBox1.Text, out double temp4))
                    {
                        Form1.Gaz = temp4;
                    }
                    break;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            double temp = 0;
            if (double.TryParse(textBox2.Text, out temp))
            {
                Form1.HotDog = temp;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            double temp = 0;
            if (double.TryParse(textBox3.Text, out temp))
            {
                Form1.Coffee = temp;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            double temp = 0;
            if (double.TryParse(textBox4.Text, out temp))
            {
                Form1.CocaCola = temp;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            double temp = 0;
            if (double.TryParse(textBox5.Text, out temp))
            {
                Form1.Sendwich = temp;
            }
        }
    }
}
