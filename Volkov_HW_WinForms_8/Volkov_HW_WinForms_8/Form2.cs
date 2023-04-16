using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Volkov_HW_WinForms_8
{
    public partial class Form2 : Form
    {
        public List<Tuple<string, string[]>> list { get; set; }
        public List<string> answer { get; set; }

        public Form ParentForm1 { get; set; }

        public Form2()
        {
            InitializeComponent();
            list = new List<Tuple<string, string[]>>();
            answer = new List<string>();

        }

        private void AddQuestionButton_Click(object sender, EventArgs e)
        {
            list.Add(new Tuple<string, string[]>(QuestionForAdd.Text, new string[] { AnswerForAdd1.Text, AnswerForAdd2.Text, AnswerForAdd3.Text, AnswerForAdd4.Text }));
            answer.Add(AnswerForAdd1.Text);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = list.Count;
            int index = (int)numericUpDown1.Value;
            TextBoxForDelete.Text = list[index - 1].Item1;
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            int index = (int)numericUpDown1.Value;
            list.RemoveAt(index - 1);
            answer.RemoveAt(index - 1);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown2.Minimum = 1;
            numericUpDown2.Maximum = list.Count;
            int index = (int)numericUpDown2.Value;
            TextBoxQuestionForChange.Text = list[index - 1].Item1;
            textBox8.Text = list[index - 1].Item2[0];
            textBox9.Text = list[index - 1].Item2[1];
            textBox10.Text = list[index - 1].Item2[2];
            textBox11.Text = list[index - 1].Item2[3];
        }

        private void Change_Click(object sender, EventArgs e)
        {
            int index = (int)numericUpDown2.Value;
            Tuple<string, string[]> oldTuple = list[index - 1];
            Tuple<string,string[]> newTuple = new Tuple<string, string[]>(TextBoxQuestionForChange.Text, oldTuple.Item2);
            list[index - 1] = newTuple;
            list[index - 1].Item2[0] = textBox8.Text;
            list[index - 1].Item2[1] = textBox9.Text;
            list[index - 1].Item2[2] = textBox10.Text;
            list[index - 1].Item2[3] = textBox11.Text;
            for (int i = 0; i < list[index -1 ].Item2.Length; i++)
            {
                if (answer[index-1] == list[index - 1].Item2[i])
                {
                    return;
                }
            }
            answer[index - 1] = textBox8.Text;
        }
    }
}
