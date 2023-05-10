using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Volkov_WinForms_ExamProject.Properties;

namespace Volkov_WinForms_ExamProject
{
    public partial class Form1 : Form
    {
        List<Panel> panels; // лист для хранение задач
        List<Button> typetask;
        List<CheckBox> endtask;
        List<Panel> listendtaskpanel;
        List<CheckBox> backtask;
        int index;
        public Form1()
        {
            InitializeComponent();
            index = 0;
            endtask= new List<CheckBox>();
            panels = new List<Panel>();
            typetask = new List<Button>() { button1, button2, button3 };
            listendtaskpanel= new List<Panel>();
            backtask = new List<CheckBox>();
            DateTime date = DateTime.Now;
            string day = date.ToString("dddd, dd MMMM", new CultureInfo("ru-RU"));
            label2.Text = day;
            TaskPanel.Size = new Size(this.Width, this.Height);
            textBox1.Size = new Size(panel2.Width - 18, panel2.Height - 18);
            Circle_Panel();
            Circle_TextBox();
            GraphicsPath path = new GraphicsPath();
            int borderRadius = 5;
            path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
            path.AddArc(textBox2.Width - borderRadius - 1, 0, borderRadius, borderRadius, 270, 90);
            path.AddArc(textBox2.Width - borderRadius - 1, textBox2.Height - borderRadius - 1, borderRadius, borderRadius, 0, 90); // Нижний правый угол
            path.AddArc(0, textBox2.Height - borderRadius - 1, borderRadius, borderRadius, 90, 90);
            path.CloseAllFigures();
            textBox2.Region = new Region(path);
        }

        private void Circle_Panel() // метод закругление панели
        {
            foreach (var i in panels)
            {
                GraphicsPath path = new GraphicsPath();
                int borderRadius = 10;
                path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
                path.AddArc(i.Width - borderRadius - 1, 0, borderRadius, borderRadius, 270, 90);
                path.AddArc(i.Width - borderRadius - 1, i.Height - borderRadius - 1, borderRadius, borderRadius, 0, 90); // Нижний правый угол
                path.AddArc(0, i.Height - borderRadius - 1, borderRadius, borderRadius, 90, 90);
                path.CloseAllFigures();
                i.Region = new Region(path);
            }
        }

        private void Circle_TextBox() // метод закругление текстбокса
        {
            GraphicsPath path = new GraphicsPath();
            int borderRadius = 5;
            path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
            path.AddArc(textBox1.Width - borderRadius - 1, 0, borderRadius, borderRadius, 270, 90);
            path.AddArc(textBox1.Width - borderRadius - 1, textBox1.Height - borderRadius - 1, borderRadius, borderRadius, 0, 90); // Нижний правый угол
            path.AddArc(0, textBox1.Height - borderRadius - 1, borderRadius, borderRadius, 90, 90);
            path.CloseAllFigures();
            textBox1.Region = new Region(path);
        }

        private void button1_Click(object sender, EventArgs e) // категория мой день хранит задачи на текущий день
        {
            Button clickbut = sender as Button;
            for (int i = 0; i < typetask.Count; i++)
            {
                typetask[i].BackColor = Color.FromArgb(64, 64, 64);
            }
            label1.Text = "Мой день";
            label1.ForeColor = Color.FromArgb(188, 122, 188);
            label2.Visible = true;
            pictureBox1.Image = Resources.MyDay_Ico1;
            button1.BackColor = Color.FromArgb(84, 84, 84);
        }

        private void button2_Click(object sender, EventArgs e) // категории важно хранит задачи которые важны
        {            
            Button clickbut = sender as Button;
            for (int i = 0; i < typetask.Count; i++)
            {
                typetask[i].BackColor = Color.FromArgb(64, 64, 64);
            }
            label1.Text = "Важно";
            label1.ForeColor = Color.FromArgb(222,166,177);
            label2.Visible = false;
            pictureBox1.Image = Resources.ImportantTask_Ico;
            button2.BackColor = Color.FromArgb(84, 84, 84);
        }

        private void button3_Click(object sender, EventArgs e) // категория задачи просто хранит какие то задачи
        {
            Button clickbut = sender as Button;            
            for(int i = 0; i < typetask.Count; i++)
            {
                typetask[i].BackColor = Color.FromArgb(64, 64, 64);
            }
            label1.Text = "Задачи";
            label1.ForeColor = Color.FromArgb(120,140,222);
            label2.Visible = false;
            pictureBox1.Image = Resources.Task_Ico;
            button3.BackColor = Color.FromArgb(84, 84, 84);

        }

        private void panel_Click(object sender, EventArgs e) // когда кликается на задачу то открывается меню настройки задачи
        {
            panel3.Visible = true;
            TaskPanel.Size = new Size(this.Width, this.Height);
            Panel clickedPanel = sender as Panel;
            index = panels.IndexOf(clickedPanel); // получаем индекс кликнутой панели задач
            for(int i = 0; i < panels.Count; i++)
            {

                panels[i].Size = new Size(TaskPanel.Width - 40, TaskPanel.Height - 245); // меняется размер

                Circle_Panel(); // закругление
            }                
            textBox1.Size = new Size(panel2.Width - 18, panel2.Height - 18); // меняется размер текстбокса
            Circle_TextBox(); // закругление текстбокса
        }


