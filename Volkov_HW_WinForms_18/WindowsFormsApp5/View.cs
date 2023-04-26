using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class View : Form
    {
        Controller controller;
        public View()
        {
            InitializeComponent();
            controller = new Controller();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            if (radioButton1.Checked)
            {
                textBox2.Text = controller.GetBookName(textBox1.Text).ToString();
            }
            if(radioButton2.Checked)
            {
                textBox2.Text = controller.GetBookAutor(textBox1.Text).ToString();
            }
        }

    }
}
