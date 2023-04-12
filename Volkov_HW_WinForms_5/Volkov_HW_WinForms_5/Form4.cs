using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Volkov_HW_WinForms_5
{
    public partial class Form4 : Form
    {
        public Form ParentForm1 { get; set; }

        Form5 form;

        public Form4()
        {
            InitializeComponent();
            label1.Text = "Введите пароль";
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "admin")
            {
                label1.Text = "Верный";
                label1.ForeColor = Color.Green;
                form = new Form5();
                form.ParentForm1 = this;
                DialogResult rez = form.ShowDialog();
                if(rez == DialogResult.OK)
                {

                }
            }
            else
            {
                label1.Text = "Неверный пароль";
                label1.ForeColor = Color.Red;
            }
        }
    }
}
