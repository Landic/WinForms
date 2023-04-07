﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Volkov_HW_WinForms_5
{
    public partial class Form1 : Form
    {
        string price;
        double cafe;

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("А-95");
            comboBox1.Items.Add("A-95+");
            comboBox1.Items.Add("ДП");
            comboBox1.Items.Add("Газ");
            textBox4.Text = "68,00";
            textBox5.Text = "54,00";
            textBox6.Text = "33,00";
            textBox7.Text = "59,00";
            price = string.Empty;
            cafe = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            object obj = comboBox1.SelectedItem;
            switch (obj)
            {
                case "А-95":
                    textBox1.Text = "48,99";
                    break;
                case "A-95+":
                    textBox1.Text = "51,00";
                    break;
                case "ДП":
                    textBox1.Text = "48,99";
                    break;
                case "Газ":
                    textBox1.Text = "21,99";
                    break;
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                textBox2.Enabled = true;
                textBox3.Enabled = false;

                
            }
            if (radioButton2.Checked)
            {
                textBox2.Enabled = false;
                textBox3.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            double temp = 0;
            int temp2 = 0;
            if (textBox2.Enabled && double.TryParse(textBox1.Text, out temp) && int.TryParse(textBox2.Text, out temp2))
            {
                price = (temp * temp2).ToString();
                textBox3.Text = price.ToString();
                label6.Text = textBox3.Text;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            double temp = 0;
            double temp2 = 0;
            if (textBox3.Enabled && double.TryParse(textBox1.Text, out temp) && double.TryParse(textBox3.Text, out temp2))
            {
                price = (temp2 / temp).ToString();
                textBox2.Text = price.ToString();
                label6.Text = textBox3.Text;
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

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
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

        private void button1_Click(object sender, EventArgs e)
        {
            double temp = Convert.ToDouble(label6.Text) + Convert.ToDouble(label8.Text);
            label7.Text = temp.ToString();
        }
    }
}
