using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Volkov_HW_WinForms_1
{
    public partial class Form1 : Form
    {
        int countmessage;
        int countstr;
        int number;

        public Form1()
        {
            InitializeComponent();
            countmessage= 0;
            countstr= 0;
            number = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "Имя: Данил\nФамилия: Волков";
            string strtemp = string.Empty;
            MessageBox.Show(str, "Резюме");
            countmessage++;
            strtemp = str;
            str = "Место учебы: Приватный университет \"Шаг\"";
            MessageBox.Show(str, "Резюме");
            strtemp += str;
            str = "Факультет: Компьютерные науки";
            countmessage++;
            MessageBox.Show(str, "Резюме");
            strtemp += str;
            str = "Будущая профессия: Программист";
            strtemp += str;
            countstr = strtemp.Length;
            countmessage++;
            MessageBox.Show("Будущая профессия: Программист", "Резюме");
            countmessage++;
            MessageBox.Show("Конец", $"Количество окон: {countmessage}, Среднее количество символов: {countstr / countmessage}");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = 0;
            while (true)
            {
                count++;
                Random rand = new Random();
                number = rand.Next(2000);
                DialogResult rez = MessageBox.Show($"Число -> {number}", $"Угадай число Попытка -> {count}", MessageBoxButtons.YesNo);
                if(rez == DialogResult.Yes)
                {
                    rez = MessageBox.Show($"Компьютер выиграл попыток использовано -> {count}\nХотите продолжить?", "Угадай число", MessageBoxButtons.RetryCancel);
                    if(rez == DialogResult.Retry)
                    {
                        count = 0;
                        continue;
                    }
                    break;
                }
                else if(count == 10)
                {
                    rez = MessageBox.Show($"Компьютер проиграл попыток использовано -> {count}\nХотите продолжить?", "Угадай число", MessageBoxButtons.RetryCancel);
                    if (rez == DialogResult.Retry)
                    {
                        count = 0;
                        continue;
                    }
                    break;
                }
            }
        }
    }
}
