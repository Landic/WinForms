using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
{
    public partial class Form1 : Form
    {
        string text;
        Form2 form;

        public Form1()
        {
            InitializeComponent();
            text = string.Empty;    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using(StreamReader reader= new StreamReader(openFileDialog1.FileName)) 
                { 
                    text = reader.ReadToEnd();
                    textBox1.Text = text;
                    button2.Enabled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form = new Form2();
            form.ParentForm1 = this;
            form.text = textBox1.Text;
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = form.text;
                using(StreamWriter writer = new StreamWriter(openFileDialog1.FileName))
                {
                    writer.Write(form.text);
                }
            }
        }
    }
}
