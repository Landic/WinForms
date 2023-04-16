using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Volkov_HW_WinForms_8
{
    public partial class Form1 : Form
    {
        Dictionary<int, int> map;
        List<Tuple<string, string[]>> list;
        Button[] arr;
        int index;
        int pause, clue1, clue2, clue3;
        List<string> answer;
        Form2 form;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Кто хочет стать миллионером?";
            list = new List<Tuple<string, string[]>>()
            {
                new Tuple<string, string[]>("Как называется место на берегу, где обитают тюлени?", new string[]{ "Лежбище", "Стойбище", "Пастбище", "Гульбище" }),
                new Tuple<string, string[]>("Как мировая пресса называла премьер-министра Великобритании Маргарет Тэтчер?", new string[]{ "Железная леди", "Стальная леди","Оловянный солдатик","Крепкий орешек" }),
                new Tuple<string, string[]>("Какой из этих городов южнее остальных?", new string[]{"Каир", "Токио", "Мадрид","Сан-Франциско" }),
                new Tuple<string, string[]>("Через какой город мира проходит нулевой меридиан?", new string[]{"Гринсборо", "Гринвич", "Глазго","Гронинген" }),
                new Tuple<string, string[]>("Какая птица является символом Новой Зеландии?", new string[]{"Эму", "Жако", "Киви","Казуар" }),
                new Tuple<string, string[]>("Какого короля англичане прозвали \"Львиное сердце\"?", new string[]{ "Георг I", "Вильгельм I", "Ричард I", "Генрих I" }),
                new Tuple<string, string[]>("Как в народе называются финансовые институты, обещающие вкладчикам золотые горы?", new string[]{ "Пирамиды", "Гробницы", "Захоронения", "Сфинксы" }),
                new Tuple<string, string[]>("Какая награда вручается вместе с присвоением звания Героя Украины?", new string[]{ "Орден \"За мужество\"", "Орден \"Богдана Хмельницкого\"", "Орден \"Героев Небесной Сотни\"", "Орден \"Золотая Звезда\"" }),
                new Tuple<string, string[]>("В каком городе родился Вольфганг Амадей Моцарт?", new string[]{ "Веймар", "Зальцбург", "Прага", "Вена" }),
                new Tuple<string, string[]>("Какую реку Юлий Цезарь перешел со словами \"Жребий брошен\"?", new string[]{ "Нил", "Припять", "Рубикон", "Евфрат" }),
                new Tuple<string, string[]>("Как называется искусство аранжировки цветов?", new string[]{ "Икебана", "Суши", "Кэндо", "Харакири" }),
                new Tuple<string, string[]>("Какая страна является мировым лидером по производству кофе?", new string[]{ "Аргентина", "Венесуэла", "Мексика", "Бразилия" }),
                new Tuple<string, string[]>("Что труднее всего дается не трезвому человеку?", new string[]{ "Витать в облаках", "Трепать нервы", "Бить баклуши", "Вязать лыко" }),
                new Tuple<string, string[]>("Как называют японских мафиози?", new string[]{ "Джакузи", "Якудза", "Камикадзе", "Коза Ностра" }),
                new Tuple<string, string[]>("Какой цвет получается при смешении синего и красного?", new string[]{ "Коричневый", "Фиолетовый", "Зеленый", "Голубой" })
            };

            answer = new List<string>() { "Лежбище", "Железная леди",  "Каир", "Гринвич", "Киви", "Ричард I", "Пирамиды", "Орден \"Золотая Звезда\"", "Зальцбург", "Рубикон", "Икебана", "Бразилия", "Вязать лыко", "Якудза", "Фиолетовый" };

            arr = new Button[] { Answer1, Answer2, Answer3, Answer4 };
            index = 0;

            pause = 0;
            clue1 = 0;
            clue2 = 0;
            clue3 = 0;

            map = new Dictionary<int, int>()
            {
                {1, 100},
                {2, 200 },
                {3, 300 },
                {4, 500 },
                {5, 1000 },
                {6, 2000 },
                {7, 4000 },
                {8, 8000 },
                {9, 16000 },
                {10, 32000 },
                {11, 64000 },
                {12, 125000 },
                {13, 250000 },
                {14, 500000 },
                {15, 1000000 }
            };
            foreach(KeyValuePair<int, int> i in map)
            {
                    listBox1.Items.Add(i.Key + " -     " + i.Value);
            }
            listBox1.Enabled = true;
            //listBox1.SelectionMode = SelectionMode.None;
            listBox1.DrawMode = DrawMode.OwnerDrawFixed;
            Answer1.Visible = false;
            Answer2.Visible = false;
            Answer3.Visible = false;
            Answer4.Visible = false;
            Question.Visible = false;
            
            
        }

        private void ProgrammToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Кто хочет стать миллионером? — телеигра, аналог оригинальной английской телевикторины «Who Wants to Be a Millionaire?», воспроизведённый по одноимённому франчайзингу компании «Sony Pictures Entertainment». В телеигре каждый участник может выиграть 1 миллиона гривен, ответив на 15 вопросов из различных областей знаний.", "Кто хочет стать миллионером?");
        }

        private void GameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Answer1.Visible = true;
            Answer2.Visible = true;
            Answer3.Visible = true;
            Answer4.Visible = true;
            Question.Visible = true;
            index = 0;
            clue2 = 0;
            clue1 = 0;
            clue3 = 0;
            Clue1.Image = Properties.Resources._1;
            Clue2.Image = Properties.Resources._2;
            Clue3.Image = Properties.Resources._3;
            Question.Text = list[index].Item1;
            SoundPlayer player = new SoundPlayer("begin.wav");
            player.Play();
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i].Text = list[index].Item2[i];
            }
            listBox1.SelectedIndex = index;
        }

        private void Answer1_Click(object sender, EventArgs e)
        {
            foreach(var i in answer)
            {
                if(Answer1.Text == i.ToString())
                {
                    index++;
                    Answer1.BackColor = Color.Green;
                    SoundPlayer player = new SoundPlayer("true.wav");
                    player.Play();
                    Thread.Sleep(1000);
                    Answer1.BackColor = Color.Black;
                    PhonedFriend.Visible = false;
                    textBox1.Visible = false;
                    if (CheckWin() == false)
                    {
                        Question.Text = list[index].Item1;
                        for (int j = 0; j < arr.Length; j++)
                        {
                            arr[j].Text = list[index].Item2[j];
                        }
                        for (int j = 0; j < arr.Length; j++)
                        {
                            arr[j].Visible = true;
                        }
                        listBox1.SelectedIndex = index;
                    }
                    return;
                }
            }
            
            if (index >= 5 && index <= 9)
            {
                SoundPlayer player3 = new SoundPlayer("summa.wav");
                player3.Play();
                MessageBox.Show("Вы проиграли но уходите с 1000 гривен", "Кто хочет стать миллионером?");
            }
            else if (index >= 10 && index <= 14)
            {
                SoundPlayer player3 = new SoundPlayer("summa.wav");
                player3.Play();
                MessageBox.Show("Вы проиграли но уходите с 100000 гривен", "Кто хочет стать миллионером?");
            }
            else
            {
                SoundPlayer player2 = new SoundPlayer("false.wav");
                player2.Play();
                MessageBox.Show("Вы проиграли(", "Кто хочет стать миллионером?");
            }
            Question.Visible = false;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].Visible = false;
            }
            PhonedFriend.Visible = false;
            textBox1.Visible = false;
        }

        private void Answer2_Click(object sender, EventArgs e)
        {
            foreach (var i in answer)
            {
                if (Answer2.Text == i.ToString())
                {
                    index++;
                    Answer2.BackColor = Color.Green;
                    SoundPlayer player = new SoundPlayer("true.wav");
                    player.Play();
                    Thread.Sleep(1000);
                    Answer2.BackColor = Color.Black;
                    PhonedFriend.Visible = false;
                    textBox1.Visible = false;
                    if (CheckWin() == false)
                    {
                        Question.Text = list[index].Item1;
                        for (int j = 0; j < arr.Length; j++)
                        {
                            arr[j].Text = list[index].Item2[j];
                        }
                        for (int j = 0; j < arr.Length; j++)
                        {
                            arr[j].Visible = true;
                        }
                        listBox1.SelectedIndex = index;
                    }

                    return;
                }
            }
            
            if (index >= 5 && index <= 9)
            {
                SoundPlayer player3 = new SoundPlayer("summa.wav");
                player3.Play();
                MessageBox.Show("Вы проиграли но уходите с 1000 гривен", "Кто хочет стать миллионером?");
            }
            else if (index >= 10 && index <= 14)
            {
                SoundPlayer player3 = new SoundPlayer("summa.wav");
                player3.Play();
                MessageBox.Show("Вы проиграли но уходите с 100000 гривен", "Кто хочет стать миллионером?");
            }
            else
            {
                SoundPlayer player2 = new SoundPlayer("false.wav");
                player2.Play();
                MessageBox.Show("Вы проиграли(", "Кто хочет стать миллионером?");
            }
            Question.Visible = false;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].Visible = false;
            }
            PhonedFriend.Visible = false;
            textBox1.Visible = false;
        }

        private void Answer3_Click(object sender, EventArgs e)
        {
            foreach (var i in answer)
            {
                if (Answer3.Text == i.ToString())
                {
                    index++;
                    Answer3.BackColor = Color.Green;
                    SoundPlayer player = new SoundPlayer("true.wav");
                    player.Play();
                    Thread.Sleep(1000);
                    Answer3.BackColor = Color.Black;
                    PhonedFriend.Visible = false;
                    textBox1.Visible = false;
                    if (CheckWin() == false)
                    {
                        Question.Text = list[index].Item1;
                        for (int j = 0; j < arr.Length; j++)
                        {
                            arr[j].Text = list[index].Item2[j];
                        }
                        for (int j = 0; j < arr.Length; j++)
                        {
                            arr[j].Visible = true;
                        }
                        listBox1.SelectedIndex = index;
                    }
                    return;
                }
            }

            if (index >= 5 && index <= 9)
            {
                SoundPlayer player3 = new SoundPlayer("summa.wav");
                player3.Play();
                MessageBox.Show("Вы проиграли но уходите с 1000 гривен", "Кто хочет стать миллионером?");
            }
            else if (index >= 10 && index <= 14)
            {
                SoundPlayer player3 = new SoundPlayer("summa.wav");
                player3.Play();
                MessageBox.Show("Вы проиграли но уходите с 100000 гривен", "Кто хочет стать миллионером?");
            }
            else
            {           
                SoundPlayer player2 = new SoundPlayer("false.wav");
                player2.Play();
                MessageBox.Show("Вы проиграли(", "Кто хочет стать миллионером?");
            }
            Question.Visible = false;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].Visible = false;
            }
            PhonedFriend.Visible = false;
            textBox1.Visible = false;
        }

        private void Answer4_Click(object sender, EventArgs e)
        {
            foreach (var i in answer)
            {
                if (Answer4.Text == i.ToString())
                {
                    index++;
                    Answer4.BackColor = Color.Green;
                    SoundPlayer player = new SoundPlayer("true.wav");
                    player.Play();
                    Thread.Sleep(1000);
                    Answer4.BackColor = Color.Black;
                    PhonedFriend.Visible = false;
                    textBox1.Visible = false;
                    if (CheckWin() == false)
                    {
                        Question.Text = list[index].Item1;
                        for (int j = 0; j < arr.Length; j++)
                        {
                            arr[j].Text = list[index].Item2[j];
                        }
                        for (int j = 0; j < arr.Length; j++)
                        {
                            arr[j].Visible = true;
                        }
                        listBox1.SelectedIndex = index;
                    }
                    return;
                }
            }
            if (index >= 5 && index <= 9)
            {
                SoundPlayer player3 = new SoundPlayer("summa.wav");
                player3.Play();
                MessageBox.Show("Вы проиграли но уходите с 1000 гривен", "Кто хочет стать миллионером?");
            }
            else if (index >= 10 && index <= 14)
            {
                SoundPlayer player3 = new SoundPlayer("summa.wav");
                player3.Play();
                MessageBox.Show("Вы проиграли но уходите с 100000 гривен", "Кто хочет стать миллионером?");
            }
            else
            {
                SoundPlayer player2 = new SoundPlayer("false.wav");
                player2.Play();
                MessageBox.Show("Вы проиграли(", "Кто хочет стать миллионером?");
            }
            Question.Visible = false;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].Visible = false;
            }
            PhonedFriend.Visible = false;
            textBox1.Visible = false;
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            if (pause == 0)
            {
                Question.Enabled = false;
                Question.BackColor = Color.Gray;
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i].Enabled = false;
                    arr[i].BackColor = Color.Gray;
                }
                Stop.Text = "Возобновить";
                pause++;
            }
            else
            {
                Question.Enabled = true;
                Question.BackColor = Color.Black;
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i].Enabled = true;
                    arr[i].BackColor = Color.Black;
                }
                Stop.Text = "Стоп";
                pause--;
            }
        }

        private void Clue1_Click(object sender, EventArgs e)
        {
            if (clue1 == 0)
            {
                SoundPlayer player = new SoundPlayer("gong.wav");
                player.Play();
                Clue1.Image = Properties.Resources._4;
                foreach (var i in answer)
                {
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (arr[j].Text == i)
                        {
                            Random rand = new Random();
                            int g = rand.Next(4);
                            int y = rand.Next(4);
                            if (g != j && y != j && y != g)
                            {
                                arr[g].Visible = false;
                                arr[y].Visible = false;
                            }
                            else
                            {
                                j--;
                            }
                        }
                    }
                }
                clue1++;
            }
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            if (isSelected)
            {
                e.Graphics.FillRectangle(Brushes.Orange, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.Black, e.Bounds);
            }
            e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, Brushes.Yellow, e.Bounds, StringFormat.GenericDefault);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(index > 5)
            {
                MessageBox.Show("Вы уходите с 1000 гривен", "Кто хочет стать миллионером?");
                Close();
            }
            else if (index > 10)
            {
                MessageBox.Show("Вы уходите с 100000 гривен", "Кто хочет стать миллионером?");
                Close();
            }
            Close();
        }

        private void AdministationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form = new Form2();
            form.ParentForm1 = this;
            form.list.AddRange(list);
            form.answer.AddRange(answer);
            DialogResult rez = form.ShowDialog();
            if(rez == DialogResult.OK)
            {
                if (list.Count > form.list.Count)
                {
                    map.Remove(map.Count);
                }
                else if(list.Count < form.list.Count)
                {
                    map.Add(list.Count, map[map.Count] * 2);
                }
                list.Clear();
                list = form.list;
                answer.Clear();
                answer.AddRange(form.answer);
                listBox1.Items.Clear();
                foreach (var i in map)
                {
                    listBox1.Items.Add(i.Key + " -     " + i.Value);
                }
                answer.Add(list[list.Count - 1].Item2[0]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Answer1.Visible = true;
            Answer2.Visible = true;
            Answer3.Visible = true;
            Answer4.Visible = true;
            Question.Visible = true;
            index = 0;
            clue2 = 0;
            clue1 = 0;
            clue3 = 0;
            Clue1.Image = Properties.Resources._1;
            Clue2.Image = Properties.Resources._2;
            Clue3.Image = Properties.Resources._3;
            Question.Text = list[index].Item1;
            SoundPlayer player = new SoundPlayer("begin.wav");
            player.Play();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].Text = list[index].Item2[i];
            }
            listBox1.SelectedIndex = index;
        }

        private void Clue2_Click(object sender, EventArgs e)
        {
            if(clue2 == 0)
            {
                SoundPlayer sound = new SoundPlayer("zvonok.wav");
                sound.Play();
                Clue2.Image = Properties.Resources._5;
                clue2++;
                Random rand = new Random();
                int r = rand.Next(4);
                textBox1.Text = "Я думаю это " + list[index].Item2[r];
                PhonedFriend.Visible = true;
                textBox1.Visible = true;
            } 
        }


        private void Clue3_Click(object sender, EventArgs e)
        {
            if(clue3 == 0)
            {
                SoundPlayer sound = new SoundPlayer("zal.wav");
                sound.Play();
                clue3++;
                Clue3.Image = Properties.Resources._6;
                groupBox3.Visible = true;
            }
        }

        private bool CheckWin()
        {
            if(index == list.Count)
            {
                SoundPlayer sound = new SoundPlayer("winner.wav");
                sound.Play();
                MessageBox.Show("Вы выиграли " + map[map.Count] +" гривен! Поздравляем!", "Кто хочет стать миллионером?");
                for(int i = 0; i < arr.Length; i++)
                {
                    arr[i].Visible = false;
                }
                Question.Visible = false;
                return true;
            }
            return false;
        }
    }
}