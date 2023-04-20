using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Volkov_HW_WinForms_14
{
    public partial class Form1 : Form
    {
        Process[] processes;
        public Form1()
        {
            InitializeComponent();
            processes = Process.GetProcesses();
            listView1.Columns.Add("Имя процесса", 210);
            listView1.Columns.Add("ID процессора", 210);
            foreach (var i in processes)
            {
                listView1.Items.Add(new ListViewItem() { Text = i.ProcessName, SubItems = { i.Id.ToString() } });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                processes[selectedItem.Index].Kill();
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                processes[selectedItem.Index].Kill();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            processes = null;
            processes = Process.GetProcesses();
            listView1.Items.Clear();
            foreach (var i in processes)
            {
                listView1.Items.Add(new ListViewItem() { Text = i.ProcessName, SubItems = { i.Id.ToString() } });
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != string.Empty)
            {
                processes[processes.Length - 1].StartInfo.FileName = textBox1.Text;
                processes[processes.Length - 1].Start();
                listView1.Items.Clear();
                foreach (var i in processes)
                {
                    listView1.Items.Add(new ListViewItem() { Text = i.ProcessName, SubItems = { i.Id.ToString() } });
                }
            }
        }
    }
}
