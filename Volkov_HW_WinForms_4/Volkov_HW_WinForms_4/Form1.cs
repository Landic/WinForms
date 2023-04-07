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

namespace Volkov_HW_WinForms_4
{
    public partial class Form1 : Form
    {
        string text;

        public Form1()
        {
            InitializeComponent();
            text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(StreamReader stream = new StreamReader("Text.txt"))
            {
                text += stream.ReadToEnd();
            }
            textBox1.Text = text;
            progressBar1.Value = text.Length;
            label3.Text = text.Length.ToString();
        }
    }
}
