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
    

    public partial class Form1 : Form
    {
        public static List<Tuple<string, double>> shop { get; set; }
        double summ;
        Form2 form;

        public Form1()
        {
            InitializeComponent();
            shop = new List<Tuple<string, double>>();
            label1.Text = "0";
            label2.Text = "0";
            summ = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(shop[comboBox1.SelectedIndex].Item1);
            label1.Text = "Price " + shop[comboBox1.SelectedIndex].Item2.ToString();
            summ += shop[comboBox1.SelectedIndex].Item2;
            label2.Text = summ.ToString() + " UAH";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form = new Form2();
            form.ParentForm1 = this;
            DialogResult rez = form.ShowDialog();
            if(rez == DialogResult.OK)
            {
                comboBox1.Items.Clear();
                foreach (var i in shop)
                {
                    comboBox1.Items.Add(i.Item1);
                }
            }
        }
    }
}
