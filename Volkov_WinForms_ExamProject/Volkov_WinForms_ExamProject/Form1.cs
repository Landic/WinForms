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
using Volkov_WinForms_ExamProject.Models;
using Volkov_WinForms_ExamProject.Properties;

namespace Volkov_WinForms_ExamProject
{
    public partial class Form1 : Form
    {
        List<Button> CategoryTask;

        List<Panel> MyDayTask; // лист для хранение задач
        List<CheckBox> MyDayTaskCheckEnd;
        List<Panel> MyDayEndTaskPanels;
        List<Button> MyDayButtonImportant;
        List<CheckBox> MyDayTaskCheckBack;
        List<Label> MyDayTaskLabelEnd;
        List<Label> MyDayTaskLabel;
        List<Button> MyDayButtonImportantEnd;

        List<Panel> MyTask;
        List<CheckBox> MyTaskCheckEnd;
        List<Panel> MyTaskEndPanels;
        List<Button> MyTaskButtonImportant;
        List<CheckBox> MyTaskCheckBack;
        List<Label> MyTaskLabelEnd;
        List<Label> MyTaskLabel;
        List<Button> MyTaskButtonImportantEnd;

        List<Panel> ImportantTask;
        List<CheckBox> ImportantTaskCheckEnd;
        List<Label> ImportantTaskLabel;
        List<Button> ImportantTaskButton;


        int index;
        int indexcattegory;
        List<int> importantornotMyDay;
        List<int> importantornotMyTask;