        private void panel_MouseEnter(object sender, EventArgs e) // метод когда курсор мыши дотрагивается до задачи меняется цвет
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                panel.BackColor = Color.FromArgb(66, 66, 66);
            }
        }

        private void panel_MouseLeave(object sender, EventArgs e) // когда мышка выходит с задачи цвет меняется обратно
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                panel.BackColor = Color.FromArgb(44,44, 44);
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            TaskPanel.Size = new Size(this.Width, this.Height); // меняется размер панели которая хранит задачи
            for (int i = 0; i < panels.Count; i++) // меняется размер всех задач
            {
                panels[i].Size = new Size(TaskPanel.Width - 40, TaskPanel.Height - 245);

                Circle_Panel(); // метод для закругление панели задач
            }                
            textBox1.Size = new Size(panel2.Width - 18, panel2.Height - 18); // меняется размер текстбокса
            Circle_TextBox(); // закругляет текстбокс
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(textBox1.Text != "")
                {
                    if(panels.Count == 0)
                    {
                        panels.Add(new Panel());
                        panels[0].Size = new System.Drawing.Size(TaskPanel.Width - 40, TaskPanel.Height - 245);
                        panels[0].Location = new System.Drawing.Point(17, 0);
                        panels[0].BackColor = Color.FromArgb(44, 44, 44);
                        panels[0].MouseEnter += new EventHandler(panel_MouseEnter);
                        panels[0].MouseLeave += new EventHandler(panel_MouseLeave);
                        panels[0].Click += new EventHandler(panel_Click);
                        endtask.Add(new CheckBox());
                        endtask[0].FlatStyle = FlatStyle.Popup;
                        endtask[0].Size = new Size(10, 10);
                        endtask[0].CheckedChanged += new EventHandler(EndTask_CheckedChanged);
                        panels[0].Controls.Add(endtask[0]);
                        endtask[0].Location = new Point(10 ,(panels[0].Height / 2) - 5);
                        TaskPanel.Controls.Add(panels[0]);
                        Circle_Panel();
                        textBox1.Clear();
                    }
                    else
                    {
                        panels.Add(new Panel());
                        panels[panels.Count - 1].Size = new System.Drawing.Size(TaskPanel.Width - 40, TaskPanel.Height - 245);
                        panels[panels.Count - 1].Location = new System.Drawing.Point(17, panels[panels.Count - 2].Location.Y + 60);
                        panels[panels.Count - 1].BackColor = Color.FromArgb(44, 44, 44);
                        panels[panels.Count - 1].MouseEnter += new EventHandler(panel_MouseEnter);
                        panels[panels.Count - 1].MouseLeave += new EventHandler(panel_MouseLeave);
                        panels[panels.Count - 1].Click += new EventHandler(panel_Click);
                        endtask.Add(new CheckBox());
                        endtask[endtask.Count - 1].FlatStyle = FlatStyle.Popup;
                        endtask[endtask.Count - 1].Size = new Size(10, 10);
                        endtask[endtask.Count - 1].CheckedChanged += new EventHandler(EndTask_CheckedChanged);
                        panels[panels.Count - 1].Controls.Add(endtask[endtask.Count - 1]);
                        endtask[endtask.Count - 1].Location = new Point(10, (panels[endtask.Count - 1].Height / 2) - 5);
                        TaskPanel.Controls.Add(panels[panels.Count - 1]);
                        Circle_Panel();
                        textBox1.Clear();
                    }
                }
            }
        }

        private void BackPanelsTask()
        {
            TaskPanel.Controls.Clear();
            foreach(var i in panels)
            {
                TaskPanel.Controls.Add(i);
            }
            for(int i = 0; i < panels.Count; i++)
            {
                int index = i;
                if(i == 0)
                {
                    panels[i].Location = new Point(17, 0);
                }
                else
                {
                    panels[i].Location = new Point(17, panels[index--].Location.Y + 60);
                }
                
            }
        }

        private void EndTask_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox clicked = sender as CheckBox;
            int indexend = endtask.IndexOf(clicked);
            if (endtask[indexend].Checked == true)
            {
                if(listendtaskpanel.Count == 0)
                {
                    EndTaskPanel.Visible = true;
                    listendtaskpanel.Add(panels[indexend]);
                    if (TaskPanel.Controls.Count > 0)
                    {
                        for (int i = 0; i < panels.Count; i++)
                        {
                            if (listendtaskpanel.Contains(panels[i]) == false && listendtaskpanel[0] != panels[panels.Count - 1])
                            {
                                if (panels[i].Location.Y != 0)
                                {
                                    panels[i].Location = new Point(17, panels[i].Location.Y - 60);
                                }
                            }
                        }
                    }
                    EndTaskPanel.Controls.Add(listendtaskpanel[0]);
                    listendtaskpanel[0].Location = new Point(17, 26);
                }
                else
                {
                    listendtaskpanel.Add(panels[indexend]);
                    if (TaskPanel.Controls.Count > 0)
                    {
                        for (int i = 0; i < panels.Count; i++)
                        {
                            if (listendtaskpanel.Contains(panels[i]) == false && listendtaskpanel[0] != panels[panels.Count - 1])
                            {
                                if (panels[i].Location.Y != 0)
                                {
                                    panels[i].Location = new Point(17, panels[i].Location.Y - 60);
                                }
                            }
                        }
                    }
                    EndTaskPanel.Controls.Add(listendtaskpanel[listendtaskpanel.Count - 1]);
                    listendtaskpanel[listendtaskpanel.Count - 1].Location = new Point(17, listendtaskpanel[listendtaskpanel.Count - 2].Location.Y + 60);
                }
            }
            if (endtask[indexend].Checked == false)
            {
                if (listendtaskpanel.Count == 1)
                {
                    EndTaskPanel.Visible = false;
                    BackPanelsTask();
                    listendtaskpanel.Clear();
                    
                }
                else // ДОДЕЛАТЬ
                {

                }
            }
        }
    }
}
