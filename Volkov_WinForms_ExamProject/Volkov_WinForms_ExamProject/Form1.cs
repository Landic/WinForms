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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Volkov_WinForms_ExamProject.Properties;

namespace Volkov_WinForms_ExamProject
{
    public partial class Form1 : Form
    {
        List<Button> CategoryTask;

        List<Panel> MyDayTask; // лист для хранение задач
        List<CheckBox> MyDayTaskCheckEnd;
        List<Panel> MyDayEndTaskPanels;
        List<CheckBox> MyDayTaskCheckBack;
        List<Label> MyDayTaskLabelEnd;
        List<Label> MyDayTaskLabel;

        List<Panel> MyTask;
        List<CheckBox> MyTaskCheckEnd;
        List<Panel> MyTaskEndPanels;
        List<CheckBox> MyTaskCheckBack;
        List<Label> MyTaskLabelEnd;
        List<Label> MyTaskLabel;

        int index;
        int indexcattegory;

        public Form1()
        {
            InitializeComponent();
            index = 0;
            indexcattegory = 0;

            MyDayTaskCheckEnd = new List<CheckBox>();
            MyDayTask = new List<Panel>();
            CategoryTask = new List<Button>() { button1, button2, button3 };
            MyDayEndTaskPanels = new List<Panel>();
            MyDayTaskCheckBack = new List<CheckBox>();
            MyDayTaskLabel = new List<Label>();
            MyDayTaskLabelEnd = new List<Label>();

            MyTask= new List<Panel>();
            MyTaskCheckEnd = new List<CheckBox>();
            MyTaskLabel = new List<Label>();
            MyTaskLabelEnd = new List<Label>();
            MyTaskCheckBack = new List<CheckBox>();
            MyTaskEndPanels= new List<Panel>();

            button1.BackColor = Color.FromArgb(84, 84, 84);
            DateTime date = DateTime.Now;
            string day = date.ToString("dddd, dd MMMM", new CultureInfo("ru-RU"));
            label2.Text = day;

            TaskPanel.Size = new Size(this.Width, this.Height);
            textBox1.Size = new Size(AddPanel.Width - 18, AddPanel.Height - 18);

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
            foreach (var i in MyDayTask)
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
            if(MyDayEndTaskPanels.Count > 0)
            {
                foreach (var i in MyDayEndTaskPanels)
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
        }

        private void Circle_Panel_MyTask() // метод закругление панели
        {
            foreach (var i in MyTask)
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
            if (MyTaskEndPanels.Count > 0)
            {
                foreach (var i in MyTaskEndPanels)
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



        private void UpdateMyDayTask()
        {
            Thread updateThread = new Thread(() =>
            {
                Invoke(new Action(() =>
                {
                    if(MyDayTask.Count> 0)
                    {
                        TaskPanel.Controls.Clear();
                        foreach (Panel i in MyDayTask)
                        {
                            TaskPanel.Controls.Add(i);
                            i.Size = new Size(TaskPanel.Width - 40, 55);
                            i.Margin = new Padding(17, 0, 0, 5);
                        }
                    }
                    else
                    {
                        TaskPanel.Controls.Clear();
                    }
                }));
            });
            updateThread.Start();
        }


        private void UpdateMyDayTaskEnd()
        {
            Thread updateThread = new Thread(() =>
            {
                Invoke(new Action(() =>
                {
                    if(MyDayEndTaskPanels.Count> 0)
                    {
                        EndTaskPanel.Visible = true;
                        EndTaskPanel.Controls.Clear();
                        EndTaskPanel.Controls.Add(label4);
                        foreach (var i in MyDayEndTaskPanels)
                        {
                            EndTaskPanel.Controls.Add(i);
                        }
                        int temp = 0;
                        for (int i = 0; i < MyDayEndTaskPanels.Count; i++)
                        {
                            temp = i;
                            if (i == 0)
                            {
                                MyDayEndTaskPanels[i].Location = new Point(17, 26);
                            }
                            else
                            {
                                MyDayEndTaskPanels[i].Location = new Point(17, MyDayEndTaskPanels[temp - 1].Location.Y + 60);
                            }
                        }
                    }
                    else
                    {
                        EndTaskPanel.Visible = false;
                    }
                }));
            });
            updateThread.Start();
        }

        private void UpdateMyTask()
        {
            Thread updateThread = new Thread(() =>
            {
                Invoke(new Action(() =>
                {
                    if (MyTask.Count > 0)
                    {
                        TaskPanel.Controls.Clear();
                        foreach (Panel i in MyTask)
                        {
                            TaskPanel.Controls.Add(i);
                            i.Size = new Size(TaskPanel.Width - 40, 55);
                            i.Margin = new Padding(17, 0, 0, 5);
                        }
                    }
                    else
                    {
                        TaskPanel.Controls.Clear();
                    }
                }));
            });
            updateThread.Start();
        }

        private void UpdateMyTaskEnd()
        {
            Thread updateThread = new Thread(() =>
            {
                Invoke(new Action(() =>
                {
                    if (MyTaskEndPanels.Count > 0)
                    {
                        EndTaskPanel.Controls.Clear();
                        EndTaskPanel.Controls.Add(label4);
                        foreach (var i in MyTaskEndPanels)
                        {
                            EndTaskPanel.Controls.Add(i);
                        }
                        int temp = 0;
                        for (int i = 0; i < MyTaskEndPanels.Count; i++)
                        {
                            temp = i;
                            if (i == 0)
                            {
                                MyTaskEndPanels[i].Location = new Point(17, 26);
                            }
                            else
                            {
                                MyTaskEndPanels[i].Location = new Point(17, MyTaskEndPanels[temp - 1].Location.Y + 60);
                            }
                        }
                    }
                    else
                    {
                        EndTaskPanel.Visible = false;
                    }
                }));
            });
            updateThread.Start();
        }

        private void button1_Click(object sender, EventArgs e) // категория мой день хранит задачи на текущий день
        {
            Button clickbut = sender as Button;
            indexcattegory = CategoryTask.IndexOf(clickbut);
            for (int i = 0; i < CategoryTask.Count; i++)
            {
                CategoryTask[i].BackColor = Color.FromArgb(64, 64, 64);
            }
            label1.Text = "Мой день";
            label1.ForeColor = Color.FromArgb(188, 122, 188);
            label2.Visible = true;
            pictureBox1.Image = Resources.MyDay_Ico1;
            button1.BackColor = Color.FromArgb(84, 84, 84);
            UpdateMyDayTask();
            UpdateMyDayTaskEnd();
        }

        private void button2_Click(object sender, EventArgs e) // категории важно хранит задачи которые важны
        {            
            Button clickbut = sender as Button;
            for (int i = 0; i < CategoryTask.Count; i++)
            {
                CategoryTask[i].BackColor = Color.FromArgb(64, 64, 64);
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
            indexcattegory = CategoryTask.IndexOf(clickbut);
            for (int i = 0; i < CategoryTask.Count; i++)
            {
                CategoryTask[i].BackColor = Color.FromArgb(64, 64, 64);
            }
            label1.Text = "Задачи";
            label1.ForeColor = Color.FromArgb(120,140,222);
            label2.Visible = false;
            pictureBox1.Image = Resources.Task_Ico;
            button3.BackColor = Color.FromArgb(84, 84, 84);
            UpdateMyTask();
            UpdateMyTaskEnd();
        }

        private void panel_Click(object sender, EventArgs e) // когда кликается на задачу то открывается меню настройки задачи
        {
            SettingsPanel.Visible = true;
            //TaskPanel.Size = new Size(this.Width, this.Height);
            Panel clickedPanel = sender as Panel;
            if (MyDayTask.Contains(clickedPanel))
            {
                index = MyDayTask.IndexOf(clickedPanel);
                ChangeBoxTask.Text = MyDayTaskLabel[index].Text;
            }
            else if (MyDayEndTaskPanels.Contains(clickedPanel))
            {
                index = MyDayEndTaskPanels.IndexOf(clickedPanel);
            }
            // получаем индекс кликнутой панели задач
            foreach (Panel i in MyDayTask)
            {
                i.Size = new Size(TaskPanel.Width - 40, 55);
                i.Margin = new Padding(17, 0, 0, 5);
            }
            textBox1.Size = new Size(AddPanel.Width - 18, AddPanel.Height - 18); // меняется размер текстбокса
            if (MyDayEndTaskPanels.Count > 0)
            {
                for (int i = 0; i < MyDayEndTaskPanels.Count; i++)
                {
                    MyDayEndTaskPanels[i].Size = new Size(EndTaskPanel.Width - 40, EndTaskPanel.Height- 92);
                }
            }
            Circle_Panel();
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
            SettingsPanel.Visible = false;
            ChangeBoxTask.Text = string.Empty;
            foreach (Panel i in MyDayTask)
            {
                i.Size = new Size(TaskPanel.Width - 40, 55);
                i.Margin = new Padding(17, 0, 0, 5);
            }
            if (MyDayEndTaskPanels.Count > 0)
            {
                foreach (Panel i in MyDayEndTaskPanels)
                {
                    i.Size = new Size(EndTaskPanel.Width - 40, 55);
                    i.Margin = new Padding(17, 0, 0, 5);
                }
            }
            textBox1.Size = new Size(AddPanel.Width - 18, AddPanel.Height - 18); // меняется размер текстбокса
            Circle_Panel();// метод для закругление панели задач
            Circle_TextBox(); // закругляет текстбокс
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(textBox1.Text != "")
                {
                    if(indexcattegory == 0)
                    {
                        MyDayTask.Add(new Panel());

                        MyDayTask[MyDayTask.Count - 1].BackColor = Color.FromArgb(44, 44, 44);
                        MyDayTask[MyDayTask.Count - 1].Size = new Size(TaskPanel.Width - 40, 55);
                        MyDayTask[MyDayTask.Count - 1].Margin = new Padding(17, 0, 0, 5);
                        MyDayTask[MyDayTask.Count - 1].MouseEnter += new EventHandler(panel_MouseEnter);
                        MyDayTask[MyDayTask.Count - 1].MouseLeave += new EventHandler(panel_MouseLeave);
                        MyDayTask[MyDayTask.Count - 1].Click += new EventHandler(panel_Click);

                        MyDayTaskCheckEnd.Add(new CheckBox());

                        MyDayTaskCheckEnd[MyDayTaskCheckEnd.Count - 1].FlatStyle = FlatStyle.Popup;
                        MyDayTaskCheckEnd[MyDayTaskCheckEnd.Count - 1].Size = new Size(10, 10);
                        MyDayTaskCheckEnd[MyDayTaskCheckEnd.Count - 1].CheckedChanged += new EventHandler(EndTask_CheckedChanged);
                        MyDayTask[MyDayTask.Count - 1].Controls.Add(MyDayTaskCheckEnd[MyDayTaskCheckEnd.Count - 1]);
                        MyDayTaskCheckEnd[MyDayTaskCheckEnd.Count - 1].Location = new Point(10, (MyDayTask[MyDayTask.Count - 1].Height / 2) - 5);

                        MyDayTaskLabel.Add(new Label());

                        MyDayTaskLabel[MyDayTaskLabel.Count - 1].ForeColor = Color.Gainsboro;
                        MyDayTaskLabel[MyDayTaskLabel.Count - 1].Font = new Font("Times New Roman", 10, FontStyle.Regular);
                        MyDayTaskLabel[MyDayTaskLabel.Count - 1].Location = new Point(40, (MyDayTask[MyDayTask.Count - 1].Height / 2) - 10);
                        MyDayTaskLabel[MyDayTaskLabel.Count - 1].Text = textBox1.Text;
                        MyDayTask[MyDayTask.Count - 1].Controls.Add(MyDayTaskLabel[MyDayTaskLabel.Count - 1]);
                        TaskPanel.Controls.Add(MyDayTask[MyDayTask.Count - 1]);

                        Circle_Panel();
                        textBox1.Clear();
                    }
                    else if (indexcattegory == 2)
                    {
                        MyTask.Add(new Panel());

                        MyTask[MyTask.Count - 1].BackColor = Color.FromArgb(44, 44, 44);
                        MyTask[MyTask.Count - 1].Size = new Size(TaskPanel.Width - 40, 55);
                        MyTask[MyTask.Count - 1].Margin = new Padding(17, 0, 0, 5);
                        MyTask[MyTask.Count - 1].MouseEnter += new EventHandler(panel_MouseEnter);
                        MyTask[MyTask.Count - 1].MouseLeave += new EventHandler(panel_MouseLeave);
                        MyTask[MyTask.Count - 1].Click += new EventHandler(panel_Click);

                        MyTaskCheckEnd.Add(new CheckBox());

                        MyTaskCheckEnd[MyTaskCheckEnd.Count - 1].FlatStyle = FlatStyle.Popup;
                        MyTaskCheckEnd[MyTaskCheckEnd.Count - 1].Size = new Size(10, 10);
                        MyTaskCheckEnd[MyTaskCheckEnd.Count - 1].CheckedChanged += new EventHandler(EndTask_CheckedChanged);
                        MyTask[MyTask.Count - 1].Controls.Add(MyTaskCheckEnd[MyTaskCheckEnd.Count - 1]);
                        MyTaskCheckEnd[MyTaskCheckEnd.Count - 1].Location = new Point(10, (MyTask[MyTask.Count - 1].Height / 2) - 5);

                        MyTaskLabel.Add(new Label());

                        MyTaskLabel[MyTaskLabel.Count - 1].ForeColor = Color.Gainsboro;
                        MyTaskLabel[MyTaskLabel.Count - 1].Font = new Font("Times New Roman", 10, FontStyle.Regular);
                        MyTaskLabel[MyTaskLabel.Count - 1].Location = new Point(40, (MyTask[MyTask.Count - 1].Height / 2) - 10);
                        MyTaskLabel[MyTaskLabel.Count - 1].Text = textBox1.Text;
                        MyTask[MyTask.Count - 1].Controls.Add(MyTaskLabel[MyTaskLabel.Count - 1]);

                        TaskPanel.Controls.Add(MyTask[MyTask.Count - 1]);

                        Circle_Panel_MyTask();
                        textBox1.Clear();
                    }
                }
            }
        }

        private void EndTask_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox clicked = sender as CheckBox;
            if(indexcattegory == 0)
            {
                if (MyDayTaskCheckEnd.Contains(clicked))
                {
                    int indexend = MyDayTaskCheckEnd.IndexOf(clicked);
                    if (MyDayTaskCheckEnd[indexend].Checked == true)
                    {
                        if (EndTaskPanel.Visible == false)
                        {
                            EndTaskPanel.Visible = true;
                        }

                        MyDayEndTaskPanels.Add(MyDayTask[indexend]);
                        MyDayTaskCheckBack.Add(MyDayTaskCheckEnd[indexend]);
                        MyDayTaskLabelEnd.Add(MyDayTaskLabel[indexend]);

                        MyDayTaskLabel.RemoveAt(indexend);
                        MyDayTask.RemoveAt(indexend);
                        MyDayTaskCheckEnd.RemoveAt(indexend);

                        MyDayTaskLabelEnd[MyDayTaskLabelEnd.Count - 1].Font = new Font("Times New Roman", 10, FontStyle.Strikeout);

                        UpdateMyDayTask();
                        EndTaskPanel.Controls.Add(MyDayEndTaskPanels[MyDayEndTaskPanels.Count - 1]);
                        if (MyDayEndTaskPanels.Count == 1)
                        {
                            MyDayEndTaskPanels[MyDayEndTaskPanels.Count - 1].Location = new Point(17, 26);
                        }
                        else
                        {
                            MyDayEndTaskPanels[MyDayEndTaskPanels.Count - 1].Location = new Point(17, MyDayEndTaskPanels[MyDayEndTaskPanels.Count - 2].Location.Y + 60);
                        }
                    }
                }
                else if (MyDayTaskCheckBack.Contains(clicked))
                {
                    int indexback = MyDayTaskCheckBack.IndexOf(clicked);
                    if (MyDayTaskCheckBack[indexback].Checked == false)
                    {
                        MyDayTask.Add(MyDayEndTaskPanels[indexback]);
                        MyDayTaskCheckEnd.Add(MyDayTaskCheckBack[indexback]);
                        MyDayTaskLabel.Add(MyDayTaskLabelEnd[indexback]);

                        MyDayEndTaskPanels.RemoveAt(indexback);
                        MyDayTaskCheckBack.RemoveAt(indexback);
                        MyDayTaskLabelEnd.RemoveAt(indexback);

                        MyDayTaskLabel[MyDayTaskLabel.Count - 1].Font = new Font("Times New Roman", 10, FontStyle.Regular);

                        UpdateMyDayTask();
                        UpdateMyDayTaskEnd();
                    }
                }
            }
            else if(indexcattegory == 2)
            {
                if (MyTaskCheckEnd.Contains(clicked))
                {
                    int indexend = MyTaskCheckEnd.IndexOf(clicked);
                    if (MyTaskCheckEnd[indexend].Checked == true)
                    {
                        if (EndTaskPanel.Visible == false)
                        {
                            EndTaskPanel.Visible = true;
                        }

                        MyTaskEndPanels.Add(MyTask[indexend]);
                        MyTaskCheckBack.Add(MyTaskCheckEnd[indexend]);
                        MyTaskLabelEnd.Add(MyTaskLabel[indexend]);

                        MyTaskLabel.RemoveAt(indexend);
                        MyTask.RemoveAt(indexend);
                        MyTaskCheckEnd.RemoveAt(indexend);

                        MyTaskLabelEnd[MyTaskLabelEnd.Count - 1].Font = new Font("Times New Roman", 10, FontStyle.Strikeout);

                        UpdateMyTask();
                        EndTaskPanel.Controls.Add(MyTaskEndPanels[MyTaskEndPanels.Count - 1]);
                        if (MyTaskEndPanels.Count == 1)
                        {
                            MyTaskEndPanels[MyTaskEndPanels.Count - 1].Location = new Point(17, 26);
                        }
                        else
                        {
                            MyTaskEndPanels[MyTaskEndPanels.Count - 1].Location = new Point(17, MyTaskEndPanels[MyTaskEndPanels.Count - 2].Location.Y + 60);
                        }
                    }
                }
                else if (MyTaskCheckBack.Contains(clicked))
                {
                    int indexback = MyTaskCheckBack.IndexOf(clicked);
                    if (MyTaskCheckBack[indexback].Checked == false)
                    {
                        MyTask.Add(MyTaskEndPanels[indexback]);
                        MyTaskCheckEnd.Add(MyTaskCheckBack[indexback]);
                        MyTaskLabel.Add(MyTaskLabelEnd[indexback]);

                        MyTaskEndPanels.RemoveAt(indexback);
                        MyTaskCheckBack.RemoveAt(indexback);
                        MyTaskLabelEnd.RemoveAt(indexback);

                        MyTaskLabel[MyTaskLabel.Count - 1].Font = new Font("Times New Roman", 10, FontStyle.Regular);

                        UpdateMyTask();
                        UpdateMyTaskEnd();
                    }
                }
            }
        }

        private void ChangeBoxTask_TextChanged(object sender, EventArgs e)
        {
            if(SettingsPanel.Visible == true)
            {
                MyDayTaskLabel[index].Text = ChangeBoxTask.Text;
            }
        }
    }
}
