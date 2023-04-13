using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
{
    public partial class Form2 : Form
    {
        public Form ParentForm1 { get; set; }

        public string text
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value;  }
        }
        public Form2()
        {
            InitializeComponent();
            textBox1.Text = text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            text = textBox1.Text;
        }
    }
}
