using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Volkov_HW_WinForms_7
{
    public partial class Form1 : Form
    {
        int score, i;
        GroupBox groubox4, groupBox5, groupBox6, groupBox7,groupBox8,groupBox9;
        RadioButton radio10, radio11, radio12, radio13, radio14, radio15, radio16, radio17, radio18;
        RadioButton radio19, radio20, radio21, radio22, radio23, radio24, radio25, radio26, radio27;
        TabPage page;

        public Form1()
        {
            InitializeComponent();
            score = 0;
            i = 1;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 9;

            radio10= new RadioButton();
            radio10.Text = "8";
            radio11= new RadioButton();
            radio11.Text = "6";
            radio12 = new RadioButton();
            radio12.Text = "10";
            radio13 = new RadioButton();
            radio13.Text = "05.10.2021";
            radio14 = new RadioButton();
            radio14.Text = "05.09.2021";
            radio15 = new RadioButton();
            radio15.Text = "10.11.2020";
            radio16 = new RadioButton();
            radio16.Text = "14.03.2010";
            radio17 = new RadioButton();
            radio17.Text = "14.03.2002";
            radio18 = new RadioButton();
            radio18.Text = "14.03.2005";


            radio19 = new RadioButton();
            radio19.Text = "Харьков";
            radio20 = new RadioButton();
            radio20.Text = "Киев";
            radio21 = new RadioButton();
            radio21.Text = "Одесса";
            radio22 = new RadioButton();
            radio22.Text = "01.09.1960";
            radio23 = new RadioButton();
            radio23.Text = "29.07.1958";
            radio24 = new RadioButton();
            radio24.Text = "02.12.1991";
            radio25 = new RadioButton();
            radio25.Text = "Человек";
            radio26 = new RadioButton();
            radio26.Text = "Птица";
            radio27 = new RadioButton();
            radio27.Text = "Насекомое";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                score++;
                radioButton1.BackColor = Color.Green;
                groupBox1.Enabled= false;
            }
            if (radioButton5.Checked)
            {
                score++;
                radioButton5.BackColor = Color.Green;
                groupBox2.Enabled = false;
            }
            if (radioButton9.Checked)
            {
                score++;
                radioButton9.BackColor = Color.Green;
                groupBox3.Enabled = false;
            }
            if (radio10.Checked)
            {
                score++;
                radio10.BackColor = Color.Green;
                groubox4.Enabled = false;
            }
            if (radio15.Checked)
            {
                score++;
                radio15.BackColor = Color.Green;
                groupBox5.Enabled = false;
            }
            if (radio17.Checked)
            {
                score ++;
                radio17.BackColor = Color.Green;
                groupBox6.Enabled = false;
            }
            if (radio20.Checked)
            {
                score++;
                radio20.BackColor = Color.Green;
                groupBox7.Enabled = false;
            }
            if (radio23.Checked)
            {
                score++;
                radio23.BackColor = Color.Green;
                groupBox8.Enabled = false;
            }
            if (radio25.Checked)
            {
                score++;
                radio25.BackColor = Color.Green;
                groupBox9.Enabled = false;
            }
            progressBar1.Value = score;
            MessageBox.Show("Вы набрали " + score + "/9", "Викторина");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i++;
            if (i == 2)
            {
                TabPage page = new TabPage("Викторина " + i);
                tabControl1.Controls.Add(page);
                groubox4 = new GroupBox();
                groubox4.Size = new System.Drawing.Size(205, 100);
                groubox4.Location = new System.Drawing.Point(7, 7);
                groubox4.Text = "Вопрос 4: 2 + 2 * 2";
                radio10.Size = new System.Drawing.Size(31, 17);
                radio10.Location = new System.Drawing.Point(7, 20);
                radio11.Size = new System.Drawing.Size(31,17);
                radio11.Location = new System.Drawing.Point(6, 43);
                radio12.Size = new System.Drawing.Size(31, 17);
                radio12.Location = new System.Drawing.Point(6, 66);
                groubox4.Controls.Add(radio10);
                groubox4.Controls.Add(radio11);
                groubox4.Controls.Add(radio12);
                page.Controls.Add(groubox4);
                groupBox5= new GroupBox();
                groupBox5.Size = new System.Drawing.Size(205, 100);
                groupBox5.Location = new System.Drawing.Point(7, 113);
                groupBox5.Text = "Вопрос 5: Когда вышла Windows 11";
                radio13.Size = new System.Drawing.Size(109, 17);
                radio13.Location = new System.Drawing.Point(6, 19);
                radio14.Size = new System.Drawing.Size(109, 17);
                radio14.Location = new System.Drawing.Point(6, 42);
                radio15.Size = new System.Drawing.Size(109, 17);
                radio15.Location = new System.Drawing.Point(6, 65);
                groupBox5.Controls.Add(radio13);
                groupBox5.Controls.Add(radio14);
                groupBox5.Controls.Add(radio15);
                page.Controls.Add(groupBox5);
                groupBox6 = new GroupBox();
                groupBox6.Size = new System.Drawing.Size(205, 100);
                groupBox6.Location = new System.Drawing.Point(7, 219);
                groupBox6.Text = "Вопрос 6: Когда основали SpaceX";
                radio16.Size = new System.Drawing.Size(109, 17);
                radio16.Location = new System.Drawing.Point(6, 19);
                radio17.Size = new System.Drawing.Size(109, 17);
                radio17.Location = new System.Drawing.Point(6, 42);
                radio18.Size = new System.Drawing.Size(109, 17);
                radio18.Location = new System.Drawing.Point(6, 65);
                groupBox6.Controls.Add(radio16);
                groupBox6.Controls.Add(radio17);
                groupBox6.Controls.Add(radio18);
                page.Controls.Add(groupBox6);
            }
            else if(i == 3)
            {
                TabPage page = new TabPage("Викторина " + i);
                tabControl1.Controls.Add(page);
                groupBox7 = new GroupBox();
                groupBox7.Size = new System.Drawing.Size(205, 100);
                groupBox7.Location = new System.Drawing.Point(7, 7);
                groupBox7.Text = "Вопрос 7: Столица Украины";
                radio19.Size = new System.Drawing.Size(109, 17);
                radio19.Location = new System.Drawing.Point(7, 20);
                radio20.Size = new System.Drawing.Size(109, 17);
                radio20.Location = new System.Drawing.Point(6, 43);
                radio21.Size = new System.Drawing.Size(109, 17);
                radio21.Location = new System.Drawing.Point(6, 66);
                groupBox7.Controls.Add(radio19);
                groupBox7.Controls.Add(radio20);
                groupBox7.Controls.Add(radio21);
                page.Controls.Add(groupBox7);
                groupBox8 = new GroupBox();
                groupBox8.Size = new System.Drawing.Size(205, 100);
                groupBox8.Location = new System.Drawing.Point(7, 113);
                groupBox8.Text = "Вопрос 8: Когда основали NASA";
                radio22.Size = new System.Drawing.Size(109, 17);
                radio22.Location = new System.Drawing.Point(6, 19);
                radio23.Size = new System.Drawing.Size(109, 17);
                radio23.Location = new System.Drawing.Point(6, 42);
                radio24.Size = new System.Drawing.Size(109, 17);
                radio24.Location = new System.Drawing.Point(6, 65);
                groupBox8.Controls.Add(radio22);
                groupBox8.Controls.Add(radio23);
                groupBox8.Controls.Add(radio24);
                page.Controls.Add(groupBox8);
                groupBox9 = new GroupBox();
                groupBox9.Size = new System.Drawing.Size(205, 100);
                groupBox9.Location = new System.Drawing.Point(7, 219);
                groupBox9.Text = "Вопрос 9: Кто ты";
                radio25.Size = new System.Drawing.Size(109, 17);
                radio25.Location = new System.Drawing.Point(6, 19);
                radio26.Size = new System.Drawing.Size(109, 17);
                radio26.Location = new System.Drawing.Point(6, 42);
                radio27.Size = new System.Drawing.Size(109, 17);
                radio27.Location = new System.Drawing.Point(6, 65);
                groupBox9.Controls.Add(radio25);
                groupBox9.Controls.Add(radio26);
                groupBox9.Controls.Add(radio27);
                page.Controls.Add(groupBox9);
            }
        }
    }
}
