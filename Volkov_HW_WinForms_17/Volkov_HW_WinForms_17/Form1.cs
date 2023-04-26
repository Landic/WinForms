using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Volkov_HW_WinForms_17
{
    public partial class Form1 : Form
    {
        List<string> list;
        Semaphore semaphore;

        public Form1()
        {
            InitializeComponent();
            list = new List<string>() { "Car", "Plane", "Cat", "Example" };
            semaphore = new Semaphore(1, 1);
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.D1)
            {
                button7.BackColor = Color.DeepSkyBlue;
            }
            if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.C || e.KeyCode == Keys.D2)
            {
                button8.BackColor = Color.DeepSkyBlue;
            }
            if(e.KeyCode >= Keys.D && e.KeyCode <= Keys.F || e.KeyCode == Keys.D3)
            {
                button9.BackColor = Color.DeepSkyBlue;
            }
            if(e.KeyCode >= Keys.G && e.KeyCode <= Keys.I || e.KeyCode == Keys.D4)
            {
                button10.BackColor = Color.DeepSkyBlue;
            }
            if(e.KeyCode >= Keys.J && e.KeyCode <= Keys.L || e.KeyCode == Keys.D5)
            {
                button11.BackColor = Color.DeepSkyBlue;
            }
            if(e.KeyCode >= Keys.M && e.KeyCode <= Keys.O || e.KeyCode == Keys.D6)
            {
                button12.BackColor = Color.DeepSkyBlue;
            }
            if(e.KeyCode >= Keys.P && e.KeyCode <= Keys.S || e.KeyCode == Keys.D7)
            {
                button13.BackColor = Color.DeepSkyBlue;
            }
            if(e.KeyCode >= Keys.T && e.KeyCode <= Keys.V || e.KeyCode == Keys.D8)
            {
                button14.BackColor = Color.DeepSkyBlue;
            }
            if(e.KeyCode >= Keys.W && e.KeyCode <= Keys.Z || e.KeyCode == Keys.D9)
            {
                button15.BackColor = Color.DeepSkyBlue;
            }
            if(e.KeyCode == Keys.Multiply)
            {
                button16.BackColor = Color.DeepSkyBlue;
            }            
            if(e.KeyCode == Keys.Add || e.KeyCode == Keys.D0)
            {
                button17.BackColor = Color.DeepSkyBlue;
            }
            if(e.KeyCode == Keys.OemQuestion)
            {
                button18.BackColor = Color.DeepSkyBlue;
            }

        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.D1) 
            {
                button7.BackColor = Color.White;
            }
            if(e.KeyCode >= Keys.A && e.KeyCode <= Keys.C || e.KeyCode == Keys.D2)
            {
                button8.BackColor = Color.White;
            }
            if (e.KeyCode >= Keys.D && e.KeyCode <= Keys.F || e.KeyCode == Keys.D3)
            {
                button9.BackColor = Color.White;
            }
            if (e.KeyCode >= Keys.G && e.KeyCode <= Keys.I || e.KeyCode == Keys.D4)
            {
                button10.BackColor = Color.White;
            }
            if (e.KeyCode >= Keys.J && e.KeyCode <= Keys.L || e.KeyCode == Keys.D5)
            {
                button11.BackColor = Color.White;
            }
            if (e.KeyCode >= Keys.M && e.KeyCode <= Keys.O || e.KeyCode == Keys.D6)
            {
                button12.BackColor = Color.White;
            }
            if (e.KeyCode >= Keys.P && e.KeyCode <= Keys.S || e.KeyCode == Keys.D7)
            {
                button13.BackColor = Color.White;
            }
            if (e.KeyCode >= Keys.T && e.KeyCode <= Keys.V || e.KeyCode == Keys.D8)
            {
                button14.BackColor = Color.White;
            }
            if (e.KeyCode >= Keys.W && e.KeyCode <= Keys.Z || e.KeyCode == Keys.D9)
            {
                button15.BackColor = Color.White;
            }
            if (e.KeyCode == Keys.Multiply)
            {
                button16.BackColor = Color.White;
            }
            if (e.KeyCode == Keys.Add || e.KeyCode == Keys.D0)
            {
                button17.BackColor = Color.White;
            }
            if (e.KeyCode == Keys.OemQuestion)
            {
                button18.BackColor = Color.White;
            }
            ReplaceWord();
        }

        private void ReplaceWord()
        {
            try
            {
                semaphore.WaitOne();
                string[] text = richTextBox1.Text.Split(' ');
                if (list.Contains(text[text.Length - 1]))
                {
                    int start = richTextBox1.SelectionStart - text.Length;
                    richTextBox1.Text = richTextBox1.Text.Remove(start, text.Length);
                    for(int i = 0; i < text.Length; i++)
                    {
                        richTextBox1.Text = richTextBox1.Text.Insert(start, text[i]);
                    }
                    richTextBox1.SelectionStart = start + text.Length;
                }
            }
            finally
            {
                semaphore.Release();
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string[] text = richTextBox1.Text.Split(' ');
            list.Add(text[text.Length - 1]);
        }
    }
}
