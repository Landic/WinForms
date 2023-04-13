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

namespace Volkov_HW_WinForms_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult rez = folderBrowserDialog1.ShowDialog();
            if(rez == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string folder = textBox2.Text;
            string format = "*" + textBox1.Text;
            string[] files = Directory.GetFiles(folder, format);
            listBox1.Items.Add("Количество файлов с этим форматом: " + files.Length);
            foreach(string i in files )
            {
                listBox1.Items.Add(i);
            }
        }
    }
}
