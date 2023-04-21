using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Volkov_HW_WinForms_15
{
    public partial class Form1 : Form
    {
        List<Firm> firm;
        List<Student> students;
        List<Library> library;
        List<Product> product;
        SynchronizationContext uiContext;

        public Form1()
        {
            InitializeComponent();
            uiContext = SynchronizationContext.Current;
            firm = new List<Firm>()
            {
                new Firm("Андрей Николаевич Сидоров", "11.04.1964", "+380987654322", "ул.Гоголя", 5, 12),
                new Firm("Владислав Сергеевич Петров", "20.10.1972", "+380936547247", "ул. Шевченка", 2, 25),
                new Firm("Юрий Петрович Иванов", "05.05.1999", "+380936547247", "ул. Академия Королева", 2, 25)
            };

            students = new List<Student>()
            {
                new Student("Дмитрий Сергеевич Григорьев", 4313, 9, 8, 11, "31.01.2023"),
                new Student("Александр Игоревич Мельников", 4311, 10, 10, 12, "31.01.2023"),
                new Student("Наталья Андреевна Кравченко", 4314, 7, 7, 9, "31.01.2023")
            };

            library = new List<Library>()
            {
                new Library(10, "Stephen Hawking", "A Brief History of Time", "Bantam Books", 1988, "21.01.2023", "21.02.2023"),
                new Library(11, "Артур Конан Дойл", "Шерлок Холмс", "AST", 2017, "05.02.2023", "05.03.2023")
            };

            product = new List<Product>()
            {
                new Product("Мясо", "Курица", "Наша ряба", new DateTime(2023 , 7, 23)),
                new Product("Молочная продукция", "Молоко", "Яготинська", new DateTime(2023 , 5, 23)),
                new Product("Молочная продукция", "Йогурт", "Яготинська", new DateTime(2023 , 6, 23)),
                new Product("Мясо", "Куриные ножки", "Наша ряба", new DateTime(2023 , 8, 23))
            };
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {
                    uiContext.Send(d => listBox1.Items.Clear(), null);
                    foreach(var i in firm)
                    {
                        uiContext.Send(d => listBox1.Items.Add(i), null);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });

            await Task.Run(() =>
            {
                try
                {
                    int[] age = new int[firm.Count];
                    for(int i = 0; i < age.Length; i++)
                    {
                        DateTime dob = DateTime.ParseExact(firm[i].datebirthday, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                        age[i] = DateTime.Now.Year - dob.Year;
                    }
                    double averageage = 0;
                    foreach(var i in age)
                    {
                        averageage += i / age.Length;
                    }
                    uiContext.Send(d => listBox1.Items.Add("Средний возраст сотрудников -> " + averageage), null);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);    
                }
            });
            await Task.Run(() =>
            {
                try
                {
                    int evenhouse = 0;
                    foreach (var i in firm)
                    {
                        if(i.numberhome % 2 == 0)
                        {
                            evenhouse++;
                        }
                    }
                    uiContext.Send(d => listBox1.Items.Add("Количество людей живущих в четных дома -> " + evenhouse), null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {
                    uiContext.Send(d => listBox1.Items.Clear(), null);
                    foreach (var i in firm)
                    {
                        uiContext.Send(d => listBox1.Items.Add(i), null);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
            await Task.Run(() =>
            {
                int[] year = new int[firm.Count];
                for(int i = 0; i < year.Length; i++)
                {
                    DateTime dob = DateTime.ParseExact(firm[i].datebirthday, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    year[i] = dob.Year;
                }
                int yearofthebullcount = 0;
                for(int i = 0; i < year.Length; i++)
                {
                    int yearofthebull = (year[i] - 4) % 12;
                    if (yearofthebull < 0)
                        yearofthebull += 12;
                    if (yearofthebull == 1)
                    {
                        Console.WriteLine("Рожден в год быка");
                        yearofthebullcount++;
                    }
                }
                uiContext.Send(d => listBox1.Items.Add("Количество людей родившиеся в год быка -> " + yearofthebullcount), null);
            });
            await Task.Run(() =>
            {
                int[] month = new int[firm.Count];
                for (int i = 0; i < month.Length; i++)
                {
                    DateTime dob = DateTime.ParseExact(firm[i].datebirthday, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    month[i] = dob.Month;
                }
                string[] timeoftheyear = new string[firm.Count];
                for (int i = 0; i < month.Length; i++)
                {
                    if (month[i] == 12 || month[i] >= 1  && month[i] <= 2)
                    {
                        timeoftheyear[i] = "Зима";
                    }
                    else if (month[i] >= 3 && month[i] <= 5)
                    {
                        timeoftheyear[i] = "Весная";
                    }
                    else if (month[i] >= 6 && month[i] <= 8)
                    {
                        timeoftheyear[i] = "Лето";
                    }
                    else if (month[i] >= 9 && month[i] <= 11)
                    {
                        timeoftheyear[i] = "Осень";
                    }
                }
                for(int i = 0; i < firm.Count; i++)
                {
                    uiContext.Send(d => listBox1.Items.Add(firm[i].fullname + " - " + timeoftheyear[i]), null);
                }
            });
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {
                    uiContext.Send(d => listBox1.Items.Clear(), null);
                    foreach (var i in students)
                    {
                        uiContext.Send(d => listBox1.Items.Add(i), null);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });

            await Task.Run(() =>
            {
                try
                {
                    uiContext.Send(d => listBox1.Items.Add("------------------------------------------------"), null);
                    int[] averagegrade = new int[students.Count];
                    for(int i = 0; i < averagegrade.Length;i++)
                    {
                        int average = (students[i].gradeinformatics + students[i].grademath + students[i].gradephysic) / 3;
                        averagegrade[i] = average;
                    }

                    for (int i = 0; i < students.Count; i++)
                    {
                        students[i].Averagegrade = averagegrade[i];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });

            await Task.Run(() =>
            {
                try
                {
                    students = students.OrderBy(i => i.Averagegrade).Reverse().ToList();
                    foreach(var i in students)
                    {
                        uiContext.Send(d => listBox1.Items.Add(i.fullname + " " + i.Averagegrade), null);
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {
                    uiContext.Send(d => listBox1.Items.Clear(), null);
                    foreach (var i in library)
                    {
                        uiContext.Send(d => listBox1.Items.Add(i), null);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });

            await Task.Run(() =>
            {
                try
                {
                    uiContext.Send(d => listBox1.Items.Add("-----------------------------------------------------"), null);
                    int[] delay = new int[library.Count];
                    for (int i = 0; i < delay.Length; i++)
                    {
                        DateTime date = DateTime.ParseExact(library[i].datereturnbook, "dd/MM/yyyy", null);
                        DateTime now = DateTime.Today;
                        delay[i] = (now - date).Days;
                    }
                    for(int i = 0; i < library.Count; i++)
                    {
                        uiContext.Send(d => listBox1.Items.Add(library[i].ticket + " " + library[i].namebook + " " +delay[i]), null);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {
                    uiContext.Send(d => listBox1.Items.Clear(), null);
                    foreach (var i in product)
                    {
                        uiContext.Send(d => listBox1.Items.Add(i), null);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });

            await Task.Run(() =>
            {
                try
                {
                    product = product.OrderBy(i => i.date).ToList();
                    foreach (var i in product)
                    {
                        uiContext.Send(d => listBox1.Items.Add(i.groupproduct), null);
                        foreach(var j in product)
                        {
                            if(i.groupproduct == j.groupproduct)
                            {
                                uiContext.Send(d => listBox1.Items.Add(i), null);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }
    }
}
