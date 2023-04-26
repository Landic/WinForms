using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Volkov_HW_WinForms_16
{
    public partial class Form1 : Form
    {
        int count;
        Mutex mutex;

        public Form1()
        {
            InitializeComponent();
            count = 0;
            mutex = new Mutex(false,"Search");
        }

        private async void SearchBut_Click(object sender, EventArgs e)
        {
            try
            {
                mutex.WaitOne();
                textBox1.Clear();
                count = 0;
                DirectoryInfo dir = new DirectoryInfo(DirectoryBox.Text);
                FileInfo[] files = await Task.Run(() => dir.GetFiles("*.txt"));
                foreach (var i in files)
                {
                    using (StreamReader read = new StreamReader(i.FullName))
                    {
                        while(!read.EndOfStream)
                        {
                            string[] temp = read.ReadToEnd().Split(' ');
                            foreach(string j in temp)
                            {
                                if (j.Contains(WordBox.Text))
                                {
                                    count++;
                                }
                            }
                            
                        }
                    }
                    if(count > 0)
                    {
                        textBox1.Text = i.Name + "\t" + i.FullName + "\t" + count;
                    }
                }
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

    }
}
