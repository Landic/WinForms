using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Linq.Expressions;

namespace Volkov_HW_WinForms_12
{
    public partial class Form1 : Form
    {
        Button buttonstartcreateelement, buttonsearch, buttonstop;
        Thread thread;
        ListView list;
        TextBox textBox1, textBox2;
        ComboBox comboBox1;
        CheckBox checkBox1;
        Label label1, label2, label3, label4;

        public Form1()
        {
            InitializeComponent();
            buttonstartcreateelement= new Button();
            buttonstartcreateelement.Location= new Point(360, 36);
            buttonstartcreateelement.Size = new Size(120, 25);
            buttonstartcreateelement.Text = "Добавить элементы";
            buttonstartcreateelement.Click += new EventHandler(buttonstartclick);
            Controls.Add(buttonstartcreateelement);
            thread = null;
        }

        private void CreateElement()
        {
            buttonstartcreateelement.Visible= false;
            Action Act1 = delegate
            {
                list = new ListView();
                list.Size = new Size(804, 350);
                list.Location = new Point(12, 88);
                list.Columns.Add("Имя");
                list.Columns.Add("Тип");
                list.Columns.Add("Размер");
                Controls.Add(list);
            };
            this.Invoke(Act1);
            Action Act2 = delegate
            {
                textBox1 = new TextBox();
                textBox1.Location = new Point(12, 24);
                textBox1.Size = new Size(147, 20);
                Controls.Add(textBox1);
            };
            this.Invoke(Act2);
            Action Act3 = delegate
            {
                textBox2 = new TextBox();
                textBox2.Location = new Point(177,24);
                textBox2.Size = new Size(268,20);
                Controls.Add(textBox2);
            };
            this.Invoke(Act3);
            Action Act4 = delegate
            {
                comboBox1 = new ComboBox();
                comboBox1.Location = new Point(451, 23);
                comboBox1.Size = new Size(121, 21);
                comboBox1.Items.Add("C:\\");
                Controls.Add(comboBox1);
            };
            this.Invoke(Act4);
            Action Act5 = delegate
            {
                checkBox1= new CheckBox();
                checkBox1.Location = new Point(741, 24);
                checkBox1.Size = new Size(92, 17);
                checkBox1.Text = "Подкаталоги";
                Controls.Add(checkBox1);
            };
            this.Invoke(Act5);
            Action Act6 = delegate
            {
                label1 = new Label();
                label1.Text = "Файл";
                label1.Location = new Point(58, 8);
                label1.Size = new Size(36, 13);
                Controls.Add(label1);
            };
            this.Invoke(Act6);
            Action Act7 = delegate
            {
                label2 = new Label();
                label2.Text = "Слово или фраза";
                label2.Location = new Point(267, 8);
                label2.Size = new Size(94,13);
                Controls.Add(label2);
            };
            this.Invoke(Act7);
            Action Act8 = delegate
            {
                label3 = new Label();
                label3.Text = "Диски";
                label3.Location = new Point(490, 7);
                label3.Size = new Size(36, 13);
                Controls.Add(label3);
            };
            this.Invoke(Act8);
            Action Act9 = delegate
            {
                label4 = new Label();
                label4.Text = "Результат поиска количество найденных файлов: 0";
                label4.Location = new Point(267, 62);
                label4.Size = new Size(270, 13);
                Controls.Add(label4);
            };
            this.Invoke(Act9);
            Action Act10 = delegate
            {
                buttonsearch= new Button();
                buttonsearch.Text = "Поиск";
                buttonsearch.Location = new Point(578, 20);
                buttonsearch.Size = new Size(75, 23);
                Controls.Add(buttonsearch);
            };
            this.Invoke(Act10);
            Action Act11 = delegate
            {
                buttonsearch = new Button();
                buttonsearch.Text = "Поиск";
                buttonsearch.Location = new Point(659,20);
                buttonsearch.Size = new Size(75, 23);
                Controls.Add(buttonsearch);
            };
            this.Invoke(Act11);
        }


        private void buttonstartclick(object sender, EventArgs e)
        {
            thread = new Thread(CreateElement);
            thread.Start();
        }
    }
}
