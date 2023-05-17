using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
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
        Controller controller;

        List<Button> CategoryTask;

        List<Panel> MyDayTask; // лист для хранение задач
        List<CheckBox> MyDayTaskCheckEnd;
        List<Panel> MyDayEndTaskPanels;
        List<Button> MyDayButtonImportant;
        List<Label> MyDayEndDate;
        List<CheckBox> MyDayTaskCheckBack;
        List<Label> MyDayTaskLabelEnd;
        List<Label> MyDayTaskLabel;
        List<Button> MyDayButtonImportantEnd;

        List<Panel> MyTask;
        List<CheckBox> MyTaskCheckEnd;
        List<Panel> MyTaskEndPanels;
        List<Button> MyTaskButtonImportant;
        List<Label> MyTaskEndDate;
        List<CheckBox> MyTaskCheckBack;
        List<Label> MyTaskLabelEnd;
        List<Label> MyTaskLabel;
        List<Button> MyTaskButtonImportantEnd;

        List<Panel> ImportantTask;
        List<CheckBox> ImportantTaskCheckEnd;
        List<Label> ImportantTaskLabel;
        List<Label> ImportantDateEnd;
        List<Button> ImportantTaskButton;


        int index;
        int indexcattegory;
        List<int> importantornotMyDay;
        List<int> importantornotMyTask;

        int theam;

        int[] rgb;
        int[] rgb2;

        int[] rgb3;
        int[] rgb4;

        public Form1()
        {
            InitializeComponent();
            controller = new Controller();
            theam = 0;
            rgb3 = new int[3] { 64, 64, 64 };
            rgb4 = new int[3] { 84, 84, 84 };
            rgb = new int[3] { 44, 44, 44 };
            rgb2 = new int[3] { 223, 223, 223 };

            index = 0;
            indexcattegory = 0;
            importantornotMyDay = new List<int>();
            importantornotMyTask = new List<int>();

            MyDayTaskCheckEnd = new List<CheckBox>();
            MyDayTask = new List<Panel>();
            CategoryTask = new List<Button>() { button1, button2, button3 };
            MyDayEndTaskPanels = new List<Panel>();
            MyTaskEndDate = new List<Label>();
            MyDayEndDate = new List<Label>();
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
            ImportantDateEnd = new List<Label>();
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
            path.AddArc(TextBoxSearch.Width - borderRadius - 1, 0, borderRadius, borderRadius, 270, 90);
            path.AddArc(TextBoxSearch.Width - borderRadius - 1, TextBoxSearch.Height - borderRadius - 1, borderRadius, borderRadius, 0, 90); // Нижний правый угол
            path.AddArc(0, TextBoxSearch.Height - borderRadius - 1, borderRadius, borderRadius, 90, 90);
            path.CloseAllFigures();
            TextBoxSearch.Region = new Region(path);     
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

        private void BackSizeMyDay()
        {
            Thread updateThread = new Thread(() =>
            {
                Invoke(new Action(() =>
                {
                    SettingsPanel.Visible = false;
                    ChangeBoxTask.Clear();
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
                        foreach (Button i in MyDayButtonImportantEnd)
                        {
                            i.Location = new Point(MyDayTask[MyDayTask.Count - 1].Width - 40, (MyDayTask[MyDayTask.Count - 1].Height / 2) - 13);
                        }
                    }
                    textBox1.Size = new Size(AddPanel.Width - 18, AddPanel.Height - 18); // меняется размер текстбокса
                    UpdateMyDayTask();
                    Circle_Panel();
                    Circle_Panel();// метод для закругление панели задач
                    Circle_TextBox(); // закругляет текстбокс
                }));
            });
            updateThread.Start();
        }

        private void BackSizeImportantTask()
        {
            Thread updateThread = new Thread(() =>
            {
                Invoke(new Action(() =>
                {
                    SettingsPanel.Visible = false;
                    ChangeBoxTask.Clear();
                    foreach (Panel i in ImportantTask)
                    {
                        i.Size = new Size(TaskPanel.Width - 40, 55);
                        i.Margin = new Padding(17, 0, 0, 5);
                    }
                    foreach (Button i in ImportantTaskButton)
                    {
                        i.Location = new Point(ImportantTask[ImportantTask.Count - 1].Width - 40, (ImportantTask[ImportantTask.Count - 1].Height / 2) - 13);
                    }
                    textBox1.Size = new Size(AddPanel.Width - 18, AddPanel.Height - 18); // меняется размер текстбокса
                    UpdateImportantTask();
                    Circle_Panel_Important();
                    Circle_TextBox(); // закругляет текстбокс
                }));
            });
            updateThread.Start();
        }

        private void BackSizeMyTask()
        {
            Thread updateThread = new Thread(() =>
            {
                Invoke(new Action(() =>
                {
                    SettingsPanel.Visible = false;
                    ChangeBoxTask.Clear();
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
                        foreach (Button i in MyTaskButtonImportantEnd)
                        {
                            i.Location = new Point(MyTaskEndPanels[MyTaskEndPanels.Count - 1].Width - 40, (MyTaskEndPanels[MyTaskEndPanels.Count - 1].Height / 2) - 13);
                        }
                    }
                    foreach (Button i in MyTaskButtonImportant)
                    {
                        i.Location = new Point(MyTask[MyTask.Count - 1].Width - 40, (MyTask[MyTask.Count - 1].Height / 2) - 13);
                    }
                    textBox1.Size = new Size(AddPanel.Width - 18, AddPanel.Height - 18); // меняется размер текстбокса
                    UpdateMyTask();
                    Circle_Panel_MyTask();
                    Circle_TextBox(); // закругляет текстбокс
                }));
            });
            updateThread.Start();
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
                CategoryTask[i].BackColor = Color.FromArgb(rgb3[0], rgb3[1], rgb3[2]);
            }
            label1.Text = "Мой день";
            label1.ForeColor = Color.FromArgb(188, 122, 188);
            label2.Visible = true;
            pictureBox1.Image = Resources.MyDay_Ico1;
            button1.BackColor = Color.FromArgb(rgb4[0], rgb4[1], rgb4[2]);
            UpdateMyDayTask();
            UpdateMyDayTaskEnd();
        }

        private void button2_Click(object sender, EventArgs e) // категории важно хранит задачи которые важны
        {            
            Button clickbut = sender as Button;
            indexcattegory = CategoryTask.IndexOf(clickbut);
            for (int i = 0; i < CategoryTask.Count; i++)
            {
                CategoryTask[i].BackColor = Color.FromArgb(rgb3[0], rgb3[1], rgb3[2]);
            }
            label1.Text = "Важно";
            label1.ForeColor = Color.FromArgb(222,166,177);
            label2.Visible = false;
            pictureBox1.Image = Resources.ImportantTask_Ico;
            button2.BackColor = Color.FromArgb(rgb4[0], rgb4[1], rgb4[2]);
            EndTaskPanel.Visible = false;
            UpdateImportantTask();
        }

        private void button3_Click(object sender, EventArgs e) // категория задачи просто хранит какие то задачи
        {
            Button clickbut = sender as Button;
            indexcattegory = CategoryTask.IndexOf(clickbut);
            for (int i = 0; i < CategoryTask.Count; i++)
            {
                CategoryTask[i].BackColor = Color.FromArgb(rgb3[0], rgb3[1], rgb3[2]);
            }
            label1.Text = "Задачи";
            label1.ForeColor = Color.FromArgb(120,140,222);
            label2.Visible = false;
            pictureBox1.Image = Resources.Task_Ico;
            button3.BackColor = Color.FromArgb(rgb4[0], rgb4[1], rgb4[2]);
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
                    foreach (Button i in MyDayButtonImportantEnd)
                    {
                        i.Location = new Point(MyDayTask[MyDayTask.Count - 1].Width - 40, (MyDayTask[MyDayTask.Count - 1].Height / 2) - 13);
                    }
                }
            }
            if(indexcattegory == 1)
            {
                Panel clickedPanel = sender as Panel;
                if (ImportantTask.Contains(clickedPanel))
                {
                    index = ImportantTask.IndexOf(clickedPanel);
                    ChangeBoxTask.Text = ImportantTaskLabel[index].Text;
                }
                //получаем индекс кликнутой панели задач
                foreach (Panel i in ImportantTask)
                {
                    i.Size = new Size(TaskPanel.Width - 40, 55);
                    i.Margin = new Padding(17, 0, 0, 5);
                }
                foreach (Button i in ImportantTaskButton)
                {
                    i.Location = new Point(ImportantTask[ImportantTask.Count - 1].Width - 40, (ImportantTask[ImportantTask.Count - 1].Height / 2) - 13);
                }
                textBox1.Size = new Size(AddPanel.Width - 18, AddPanel.Height - 18); // меняется размер текстбокса
                Circle_Panel_Important();
                Circle_Panel();
                Circle_TextBox(); // закругление текстбокса
            }
            if(indexcattegory == 2)
            {
                Panel clickedPanel = sender as Panel;
                if (MyTask.Contains(clickedPanel))
                {
                    index = MyTask.IndexOf(clickedPanel);
                    ChangeBoxTask.Text = MyTaskLabel[index].Text;
                }
                //получаем индекс кликнутой панели задач
                foreach (Panel i in MyTask)
                {
                    i.Size = new Size(TaskPanel.Width - 40, 55);
                    i.Margin = new Padding(17, 0, 0, 5);
                }
                foreach (Button i in MyTaskButtonImportant)
                {
                    i.Location = new Point(MyTask[MyTask.Count - 1].Width - 40, (MyTask[MyTask.Count - 1].Height / 2) - 13);
                }
                textBox1.Size = new Size(AddPanel.Width - 18, AddPanel.Height - 18); // меняется размер текстбокса
                if (MyTaskEndPanels.Count > 0)
                {
                    for (int i = 0; i < MyTaskEndPanels.Count; i++)
                    {
                        MyTaskEndPanels[i].Size = new Size(EndTaskPanel.Width - 40, EndTaskPanel.Height - 92);
                    }
                    foreach (Button i in MyTaskButtonImportantEnd)
                    {
                        i.Location = new Point(MyTaskEndPanels[MyTaskEndPanels.Count - 1].Width - 40, (MyTaskEndPanels[MyTaskEndPanels.Count - 1].Height / 2) - 13);
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
                panel.BackColor = Color.FromArgb(rgb[0] + 20, rgb[1] + 20, rgb[2] + 20);
            }
        }

        private void panel_MouseLeave(object sender, EventArgs e) // когда мышка выходит с задачи цвет меняется обратно
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                panel.BackColor = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SettingsPanel.Visible = false;
            ChangeBoxTask.Text = string.Empty;
            if (indexcattegory == 0)
            {
                BackSizeMyDay();
            }
            else if(indexcattegory == 1)
            {
                BackSizeImportantTask();
            }
            else if(indexcattegory == 2)
            {
                BackSizeMyTask();
            }
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

                        MyDayTask[MyDayTask.Count - 1].BackColor = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
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
                        MyDayTaskCheckEnd[MyDayTaskCheckEnd.Count - 1].Location = new Point(10, (MyDayTask[MyDayTask.Count - 1].Height / 2) - 8);

                        MyDayTaskLabel.Add(new Label());

                        MyDayTaskLabel[MyDayTaskLabel.Count - 1].ForeColor = Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                        MyDayTaskLabel[MyDayTaskLabel.Count - 1].Font = new Font("Times New Roman", 10, FontStyle.Regular);
                        MyDayTaskLabel[MyDayTaskLabel.Count - 1].Location = new Point(40, (MyDayTask[MyDayTask.Count - 1].Height / 2) - 13);
                        MyDayTaskLabel[MyDayTaskLabel.Count - 1].Text = textBox1.Text;
                        MyDayTask[MyDayTask.Count - 1].Controls.Add(MyDayTaskLabel[MyDayTaskLabel.Count - 1]);

                        MyDayEndDate.Add(new Label());

                        MyDayEndDate[MyDayEndDate.Count - 1].ForeColor = Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                        MyDayEndDate[MyDayEndDate.Count - 1].Font = new Font("Times New Roman", 8, FontStyle.Regular);
                        MyDayEndDate[MyDayEndDate.Count - 1].Location = new Point(40, MyDayTask[MyDayTask.Count - 1].Height - 20);
                        MyDayEndDate[MyDayEndDate.Count - 1].Text = DateTime.Now.Date.ToString();
                        MyDayTask[MyDayTask.Count - 1].Controls.Add(MyDayEndDate[MyDayEndDate.Count - 1]);

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
                        MyTaskEndDate.Add(MyDayEndDate[MyDayEndDate.Count - 1]);

                        controller.AddMyTask(textBox1.Text, false, false, DateTime.Now);
                        controller.AddMyDayTask(textBox1.Text, false, false, DateTime.Now);

                        Circle_Panel();
                        textBox1.Clear();
                    }
                    else if(indexcattegory == 1)
                    {
                        ImportantTask.Add(new Panel());

                        ImportantTask[ImportantTask.Count - 1].BackColor = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
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
                        ImportantTaskCheckEnd[ImportantTaskCheckEnd.Count - 1].Location = new Point(10, (ImportantTask[ImportantTask.Count - 1].Height / 2) - 8);

                        ImportantTaskLabel.Add(new Label());

                        ImportantTaskLabel[ImportantTaskLabel.Count - 1].ForeColor = Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                        ImportantTaskLabel[ImportantTaskLabel.Count - 1].Font = new Font("Times New Roman", 10, FontStyle.Regular);
                        ImportantTaskLabel[ImportantTaskLabel.Count - 1].Location = new Point(40, (ImportantTask[ImportantTask.Count - 1].Height / 2) - 13);
                        ImportantTaskLabel[ImportantTaskLabel.Count - 1].Text = textBox1.Text;
                        ImportantTask[ImportantTask.Count - 1].Controls.Add(ImportantTaskLabel[ImportantTaskLabel.Count - 1]);

                        ImportantDateEnd.Add(new Label());

                        ImportantDateEnd[ImportantDateEnd.Count - 1].ForeColor = Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                        ImportantDateEnd[ImportantDateEnd.Count - 1].Font = new Font("Times New Roman", 8, FontStyle.Regular);
                        ImportantDateEnd[ImportantDateEnd.Count - 1].Location = new Point(40, ImportantTask[ImportantTask.Count - 1].Height - 20);
                        ImportantDateEnd[ImportantDateEnd.Count - 1].Visible = false;
                        ImportantTask[ImportantTask.Count - 1].Controls.Add(ImportantDateEnd[ImportantDateEnd.Count - 1]);

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
                        MyTaskEndDate.Add(ImportantDateEnd[ImportantDateEnd.Count - 1]);
                        MyTaskButtonImportant.Add(ImportantTaskButton[ImportantTaskButton.Count - 1]);
                        controller.AddImportantTask(textBox1.Text, false, true, DateTime.Now);
                        controller.AddMyTask(textBox1.Text, false, true, DateTime.Now);

                        Circle_Panel_Important();
                        textBox1.Clear();
                    }
                    else if (indexcattegory == 2)
                    {
                        MyTask.Add(new Panel());

                        MyTask[MyTask.Count - 1].BackColor = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
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
                        MyTaskCheckEnd[MyTaskCheckEnd.Count - 1].Location = new Point(10, (MyTask[MyTask.Count - 1].Height / 2) - 8);

                        MyTaskLabel.Add(new Label());

                        MyTaskLabel[MyTaskLabel.Count - 1].ForeColor = Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                        MyTaskLabel[MyTaskLabel.Count - 1].Font = new Font("Times New Roman", 10, FontStyle.Regular);
                        MyTaskLabel[MyTaskLabel.Count - 1].Location = new Point(40, (MyTask[MyTask.Count - 1].Height / 2) - 13);
                        MyTaskLabel[MyTaskLabel.Count - 1].Text = textBox1.Text;
                        MyTask[MyTask.Count - 1].Controls.Add(MyTaskLabel[MyTaskLabel.Count - 1]);

                        MyTaskEndDate.Add(new Label());

                        MyTaskEndDate[MyTaskEndDate.Count - 1].ForeColor= Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                        MyTaskEndDate[MyTaskEndDate.Count - 1].Font = new Font("Times New Roman", 8, FontStyle.Regular);
                        MyTaskEndDate[MyTaskEndDate.Count - 1].Location = new Point(40, MyTask[MyTask.Count - 1].Height - 20);
                        MyTaskEndDate[MyTaskEndDate.Count - 1].Visible = false;
                        MyTask[MyTask.Count - 1].Controls.Add(MyTaskEndDate[MyTaskEndDate.Count - 1]);

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

                        controller.AddMyTask(textBox1.Text, false, false, DateTime.Now);

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
                        controller.mytask[indexend].Complete = true;

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
                        controller.mytask[indexback].Complete = false;
                        MyTaskLabel[MyTaskLabel.Count - 1].Font = new Font("Times New Roman", 10, FontStyle.Regular);

                        UpdateMyTask();
                        UpdateMyTaskEnd();
                    }
                }
            }
        }

        private void ChangeBoxTask_TextChanged(object sender, EventArgs e)
        {
            if (SettingsPanel.Visible == true)
            {
                if(indexcattegory == 0)
                {
                    MyDayTaskLabel[index].Text = ChangeBoxTask.Text;
                }
                else if(indexcattegory == 1)
                {
                    ImportantTaskLabel[index].Text = ChangeBoxTask.Text;
                }
                else if(indexcattegory == 2)
                {
                    MyTaskLabel[index].Text = ChangeBoxTask.Text;
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if(indexcattegory == 0)
            {
                for (int i = 0; i < MyTask.Count; i++)
                {
                    if (MyTask[i] == MyDayTask[index])
                    {
                        MyTask.RemoveAt(i);
                        MyTaskButtonImportant.RemoveAt(i);
                        MyTaskCheckEnd.RemoveAt(i);
                        MyTaskLabel.RemoveAt(i);
                        importantornotMyTask.RemoveAt(i);
                        controller.mytask.RemoveAt(i);
                        break;
                    }
                }
                for (int i = 0; i < ImportantTask.Count; i++)
                {
                    if (ImportantTask[i] == MyDayTask[index])
                    {
                        ImportantTask.RemoveAt(i);
                        ImportantTaskCheckEnd.RemoveAt(i);
                        ImportantTaskButton.RemoveAt(i);
                        ImportantTaskLabel.RemoveAt(i);
                        break;
                    }
                }
                MyDayTask.RemoveAt(index);
                MyDayTaskCheckEnd.RemoveAt(index);
                MyDayTaskLabel.RemoveAt(index);
                MyDayButtonImportant.RemoveAt(index);
                importantornotMyDay.RemoveAt(index);
                BackSizeMyDay();
            }
            else if(indexcattegory == 1)
            {
                for (int i = 0; i < MyTask.Count; i++)
                {
                    if (MyTask[i] == ImportantTask[index])
                    {
                        MyTask.RemoveAt(i);
                        MyTaskButtonImportant.RemoveAt(i);
                        MyTaskCheckEnd.RemoveAt(i);
                        MyTaskLabel.RemoveAt(i);
                        controller.mytask.RemoveAt(i);
                        importantornotMyTask.RemoveAt(i);
                        break;
                    }
                }
                for(int i = 0; i < MyDayTask.Count; i++)
                {
                    if (MyDayTask[i] == ImportantTask[index])
                    {
                        MyDayTask.RemoveAt(i);
                        MyDayButtonImportant.RemoveAt(i);
                        MyDayTaskCheckEnd.RemoveAt(i);
                        MyDayTaskLabel.RemoveAt(i);
                        importantornotMyDay.RemoveAt(i);
                        break;
                    }
                }
                ImportantTask.RemoveAt(index);
                ImportantTaskCheckEnd.RemoveAt(index);
                ImportantTaskButton.RemoveAt(index);
                ImportantTaskLabel.RemoveAt(index);
                BackSizeImportantTask();
            }
            else if(indexcattegory == 2)
            {
                for (int i = 0; i < MyDayTask.Count; i++)
                {
                    if (MyDayTask[i] == MyTask[index])
                    {
                        MyDayTask.RemoveAt(i);
                        MyDayButtonImportant.RemoveAt(i);
                        MyDayTaskCheckEnd.RemoveAt(i);
                        MyDayTaskLabel.RemoveAt(i);
                        importantornotMyDay.RemoveAt(i);
                        break;
                    }
                }
                for (int i = 0; i < ImportantTask.Count; i++)
                {
                    if (ImportantTask[i] == MyTask[index])
                    {
                        ImportantTask.RemoveAt(i);
                        ImportantTaskCheckEnd.RemoveAt(i);
                        ImportantTaskButton.RemoveAt(i);
                        ImportantTaskLabel.RemoveAt(i);
                        break;
                    }
                }
                MyTask.RemoveAt(index);
                MyTaskCheckEnd.RemoveAt(index);
                MyTaskLabel.RemoveAt(index);
                MyTaskButtonImportant.RemoveAt(index);
                importantornotMyTask.RemoveAt(index);
                controller.mytask.RemoveAt(index);
                BackSizeMyTask();
            }
        }

        private void SetDataButton_Click(object sender, EventArgs e)
        {
            PanelData.Visible = true;
        }

        private void SaveButData_Click(object sender, EventArgs e)
        {
            if (indexcattegory == 0)
            {
                if(monthCalendar1.SelectionStart < DateTime.Now.Date)
                {
                    MessageBox.Show("Ошибка!", "To Do");
                }
                else
                {
                    DateTime selectedDate = monthCalendar1.SelectionStart;
                    MyDayEndDate[index].Visible = true;
                    MyDayEndDate[index].Text = selectedDate.ToString();
                    PanelData.Visible = false;
                }
            }
            else if(indexcattegory == 1)
            {
                if (monthCalendar1.SelectionStart < DateTime.Now.Date)
                {
                    MessageBox.Show("Ошибка!", "To Do");
                }
                else
                {
                    DateTime selectedDate = monthCalendar1.SelectionStart;
                    ImportantDateEnd[index].Visible = true;
                    ImportantDateEnd[index].Text = selectedDate.ToString();
                    PanelData.Visible = false;
                }
            }
            else if (indexcattegory == 2)
            {
                if (monthCalendar1.SelectionStart < DateTime.Now.Date)
                {
                    MessageBox.Show("Ошибка!", "To Do");
                }
                else
                {
                    DateTime selectedDate = monthCalendar1.SelectionStart;
                    MyTaskEndDate[index].Visible = true;
                    MyTaskEndDate[index].Text = selectedDate.ToString();
                    PanelData.Visible = false;
                }
            }
        }

        private void CancelButData_Click(object sender, EventArgs e)
        {
            if(indexcattegory == 0)
            {
                PanelData.Visible = false;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(indexcattegory == 0)
                {
                    string nametask = TextBoxSearch.Text;
                    if (string.IsNullOrEmpty(nametask))
                    {
                        UpdateMyTask();
                        UpdateMyTaskEnd();
                    }
                    else
                    {
                        TaskPanel.Controls.Clear();
                        EndTaskPanel.Controls.Clear();
                        for (int i = 0; i < MyDayTask.Count; i++)
                        {
                            if (MyDayTaskLabel[i].Text.Contains(nametask))
                            {
                                TaskPanel.Controls.Add(MyDayTask[i]);
                            }
                        }
                        for (int i = 0; i < MyDayEndTaskPanels.Count; i++)
                        {
                            if (MyDayTaskLabelEnd[i].Text.Contains(nametask))
                            {
                                TaskPanel.Controls.Add(MyDayEndTaskPanels[i]);
                            }
                        }
                    }
                }
                if(indexcattegory == 1)
                {
                    string nametask = TextBoxSearch.Text;
                    if (string.IsNullOrEmpty(nametask))
                    {
                        UpdateMyTask();
                        UpdateMyTaskEnd();
                    }
                    else
                    {
                        TaskPanel.Controls.Clear();
                        EndTaskPanel.Controls.Clear();
                        for (int i = 0; i < ImportantTask.Count; i++)
                        {
                            if (ImportantTaskLabel[i].Text.Contains(nametask))
                            {
                                TaskPanel.Controls.Add(ImportantTask[i]);
                            }
                        }
                    }
                }
                if(indexcattegory == 2)
                {
                    string nametask = TextBoxSearch.Text;
                    if (string.IsNullOrEmpty(nametask))
                    {
                        UpdateMyTask();
                        UpdateMyTaskEnd();
                    }
                    else
                    {
                        TaskPanel.Controls.Clear();
                        EndTaskPanel.Controls.Clear();
                        for (int i = 0; i < MyTask.Count; i++)
                        {
                            if (MyTaskLabel[i].Text.Contains(nametask))
                            {
                                TaskPanel.Controls.Add(MyTask[i]);
                            }
                        }
                        for (int i = 0; i < MyTaskEndPanels.Count; i++)
                        {
                            if (MyTaskLabelEnd[i].Text.Contains(nametask))
                            {
                                EndTaskPanel.Controls.Add(MyTaskEndPanels[i]);
                            }
                        }
                    }
                }
                TextBoxSearch.Clear();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipTitle = "To Do";
            notifyIcon1.BalloonTipText = "Приложение свернуто";
            notifyIcon1.Text = "To Do";
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
            }
            else if(FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible=false;
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(theam == 0)
            {
                button5.BackgroundImage = Image.FromFile("Light_Theam_Ico.png");
                rgb = new int[3]{ 235, 235, 235 };
                rgb2 = new int[3] { 110, 110, 110 };
                TaskPanel.BackColor = Color.FromArgb(179, 179, 179);
                EndTaskPanel.BackColor = Color.FromArgb(179, 179, 179);
                AddPanel.BackColor = Color.FromArgb(179, 179, 179);
                textBox1.BackColor = Color.FromArgb(235, 235, 235);
                textBox1.ForeColor = Color.FromArgb(110, 110, 110);
                InformationPanel.BackColor = Color.FromArgb(179, 179, 179);
                ElementPanel.BackColor = Color.FromArgb(199, 199, 199);
                panel5.BackColor = Color.FromArgb(199, 199, 199);
                SettingsPanel.BackColor = Color.FromArgb(199, 199, 199);
                label3.ForeColor = Color.FromArgb(110, 110, 110);
                TextBoxSearch.BackColor = Color.FromArgb(179, 179, 179);
                TextBoxSearch.ForeColor = Color.FromArgb(110, 110, 110);
                foreach(Button i in CategoryTask)
                {
                    i.BackColor = Color.FromArgb(199, 199, 199);
                    i.ForeColor = Color.FromArgb(110, 110, 110);
                }
                rgb3 = new int[3] { 199, 199, 199 };
                rgb4 = new int[3] { 159, 159, 159 };
                ChangeBoxTask.BackColor = Color.FromArgb(179, 179, 179);
                ChangeBoxTask.ForeColor = Color.FromArgb(110, 110, 110);
                SetDataButton.BackColor = Color.FromArgb(179, 179, 179);
                SetDataButton.ForeColor = Color.FromArgb(110,110,110);
                Delete.BackColor = Color.FromArgb(179, 179, 179);
                Delete.ForeColor= Color.FromArgb(110, 110, 110);
                panel1.BackColor = Color.FromArgb(179, 179, 179);
                for (int i = 0; i < MyDayTask.Count; i++)
                {
                    MyDayTask[i].BackColor = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
                    MyDayEndDate[i].ForeColor = Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                    MyDayTaskLabel[i].ForeColor = Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                }
                for (int i = 0; i < MyTask.Count; i++)
                {
                    MyTask[i].BackColor = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
                    MyTaskEndDate[i].ForeColor = Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                    MyTaskLabel[i].ForeColor = Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                }
                for (int i = 0; i < ImportantTask.Count; i++)
                {
                    ImportantTask[i].BackColor = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
                    ImportantDateEnd[i].ForeColor = Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                    ImportantTaskLabel[i].ForeColor = Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                }
                for (int i = 0; i < MyDayEndTaskPanels.Count; i++)
                {
                    MyDayEndTaskPanels[i].BackColor = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
                    MyDayEndDate[i].ForeColor = Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                    MyDayTaskLabelEnd[i].ForeColor = Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                }
                for (int i = 0; i < MyTaskEndPanels.Count; i++)
                {
                    MyTaskEndPanels[i].BackColor = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
                    MyTaskEndDate[i].ForeColor = Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                    MyTaskLabelEnd[i].ForeColor = Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                }
                theam = 1;
            }
            else if(theam == 1)
            {
                button5.BackgroundImage = Image.FromFile("Dark_Theam_Ico.png");
                rgb = new int[3] { 64, 64, 64 };
                rgb2 = new int[3] { 223, 223, 223 };
                TaskPanel.BackColor = Color.FromArgb(33, 33, 33);
                EndTaskPanel.BackColor = Color.FromArgb(33, 33, 33);
                AddPanel.BackColor = Color.FromArgb(33, 33, 33);
                textBox1.BackColor = Color.FromArgb(44, 44, 44);
                textBox1.ForeColor = Color.FromArgb(223, 223, 223);
                InformationPanel.BackColor = Color.FromArgb(33, 33, 33);
                ElementPanel.BackColor = Color.FromArgb(64, 64, 64);
                panel5.BackColor = Color.FromArgb(64, 64, 64);
                SettingsPanel.BackColor = Color.FromArgb(64, 64, 64);
                label3.ForeColor = Color.FromArgb(223, 223, 223);
                TextBoxSearch.BackColor = Color.FromArgb(44, 44, 44);
                TextBoxSearch.ForeColor = Color.FromArgb(223, 223, 223);
                foreach (Button i in CategoryTask)
                {
                    i.BackColor = Color.FromArgb(64, 64, 64);
                    i.ForeColor = Color.FromArgb(223, 223, 223);
                }
                rgb3 = new int[3] { 64, 64, 64 };
                rgb4 = new int[3] { 94,94, 94 };
                ChangeBoxTask.BackColor = Color.FromArgb(84,84, 84);
                ChangeBoxTask.ForeColor = Color.FromArgb(223, 223, 223);
                SetDataButton.BackColor = Color.FromArgb(84, 84, 84);
                SetDataButton.ForeColor = Color.FromArgb(223, 223, 223);
                Delete.BackColor = Color.FromArgb(84, 84, 84);
                Delete.ForeColor = Color.FromArgb(223, 223, 223);
                panel1.BackColor = Color.FromArgb(84, 84, 84);
                for(int i = 0; i < MyDayTask.Count; i++)
                {
                    MyDayTask[i].BackColor = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
                    MyDayEndDate[i].ForeColor = Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                    MyDayTaskLabel[i].ForeColor = Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                }
                for (int i = 0; i < MyTask.Count; i++)
                {
                    MyTask[i].BackColor = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
                    MyTaskEndDate[i].ForeColor = Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                    MyTaskLabel[i].ForeColor = Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                }
                for (int i = 0; i < ImportantTask.Count; i++)
                {
                    ImportantTask[i].BackColor = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
                    ImportantDateEnd[i].ForeColor = Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                    ImportantTaskLabel[i].ForeColor = Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                }
                for (int i = 0; i < MyDayEndTaskPanels.Count; i++)
                {
                    MyDayEndTaskPanels[i].BackColor = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
                    MyDayEndDate[i].ForeColor = Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                    MyDayTaskLabelEnd[i].ForeColor = Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                }
                for (int i = 0; i < MyTaskEndPanels.Count; i++)
                {
                    MyTaskEndPanels[i].BackColor = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
                    MyTaskEndDate[i].ForeColor = Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                    MyTaskLabelEnd[i].ForeColor = Color.FromArgb(rgb2[0], rgb2[1], rgb2[2]);
                }
                theam = 0;
            }
        }
    }
}
