using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form2 : Form
    {
        public Form ParentForm1 { get; set; }

        public Form2()
        {
            InitializeComponent();
            if(Form1.shop.Count > 0)
            {
                foreach(var i in Form1.shop)
                {
                    comboBox1.Items.Add(i.Item1);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.shop.Add(new Tuple<string, double>(textBox1.Text, Convert.ToDouble(textBox2.Text)));
            comboBox1.Items.Clear();
            foreach(var i in Form1.shop)
            {
                comboBox1.Items.Add(i.Item1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.shop[comboBox1.SelectedIndex] = new Tuple<string,double>(textBox3.Text, Convert.ToDouble(textBox4.Text));
            comboBox1.Items.Clear();
            foreach (var i in Form1.shop)
            {
                comboBox1.Items.Add(i.Item1);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = Form1.shop[comboBox1.SelectedIndex].Item1;
            textBox4.Text = Form1.shop[comboBox1.SelectedIndex].Item2.ToString();
        }
    }
}
