using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Volkov_HW_WinForms_3
{
    public partial class Form1 : Form
    {
        int time;
        int score;

        public Form1()
        {
            InitializeComponent();
            time = 1;
            label1.Text = "0";
            score = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 11;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            groupBox8.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = time.ToString();
            time++;
            if (time == 6)
            {
                groupBox8.Enabled = false;
                timer1.Stop();
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                score++;
            }
            if (radioButton5.Checked) 
            { 
                score++; 
            }
            if (radioButton7.Checked)
            {
                score++;
            }
            if (radioButton11.Checked)
            {
                score++;
            }
            if (radioButton15.Checked)
            {
                score++;
            }
            if(checkBox1.Checked)
            {
                score++;
            }
            if (checkBox3.Checked)
            {
                score++;
            }
            if (radioButton20.Checked)
            {
                score++;
            }
            if (radioButton23.Checked)
            {
                score++;
            }
            if (radioButton26.Checked)
            {
                score++;
            }
            if (radioButton30.Checked)
            {
                score++;
            }
            progressBar1.Value = score;
            button2.Enabled = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
            groupBox6.Enabled = false;
            groupBox7.Enabled = false;
            groupBox8.Enabled = false;
            groupBox9.Enabled = false;
            groupBox10.Enabled = false;
            using(StreamWriter stream = new StreamWriter(".../Result.txt"))
            {
                int score2temp = (score * 100) / 11;
                stream.Write("Person -> " + score2temp + "%");
            }
        }
    }
}
