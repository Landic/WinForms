using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Volkov_HW_WinForms_2
{
    public partial class Form1 : Form
    {
        Rectangle rectangle;

        public Form1()
        {
            InitializeComponent();
            rectangle= new Rectangle(10,10,this.ClientSize.Width / 2,this.ClientSize.Height);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = $"X -> {e.X} Y -> {e.Y}";
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {

                if (rectangle.Contains(e.Location))
                {
                    MessageBox.Show("Курсор находится в прямоугольнике", "Прямоугольник");
                }
                else if (rectangle.IntersectsWith(new Rectangle(e.Location, new Size(10, this.ClientSize.Height))))
                {
                    MessageBox.Show("Курсор находится на границе", "Прямоугольник");
                }
                else
                {
                    MessageBox.Show("Курсор находится не в прямоугольнике", "Прямоугольник");
                }
                if(Control.ModifierKeys == Keys.Control)
                {
                    Application.Exit();
                }
            }
            if(e.Button == MouseButtons.Right)
            {
                Text = $"Ширина -> {this.ClientSize.Width} Высота -> {this.ClientSize.Height}";
            }
        }
    }
}
