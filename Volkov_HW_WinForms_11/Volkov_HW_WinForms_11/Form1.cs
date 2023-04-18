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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

namespace Volkov_HW_WinForms_11
{
    public partial class Form1 : Form
    {
        Thread thread;
        ImageList imageList1;
        string direct;
        string format;

        public Form1()
        {
            InitializeComponent();
            thread = null;
            foreach (DriveInfo i in DriveInfo.GetDrives())
            {
                comboBox1.Items.Add(i.Name);
                imageList1 = new ImageList();
            }
            direct = string.Empty;
            format = string.Empty;
        }

        void Search()
        {
            listView1.Items.Clear();
            string[] file = Directory.GetFiles(direct);
            string[] dir = Directory.GetDirectories(direct);
            ImageList image = new ImageList();
            Icon icon;
            int index = 1;
            foreach (string i in file)
            {
                icon = Icon.ExtractAssociatedIcon(i);
                image.Images.Add(icon);
                if (i.Contains(textBox1.Text))
                    listView1.Items.Add(i, index++);
            }
            label5.Text = listView1.Items.Count.ToString();
        }

        private void SearchBut_Click(object sender, EventArgs e)
        {
            direct = comboBox1.SelectedItem.ToString();
            format = textBox1.Text;
            thread = new Thread(new ThreadStart(Search));
            thread.IsBackground= true;
            thread.Start();
            StopBut.Enabled = true;
            SearchBut.Enabled = false;
        }

        private void StopBut_Click(object sender, EventArgs e)
        {
            thread.Abort();
            StopBut.Enabled = false;
            SearchBut.Enabled = true;
        }
    }
}
