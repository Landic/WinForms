using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Task2
{
    public partial class Form1 : Form
    {
        List<string[]> list = new List<string[]>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.maskedTextBox4.Text.Length != 0 && this.maskedTextBox3.Text.Length != 0 && this.maskedTextBox2.Text.Length != 0 && this.maskedTextBox1.Text.Length != 0)
            {
                string[] str = new string[] { maskedTextBox4.Text, maskedTextBox3.Text, maskedTextBox2.Text, maskedTextBox1.Text };
                string item = string.Format("{0}", maskedTextBox4.Text);
                list.Add(str);
                listBox1.Items.Add(item);
            }
            else
                MessageBox.Show("Заполните!");
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string[] temp = list[listBox1.SelectedIndex];
                maskedTextBox4.Text = temp[0];
                maskedTextBox3.Text = temp[1];
                maskedTextBox2.Text = temp[2];
                maskedTextBox1.Text = temp[3];
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                list.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                using(StreamWriter stream = new StreamWriter("User.txt"))
                {
                    string[] temp = list[listBox1.SelectedIndex];
                    stream.WriteLine(temp[0]);
                    stream.WriteLine(temp[1]);
                    stream.WriteLine(temp[2]);
                    stream.WriteLine(temp[3]);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string[] temp = list[listBox1.SelectedIndex];
                XElement wr = new XElement("User"); // начало документа
                XElement it = new XElement("Name", temp[0]); // создаем атрибут слова
                wr.Add(it);
                it = new XElement("Surname", temp[1]);
                wr.Add(it);
                it = new XElement("E-mail", temp[2]);
                wr.Add(it);
                it = new XElement("Phone", temp[3]);
                wr.Add(it);
                XDocument document = new XDocument(wr);
                document.Save("User.xml");
            }
        }
    }
}