        public Form1()
        {
            InitializeComponent();
            index = 0;
            indexcattegory = 0;
            importantornotMyDay = new List<int>();
            importantornotMyTask = new List<int>();

            MyDayTaskCheckEnd = new List<CheckBox>();
            MyDayTask = new List<Panel>();
            CategoryTask = new List<Button>() { button1, button2, button3 };
            MyDayEndTaskPanels = new List<Panel>();
            MyDayTaskCheckBack = new List<CheckBox>();
            MyDayTaskLabel = new List<Label>();
            MyDayTaskLabelEnd = new List<Label>();
            MyDayButtonImportant = new List<Button>();
            MyDayButtonImportantEnd = new List<Button>();

            MyTask = new List<Panel>();
            MyTaskCheckEnd = new List<CheckBox>();
            MyTaskLabel = new List<Label>();
            MyTaskLabelEnd = new List<Label>();
            MyTaskCheckBack = new List<CheckBox>();
            MyTaskEndPanels= new List<Panel>();
            MyTaskButtonImportant = new List<Button>();
            MyTaskButtonImportantEnd = new List<Button>();

            ImportantTask = new List<Panel>();
            ImportantTaskCheckEnd = new List<CheckBox>();
            ImportantTaskLabel = new List<Label>();
            ImportantTaskButton = new List<Button>();

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

        private void Circle_Panel_Important()
        {
            foreach (var i in ImportantTask)
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

        private void UpdateImportantTask()
        {
            Thread updateThread = new Thread(() =>
            {
                Invoke(new Action(() =>
                {
                    if (ImportantTask.Count > 0)
                    {
                        TaskPanel.Controls.Clear();
                        foreach (Panel i in ImportantTask)
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
                        EndTaskPanel.Visible = true;
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
            indexcattegory = CategoryTask.IndexOf(clickbut);
            for (int i = 0; i < CategoryTask.Count; i++)
            {
                CategoryTask[i].BackColor = Color.FromArgb(64, 64, 64);
            }
            label1.Text = "Важно";
            label1.ForeColor = Color.FromArgb(222,166,177);
            label2.Visible = false;
            pictureBox1.Image = Resources.ImportantTask_Ico;
            button2.BackColor = Color.FromArgb(84, 84, 84);
            EndTaskPanel.Visible = false;
            UpdateImportantTask();
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
            if(indexcattegory == 0)
            {
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
                foreach(Button i in MyDayButtonImportant)
                {
                    i.Location = new Point(MyDayTask[MyDayTask.Count - 1].Width - 40, (MyDayTask[MyDayTask.Count - 1].Height / 2) - 13);
                }
                if (MyDayEndTaskPanels.Count > 0)
                {
                    for (int i = 0; i < MyDayEndTaskPanels.Count; i++)
                    {
                        MyDayEndTaskPanels[i].Size = new Size(EndTaskPanel.Width - 40, EndTaskPanel.Height - 92);
                    }
                }
            }
            if(indexcattegory == 2)
            {
                Panel clickedPanel = sender as Panel;
                if (MyTask.Contains(clickedPanel))
                {
                    index = MyTask.IndexOf(clickedPanel);
                    ChangeBoxTask.Text = MyTaskLabel[index].Text;
                }
                else if (MyTaskEndPanels.Contains(clickedPanel))
                {
                    index = MyTaskEndPanels.IndexOf(clickedPanel);
                }
                //получаем индекс кликнутой панели задач
                foreach (Panel i in MyTask)
                {
                    i.Size = new Size(TaskPanel.Width - 40, 55);
                    i.Margin = new Padding(17, 0, 0, 5);
                }
                textBox1.Size = new Size(AddPanel.Width - 18, AddPanel.Height - 18); // меняется размер текстбокса
                if (MyTaskEndPanels.Count > 0)
                {
                    for (int i = 0; i < MyTaskEndPanels.Count; i++)
                    {
                        MyTaskEndPanels[i].Size = new Size(EndTaskPanel.Width - 40, EndTaskPanel.Height - 92);
                    }
                }
            }
            Circle_Panel_MyTask();
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
            if(indexcattegory == 0)
            {
                SettingsPanel.Visible = false;
                ChangeBoxTask.Text = string.Empty;
                foreach (Panel i in MyDayTask)
                {
                    i.Size = new Size(TaskPanel.Width - 40, 55);
                    i.Margin = new Padding(17, 0, 0, 5);
                }
                foreach (Button i in MyDayButtonImportant)
                {
                    i.Location = new Point(MyDayTask[MyDayTask.Count - 1].Width - 40, (MyDayTask[MyDayTask.Count - 1].Height / 2) - 13);
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
            }
            else if(indexcattegory == 2)
            {
                SettingsPanel.Visible = false;
                ChangeBoxTask.Text = string.Empty;
                foreach (Panel i in MyTask)
                {
                    i.Size = new Size(TaskPanel.Width - 40, 55);
                    i.Margin = new Padding(17, 0, 0, 5);
                }
                if (MyTaskEndPanels.Count > 0)
                {
                    foreach (Panel i in MyTaskEndPanels)
                    {
                        i.Size = new Size(EndTaskPanel.Width - 40, 55);
                        i.Margin = new Padding(17, 0, 0, 5);
                    }
                }
                textBox1.Size = new Size(AddPanel.Width - 18, AddPanel.Height - 18); // меняется размер текстбокса
            }
            Circle_Panel_MyTask();
            Circle_Panel();// метод для закругление панели задач
            Circle_TextBox(); // закругляет текстбокс
        }

        private void AddImportant_Click(object sender, EventArgs e)
        {
            if(indexcattegory == 0)
            {
                Button clicked = sender as Button;
                int indexclickedimportant = MyDayButtonImportant.IndexOf(clicked);
                if (importantornotMyDay[indexclickedimportant] == 0)
                {
                    MyDayButtonImportant[indexclickedimportant].BackgroundImage = Image.FromFile("ImportantButton_Clicked_Ico.png");
                    importantornotMyTask[indexclickedimportant] = 1;
                    importantornotMyDay[indexclickedimportant] = 1;
                    ImportantTask.Add(MyDayTask[indexclickedimportant]);
                    ImportantTaskCheckEnd.Add(MyDayTaskCheckEnd[indexclickedimportant]);
                    ImportantTaskButton.Add(MyDayButtonImportant[indexclickedimportant]);
                    ImportantTaskLabel.Add(MyDayTaskLabel[indexclickedimportant]);
                    
                }
                else
                {
                    MyDayButtonImportant[indexclickedimportant].BackgroundImage = Image.FromFile("ImportantButton_Ico.png");
                    importantornotMyDay[indexclickedimportant] = 0;
                    for(int i = 0; i < ImportantTask.Count; i++)
                    {
                        if (ImportantTask[i] == MyDayTask[indexclickedimportant])
                        {
                            ImportantTask.RemoveAt(i);
                            ImportantTaskCheckEnd.RemoveAt(i);
                            ImportantTaskButton.RemoveAt(i);
                            ImportantTaskLabel.RemoveAt(i);
                        }
                    }
                }
                
            }
            else if(indexcattegory == 1)
            {
                Button clicked = sender as Button;
                int indexclickedimportant = ImportantTaskButton.IndexOf(clicked);
                if (MyDayTask.Contains(ImportantTask[indexclickedimportant]))
                {
                    for (int i = 0; i < MyDayTask.Count; i++)
                    {
                        if (MyDayTask[i] == ImportantTask[indexclickedimportant])
                        {
                            MyDayButtonImportant[i].BackgroundImage = Image.FromFile("ImportantButton_Ico.png");
                            importantornotMyDay[i] = 0;
                            break;
                        }
                    }
                }
                for(int i = 0; i < MyTask.Count; i++)
                {
                    if (MyTask[i] == ImportantTask[indexclickedimportant])
                    {
                        MyTaskButtonImportant[i].BackgroundImage = Image.FromFile("ImportantButton_Ico.png");
                        importantornotMyTask[i] = 0;
                        break;
                    }
                }
                ImportantTask.RemoveAt(indexclickedimportant);
                ImportantTaskCheckEnd.RemoveAt(indexclickedimportant);
                ImportantTaskButton.RemoveAt(indexclickedimportant);
                ImportantTaskLabel.RemoveAt(indexclickedimportant);
                UpdateImportantTask();
            }
            else if(indexcattegory == 2)
            {
                Button clicked = sender as Button;
                int indexclickedimportant = MyTaskButtonImportant.IndexOf(clicked);
                if (importantornotMyTask[indexclickedimportant] == 0)
                {
                    MyTaskButtonImportant[indexclickedimportant].BackgroundImage = Image.FromFile("ImportantButton_Clicked_Ico.png");
                    for(int i = 0; i < MyDayTask.Count; i++)
                    {
                        if (MyDayTask[i] == MyTask[indexclickedimportant])
                        {
                            importantornotMyDay[i] = 1;
                            break;
                        }
                    }

                    importantornotMyTask[indexclickedimportant] = 1;
                    ImportantTask.Add(MyTask[indexclickedimportant]);
                    ImportantTaskCheckEnd.Add(MyTaskCheckEnd[indexclickedimportant]);
                    ImportantTaskButton.Add(MyTaskButtonImportant[indexclickedimportant]);
                    ImportantTaskLabel.Add(MyTaskLabel[indexclickedimportant]);

                }
                else
                {
                    MyTaskButtonImportant[indexclickedimportant].BackgroundImage = Image.FromFile("ImportantButton_Ico.png");
                    if (MyDayTask.Contains(MyTask[indexclickedimportant]))
                    {
                        int tempindex = MyDayButtonImportant.IndexOf(clicked);
                        importantornotMyTask[indexclickedimportant] = 0;
                        importantornotMyDay[tempindex] = 0;
                        for (int i = 0; i < ImportantTask.Count; i++)
                        {
                            if (ImportantTask[i] == MyDayTask[indexclickedimportant])
                            {
                                ImportantTask.RemoveAt(i);
                                ImportantTaskCheckEnd.RemoveAt(i);
                                ImportantTaskButton.RemoveAt(i);
                                ImportantTaskLabel.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    
                    else
                    {
                        importantornotMyTask[indexclickedimportant] = 0;
                        for(int i = 0; i < ImportantTask.Count; i++)
                        {
                            if (ImportantTask[i] == MyTask[indexclickedimportant])
                            {
                                ImportantTask.RemoveAt(i);
                                ImportantTaskCheckEnd.RemoveAt(i);
                                ImportantTaskButton.RemoveAt(i);
                                ImportantTaskLabel.RemoveAt(i);
                                break;
                            }
                        }
                    }
                }
            }
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

                        MyDayButtonImportant.Add(new Button());

                        MyDayButtonImportant[MyDayButtonImportant.Count - 1].FlatAppearance.BorderSize = 0;
                        MyDayButtonImportant[MyDayButtonImportant.Count - 1].FlatStyle = FlatStyle.Flat;
                        MyDayButtonImportant[MyDayButtonImportant.Count - 1].Size = new Size(25, 25);
                        MyDayButtonImportant[MyDayButtonImportant.Count - 1].BackgroundImage = Image.FromFile("ImportantButton_Ico.png");
                        
                        MyDayButtonImportant[MyDayButtonImportant.Count - 1].BackgroundImageLayout = ImageLayout.Zoom;
                        MyDayButtonImportant[MyDayButtonImportant.Count - 1].Click += new EventHandler(AddImportant_Click);
                        importantornotMyDay.Add(0);
                        importantornotMyTask.Add(0);

                        MyDayTask[MyDayTask.Count - 1].Controls.Add(MyDayButtonImportant[MyDayButtonImportant.Count - 1]);

                        MyDayButtonImportant[MyDayButtonImportant.Count - 1].Location = new Point(MyDayTask[MyDayTask.Count - 1].Width - 40, (MyDayTask[MyDayTask.Count - 1].Height / 2) - 13);

                        TaskPanel.Controls.Add(MyDayTask[MyDayTask.Count - 1]);

                        MyTask.Add(MyDayTask[MyDayTaskLabel.Count - 1]);
                        MyTaskCheckEnd.Add(MyDayTaskCheckEnd[MyDayTaskCheckEnd.Count - 1]);
                        MyTaskLabel.Add(MyDayTaskLabel[MyDayTaskLabel.Count - 1]);
                        MyTaskButtonImportant.Add(MyDayButtonImportant[MyDayButtonImportant.Count - 1]);

                        Circle_Panel();
                        textBox1.Clear();
                    }
                    else if(indexcattegory == 1)
                    {
                        ImportantTask.Add(new Panel());

                        ImportantTask[ImportantTask.Count - 1].BackColor = Color.FromArgb(44, 44, 44);
                        ImportantTask[ImportantTask.Count - 1].Size = new Size(TaskPanel.Width - 40, 55);
                        ImportantTask[ImportantTask.Count - 1].Margin = new Padding(17, 0, 0, 5);
                        ImportantTask[ImportantTask.Count - 1].MouseEnter += new EventHandler(panel_MouseEnter);
                        ImportantTask[ImportantTask.Count - 1].MouseLeave += new EventHandler(panel_MouseLeave);
                        ImportantTask[ImportantTask.Count - 1].Click += new EventHandler(panel_Click);

                        ImportantTaskCheckEnd.Add(new CheckBox());

                        ImportantTaskCheckEnd[ImportantTaskCheckEnd.Count - 1].FlatStyle = FlatStyle.Popup;
                        ImportantTaskCheckEnd[ImportantTaskCheckEnd.Count - 1].Size = new Size(10, 10);
                        ImportantTaskCheckEnd[ImportantTaskCheckEnd.Count - 1].CheckedChanged += new EventHandler(EndTask_CheckedChanged);
                        ImportantTask[ImportantTask.Count - 1].Controls.Add(ImportantTaskCheckEnd[ImportantTaskCheckEnd.Count - 1]);
                        ImportantTaskCheckEnd[ImportantTaskCheckEnd.Count - 1].Location = new Point(10, (ImportantTask[ImportantTask.Count - 1].Height / 2) - 5);

                        ImportantTaskLabel.Add(new Label());

                        ImportantTaskLabel[ImportantTaskLabel.Count - 1].ForeColor = Color.Gainsboro;
                        ImportantTaskLabel[ImportantTaskLabel.Count - 1].Font = new Font("Times New Roman", 10, FontStyle.Regular);
                        ImportantTaskLabel[ImportantTaskLabel.Count - 1].Location = new Point(40, (ImportantTask[ImportantTask.Count - 1].Height / 2) - 10);
                        ImportantTaskLabel[ImportantTaskLabel.Count - 1].Text = textBox1.Text;
                        ImportantTask[ImportantTask.Count - 1].Controls.Add(ImportantTaskLabel[ImportantTaskLabel.Count - 1]);

                        ImportantTaskButton.Add(new Button());

                        ImportantTaskButton[ImportantTaskButton.Count - 1].FlatAppearance.BorderSize = 0;
                        ImportantTaskButton[ImportantTaskButton.Count - 1].FlatStyle = FlatStyle.Flat;
                        ImportantTaskButton[ImportantTaskButton.Count - 1].Size = new Size(25, 25);
                        ImportantTaskButton[ImportantTaskButton.Count - 1].BackgroundImage = Image.FromFile("ImportantButton_Clicked_Ico.png");
                        ImportantTaskButton[ImportantTaskButton.Count - 1].BackgroundImageLayout = ImageLayout.Zoom;
                        ImportantTaskButton[ImportantTaskButton.Count - 1].Click += new EventHandler(AddImportant_Click);
                        importantornotMyTask.Add(1);

                        ImportantTask[ImportantTask.Count - 1].Controls.Add(ImportantTaskButton[ImportantTaskButton.Count - 1]);

                        ImportantTaskButton[ImportantTaskButton.Count - 1].Location = new Point(ImportantTask[ImportantTask.Count - 1].Width - 40, (ImportantTask[ImportantTask.Count - 1].Height / 2) - 13);

                        TaskPanel.Controls.Add(ImportantTask[ImportantTask.Count - 1]);

                        MyTask.Add(ImportantTask[ImportantTask.Count - 1]);
                        MyTaskCheckEnd.Add(ImportantTaskCheckEnd[ImportantTaskCheckEnd.Count - 1]);
                        MyTaskLabel.Add(ImportantTaskLabel[ImportantTaskLabel.Count - 1]);
                        MyTaskButtonImportant.Add(ImportantTaskButton[ImportantTaskButton.Count - 1]);

                        Circle_Panel_Important();
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

                        MyTaskButtonImportant.Add(new Button());

                        MyTaskButtonImportant[MyTaskButtonImportant.Count - 1].FlatAppearance.BorderSize = 0;
                        MyTaskButtonImportant[MyTaskButtonImportant.Count - 1].FlatStyle = FlatStyle.Flat;
                        MyTaskButtonImportant[MyTaskButtonImportant.Count - 1].Size = new Size(25, 25);
                        MyTaskButtonImportant[MyTaskButtonImportant.Count - 1].BackgroundImage = Image.FromFile("ImportantButton_Ico.png");
                        MyTaskButtonImportant[MyTaskButtonImportant.Count - 1].BackgroundImageLayout = ImageLayout.Zoom;
                        MyTaskButtonImportant[MyTaskButtonImportant.Count - 1].Click += new EventHandler(AddImportant_Click);
                        importantornotMyTask.Add(0);

                        MyTask[MyTask.Count - 1].Controls.Add(MyTaskButtonImportant[MyTaskButtonImportant.Count - 1]);

                        MyTaskButtonImportant[MyTaskButtonImportant.Count - 1].Location = new Point(MyTask[MyTask.Count - 1].Width - 40, (MyTask[MyTask.Count - 1].Height / 2) - 13);

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
            if (indexcattegory == 0)
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

                        MyDayButtonImportant[indexend].BackgroundImage = Image.FromFile("ImportantButton_Ico.png");
                        MyDayButtonImportant[indexend].Enabled = false;

                        MyDayEndTaskPanels.Add(MyDayTask[indexend]);
                        MyDayTaskCheckBack.Add(MyDayTaskCheckEnd[indexend]);
                        MyDayTaskLabelEnd.Add(MyDayTaskLabel[indexend]);
                        MyDayButtonImportantEnd.Add(MyDayButtonImportant[indexend]);

                        for(int i = 0; i < ImportantTask.Count; i++)
                        {
                            if (ImportantTask[i] == MyDayTask[indexend])
                            {
                                ImportantTask.RemoveAt(i);
                                ImportantTaskCheckEnd.RemoveAt(i);
                                ImportantTaskLabel.RemoveAt(i);
                                ImportantTaskButton.RemoveAt(i);
                                break;
                            }
                        }

                        for(int i = 0; i< MyTask.Count; i++)
                        {
                            if (MyTask[i] == MyDayTask[indexend])
                            {
                                MyTaskEndPanels.Add(MyDayTask[indexend]);
                                MyTaskCheckBack.Add(MyDayTaskCheckEnd[indexend]);
                                MyTaskLabelEnd.Add(MyDayTaskLabel[indexend]);
                                MyTaskButtonImportantEnd.Add(MyDayButtonImportant[indexend]);
                                importantornotMyTask.Remove(i);
                                MyTask.RemoveAt(i);
                                MyTaskCheckEnd.RemoveAt(i);
                                MyTaskLabel.RemoveAt(i);
                                MyTaskButtonImportant.RemoveAt(i);
                                break;
                            }
                        }
                        MyDayButtonImportant.RemoveAt(indexend);
                        MyDayTaskLabel.RemoveAt(indexend);
                        MyDayTask.RemoveAt(indexend);
                        MyDayTaskCheckEnd.RemoveAt(indexend);
                        importantornotMyDay.RemoveAt(indexend);

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
                        MyDayButtonImportantEnd[indexback].Enabled = true;
                        MyTaskButtonImportantEnd[indexback].Enabled = true;
                        MyDayTask.Add(MyDayEndTaskPanels[indexback]);
                        MyDayTaskCheckEnd.Add(MyDayTaskCheckBack[indexback]);
                        MyDayTaskLabel.Add(MyDayTaskLabelEnd[indexback]);
                        MyDayButtonImportant.Add(MyDayButtonImportantEnd[indexback]);
                        importantornotMyDay.Add(0);
                        MyDayEndTaskPanels.RemoveAt(indexback);
                        MyDayTaskCheckBack.RemoveAt(indexback);
                        MyDayTaskLabelEnd.RemoveAt(indexback);
                        MyDayButtonImportantEnd.RemoveAt(indexback);

                        MyTask.Add(MyTaskEndPanels[indexback]);
                        MyTaskCheckEnd.Add(MyTaskCheckBack[indexback]);
                        MyTaskLabel.Add(MyTaskLabelEnd[indexback]);
                        MyTaskButtonImportant.Add(MyTaskButtonImportantEnd[indexback]);
                        importantornotMyTask.Add(0);
                        MyTaskEndPanels.RemoveAt(indexback);
                        MyTaskCheckBack.RemoveAt(indexback);
                        MyTaskLabelEnd.RemoveAt(indexback);
                        MyTaskButtonImportantEnd.RemoveAt(indexback);

                        MyDayTaskLabel[MyDayTaskLabel.Count - 1].Font = new Font("Times New Roman", 10, FontStyle.Regular);

                        UpdateMyDayTask();
                        UpdateMyDayTaskEnd();
                    }
                }
            }
            else if (indexcattegory == 1)
            {
                int indexend = ImportantTaskCheckEnd.IndexOf(clicked);
                if (MyDayTask.Contains(ImportantTask[indexend]))
                {
                    for (int i = 0; i < MyDayTask.Count; i++)
                    {
                        if (MyDayTask[i] == ImportantTask[indexend])
                        {
                            MyDayButtonImportant[i].BackgroundImage = Image.FromFile("ImportantButton_Ico.png");
                            MyDayButtonImportant[i].Enabled = false;
                            MyDayEndTaskPanels.Add(ImportantTask[indexend]);
                            MyDayTaskCheckBack.Add(ImportantTaskCheckEnd[indexend]);
                            MyDayTaskLabelEnd.Add(ImportantTaskLabel[indexend]);
                            MyDayButtonImportantEnd.Add(ImportantTaskButton[indexend]);
                            MyDayTask.RemoveAt(i);
                            MyDayTaskCheckEnd.RemoveAt(i);
                            MyDayTaskLabel.RemoveAt(i);
                            MyDayButtonImportant.RemoveAt(i);
                            importantornotMyDay.RemoveAt(i);
                            break;
                        }
                    }
                }
                for (int i = 0; i < MyTask.Count; i++)
                {
                    if (MyTask[i] == ImportantTask[indexend])
                    {
                        MyTaskButtonImportant[i].BackgroundImage = Image.FromFile("ImportantButton_Ico.png");
                        MyTaskButtonImportant[i].Enabled = false;
                        MyTaskEndPanels.Add(ImportantTask[indexend]);
                        MyTaskCheckBack.Add(ImportantTaskCheckEnd[indexend]);
                        MyTaskLabelEnd.Add(ImportantTaskLabel[indexend]);
                        MyTaskButtonImportantEnd.Add(ImportantTaskButton[indexend]);
                        MyTask.RemoveAt(i);
                        MyTaskCheckEnd.RemoveAt(i);
                        MyTaskLabel.RemoveAt(i);
                        MyTaskButtonImportant.RemoveAt(i);
                        importantornotMyTask.RemoveAt(i);
                        break;
                    }
                }
                ImportantTask.RemoveAt(indexend);
                ImportantTaskCheckEnd.RemoveAt(indexend);
                ImportantTaskLabel.RemoveAt(indexend);
                ImportantTaskButton.RemoveAt(indexend);
                UpdateImportantTask();
            }
            else if (indexcattegory == 2)
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
                        for (int i = 0; i < MyDayTask.Count; i++)
                        {
                            if (MyDayTask[i] == MyTask[indexend])
                            {
                                MyDayButtonImportant[i].BackgroundImage = Image.FromFile("ImportantButton_Ico.png");
                                MyDayButtonImportant[i].Enabled = false;
                                MyDayEndTaskPanels.Add(MyDayTask[i]);
                                MyDayTaskCheckBack.Add(MyDayTaskCheckEnd[i]);
                                MyDayTaskLabelEnd.Add(MyDayTaskLabel[i]);
                                MyDayButtonImportantEnd.Add(MyDayButtonImportant[i]);
                                MyDayTaskLabel.RemoveAt(i);
                                MyDayTask.RemoveAt(i);
                                MyDayTaskCheckEnd.RemoveAt(i);
                                MyDayButtonImportant.RemoveAt(i);
                                importantornotMyDay.RemoveAt(i);
                                for (int j = 0; j < ImportantTask.Count; j++)
                                {
                                    if (ImportantTask[j] == MyTask[indexend])
                                    {
                                        ImportantTask.RemoveAt(j);
                                        ImportantTaskCheckEnd.RemoveAt(j);
                                        ImportantTaskLabel.RemoveAt(j);
                                        ImportantTaskButton.RemoveAt(j);
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        for(int i = 0; i < ImportantTask.Count; i++)
                        {
                            if (ImportantTask[i] == MyTask[indexend])
                            {
                                ImportantTask.RemoveAt(i);
                                ImportantTaskCheckEnd.RemoveAt(i);
                                ImportantTaskLabel.RemoveAt(i);
                                ImportantTaskButton.RemoveAt(i);
                                break;
                            }
                        }
                        MyTaskButtonImportant[indexend].BackgroundImage = Image.FromFile("ImportantButton_Ico.png");
                        MyTaskButtonImportant[indexend].Enabled = false;
                        MyTaskEndPanels.Add(MyTask[indexend]);
                        MyTaskCheckBack.Add(MyTaskCheckEnd[indexend]);
                        MyTaskLabelEnd.Add(MyTaskLabel[indexend]);
                        MyTaskButtonImportantEnd.Add(MyTaskButtonImportant[indexend]);

                        MyTaskLabel.RemoveAt(indexend);
                        MyTask.RemoveAt(indexend);
                        MyTaskCheckEnd.RemoveAt(indexend);
                        MyTaskButtonImportant.RemoveAt(indexend);
                        importantornotMyTask.RemoveAt(indexend);

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
                        UpdateMyTaskEnd();
                    }
                }
                else if (MyTaskCheckBack.Contains(clicked))
                {
                    int indexback = MyTaskCheckBack.IndexOf(clicked);
                    if (MyTaskCheckBack[indexback].Checked == false)
                    {
                        MyTaskButtonImportantEnd[indexback].Enabled = true;
                        MyTask.Add(MyTaskEndPanels[indexback]);
                        MyTaskCheckEnd.Add(MyTaskCheckBack[indexback]);
                        MyTaskLabel.Add(MyTaskLabelEnd[indexback]);
                        MyTaskButtonImportant.Add(MyTaskButtonImportantEnd[indexback]);
                        importantornotMyTask.Add(0);
                        for(int i = 0; i < MyDayEndTaskPanels.Count; i++)
                        {
                            if (MyDayEndTaskPanels[i] == MyTaskEndPanels[indexback])
                            {
                                MyDayButtonImportantEnd[i].Enabled = true;
                                MyDayTask.Add(MyDayEndTaskPanels[i]);
                                MyDayTaskCheckEnd.Add(MyDayTaskCheckBack[i]);
                                MyDayTaskLabel.Add(MyDayTaskLabelEnd[i]);
                                MyDayButtonImportant.Add(MyDayButtonImportantEnd[i]);
                                importantornotMyDay.Add(0);
                                MyDayTaskLabelEnd.RemoveAt(i);
                                MyDayEndTaskPanels.RemoveAt(i);
                                MyDayTaskCheckBack.RemoveAt(i);
                                MyDayButtonImportantEnd.RemoveAt(i);
                                break;
                            }
                        }
                        MyTaskEndPanels.RemoveAt(indexback);
                        MyTaskCheckBack.RemoveAt(indexback);
                        MyTaskLabelEnd.RemoveAt(indexback);
                        MyTaskButtonImportantEnd.RemoveAt(indexback);

                        MyTaskLabel[MyTaskLabel.Count - 1].Font = new Font("Times New Roman", 10, FontStyle.Regular);

                        UpdateMyTask();
                        UpdateMyTaskEnd();
                    }
                }
            }
        }

        private void ChangeBoxTask_TextChanged(object sender, EventArgs e)
        {
            //if(SettingsPanel.Visible == true)
            //{
            //    MyDayTaskLabel[index].Text = ChangeBoxTask.Text;
            //}
        }
    }
}
