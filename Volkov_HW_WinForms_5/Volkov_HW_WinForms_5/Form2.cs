using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Volkov_HW_WinForms_5
{
    public partial class Form2 : Form
    {
        public Form ParentForm1 { get; set; }

        string price;

        Thread thread;

        Mutex mutex;

        public Form2()
        {
            InitializeComponent();
            comboBox1.Items.Add("А-95");
            comboBox1.Items.Add("A-95+");
            comboBox1.Items.Add("ДП");
            comboBox1.Items.Add("Газ");

            textBox2.Text = "0";           
            textBox1.Text = "0";
            textBox3.Text = "0";
            this.Text = "ОККО";
            thread = null;
            mutex = new Mutex(false, "OKKO");
        }

        public string GetText
        {
            get
            {
                return textBox3.Text;
            }
        }

        public string GetComboText
        {
            get
            {
                return comboBox1.Text;
            }
        }

        public string GetPriceFuel
        {
            get
            {
                return textBox1.Text;
            }
        }

        public string GetLitr
        {
            get
            {
                return textBox2.Text;
            }
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

        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
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
            thread = new Thread(Summ);
            thread.Start();
            thread.Join();
        }

        private void Summ()
        {
            double temp = 0;
            int temp2 = 0;
            mutex.WaitOne();
            if (textBox2.Enabled && double.TryParse(textBox1.Text, out temp) && int.TryParse(textBox2.Text, out temp2))
            {
                
                price = (temp * temp2).ToString();
                textBox3.Text = price.ToString();
                label6.Text = textBox3.Text;
                
            }
            mutex.ReleaseMutex();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            thread = new Thread(Summ2);
            thread.Start();
            thread.Join();
        }

        private void Summ2()
        {                
            double temp = 0;
            double temp2 = 0;
            mutex.WaitOne();
            if (textBox3.Enabled && double.TryParse(textBox1.Text, out temp) && double.TryParse(textBox3.Text, out temp2))
            {

                price = (temp2 / temp).ToString();
                textBox2.Text = price.ToString();
                label6.Text = textBox3.Text;
                
            }
            mutex.ReleaseMutex();
        }
    }
}
