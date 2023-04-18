using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Volkov_HW_WinForms_9
{
    public partial class Form1 : Form
    {
        string path;
        ImageList image_list1;
        ImageList image_list2;
        List<string> history;
        List<string> history2;
        ImageList image_list3;
        Icon icon;
        int i;

        public Form1()
        {
            InitializeComponent();
            i = 0;

            image_list3 = new ImageList();                 
            treeView1.ImageList= image_list3;


            image_list3.Images.Add("hdd",Image.FromFile("hdd.png"));
            image_list3.Images.Add("folder", Image.FromFile("folder.png"));
            image_list3.ImageSize = new Size(20, 20);

            foreach (DriveInfo i in DriveInfo.GetDrives())
            {
                TreeNode node = new TreeNode(i.Name);
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;
                treeView1.Nodes.Add(node);
            }



            image_list1 = new ImageList();
            image_list2 = new ImageList(); 
            

            image_list1.ColorDepth = ColorDepth.Depth32Bit;
            image_list1.ImageSize = new Size(45, 45);
            listView1.LargeImageList = image_list1;

            image_list2.ColorDepth = ColorDepth.Depth32Bit;
            image_list2.ImageSize = new Size(16, 16);
            listView1.SmallImageList = image_list2;

            
            

            path = "C:\\";
            string[] file = Directory.GetFiles(path);
            string[] dir = Directory.GetDirectories(path);
            icon = new Icon("icon.ico");                
            image_list1.Images.Add(icon);
            image_list2.Images.Add(icon);
            history = new List<string>() { path };
            history2 = new List<string>();
            foreach (string i in dir)
            {
                listView1.Items.Add(i, 0);
            }
            int index = 1;
            foreach (string i in file)
            {
                icon = Icon.ExtractAssociatedIcon(i);
                image_list1.Images.Add(icon);
                image_list2.Images.Add(icon);
                listView1.Items.Add(i, index++);
            }
        }


        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem item = listView1.SelectedItems[0];
            history2.Clear();
            i = 0;
            toolStripButton2.Enabled = false;
            if (item.Tag is DirectoryInfo)
            {
                DirectoryInfo dir = (DirectoryInfo)item.Tag;
                path = dir.FullName;
                history.Add(path);
                listView1.Items.Clear();
                foreach (DirectoryInfo i in dir.GetDirectories())
                {
                    ListViewItem item2 = new ListViewItem(i.Name, 0);
                    item2.Tag = i;
                    listView1.Items.Add(item2);
                }
                foreach (FileInfo i in dir.GetFiles())
                {
                    icon = Icon.ExtractAssociatedIcon(i.FullName);
                    ListViewItem item2 = new ListViewItem(i.Name, image_list1.Images.Count - 1);
                    item2.Tag = i;
                    listView1.Items.Add(item2);
                }
                TreeNode[] node = treeView1.Nodes.Find(dir.FullName, true);
                if (node.Length > 0)
                {
                    treeView1.SelectedNode = node[0];
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            history2.Clear();
            i = 0;
            toolStripButton2.Enabled = false;
            listView1.Items.Clear();
            path = e.Node.FullPath;
            history.Add(path);
            string[] file = Directory.GetFiles(path);
            string[] dir = Directory.GetDirectories(path);
            foreach (string i in dir)
            {
                string dirname = new DirectoryInfo(i).Name;
                TreeNode node = new TreeNode(dirname);
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
                e.Node.Nodes.Add(node);
                ListViewItem item = new ListViewItem(dirname, 0);
                item.Tag = new DirectoryInfo(i);
                listView1.Items.Add(item);
            }
            int index = 1;
            foreach (string i in file)
            {
                icon = Icon.ExtractAssociatedIcon(i);
                image_list1.Images.Add(icon);
                image_list2.Images.Add(icon);
                listView1.Items.Add(i, index++);
            }
        }

        private void BigIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void ListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.List;
        }

        private void SmallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;
        }

        private void TileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.Tile;
        }

        private void TableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string[] dir = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);
            foreach (string i in dir)
            {
                DirectoryInfo dirinfo = new DirectoryInfo(i);
                ListViewItem item = new ListViewItem(dirinfo.Name, 0);
                item.SubItems.Add("");
                item.SubItems.Add("Folder");
                listView1.Items.Add(item);
            }
            
            foreach (string i in files)
            {
                FileInfo info = new FileInfo(i);
                ListViewItem item = new ListViewItem(info.Name, 1);
                item.SubItems.Add(Path.GetExtension(info.Name));
                listView1.Items.Add(item);
            }
            listView1.Columns.Add("Имя", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("Тип", 80, HorizontalAlignment.Left);
            listView1.View = View.Details;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(history.Count > 1)
            {
                history2.Add(history[history.Count - 1]);
                history.RemoveAt(history.Count - 1);
                path = history[history.Count - 1];
                
                string[] file = Directory.GetFiles(path);
                string[] dir = Directory.GetDirectories(path);
                listView1.Items.Clear();
                foreach (string i in dir)
                {
                    ListViewItem item = new ListViewItem(i, 0);
                    item.Tag = new DirectoryInfo(i);
                    listView1.Items.Add(item);
                }
                foreach (string i in file)
                {
                    FileInfo info = new FileInfo(i);
                    icon = Icon.ExtractAssociatedIcon(info.FullName);
                    image_list1.Images.Add(icon);
                    image_list2.Images.Add(icon);
                    ListViewItem item = new ListViewItem(info.Name, image_list1.Images.Count - 1);
                    item.Tag = info;
                    listView1.Items.Add(item);
                }
                toolStripButton2.Enabled = true;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
            
            history.Add(history2[history2.Count - 1]);
            path = history2[i];
            i++;

            string[] file = Directory.GetFiles(path);
            string[] dir = Directory.GetDirectories(path);
            listView1.Items.Clear();
            foreach (string i in dir)
            {
                ListViewItem item = new ListViewItem(i, 0);
                item.Tag = new DirectoryInfo(i);
                listView1.Items.Add(item);
            }
            foreach (string i in file)
            {
                FileInfo info = new FileInfo(i);
                icon = Icon.ExtractAssociatedIcon(info.FullName);
                image_list1.Images.Add(icon);
                image_list2.Images.Add(icon);
                ListViewItem item = new ListViewItem(info.Name, image_list1.Images.Count - 1);
                item.Tag = info;
                listView1.Items.Add(item);
            }
            if(history2.Count == 1) 
            {
                toolStripButton2.Enabled = false;
                history2.Clear();
                i = 0;
            }
            else if(history2.Count == i) 
            {
                toolStripButton2.Enabled = false;
                history2.Clear();
                i = 0;
            }
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (history.Count > 1)
            {
                history.RemoveAt(history.Count - 1);
                path = history[history.Count - 1];

                string[] file = Directory.GetFiles(path);
                string[] dir = Directory.GetDirectories(path);
                listView1.Items.Clear();
                foreach (string i in dir)
                {
                    ListViewItem item = new ListViewItem(i, 0);
                    item.Tag = new DirectoryInfo(i);
                    listView1.Items.Add(item);
                }
                foreach (string i in file)
                {
                    FileInfo info = new FileInfo(i);
                    icon = Icon.ExtractAssociatedIcon(info.FullName);
                    image_list1.Images.Add(icon);
                    image_list2.Images.Add(icon);
                    ListViewItem item = new ListViewItem(info.Name, image_list1.Images.Count - 1);
                    item.Tag = info;
                    listView1.Items.Add(item);
                }
                toolStripButton2.Enabled = true;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            string[] file = Directory.GetFiles(path);
            string[] dir = Directory.GetDirectories(path);
            listView1.Clear();
            foreach(string i in dir)
            {
                listView1.Items.Add(i, 0);
            }
            int index = 1;
            foreach (string i in file)
            {
                icon = Icon.ExtractAssociatedIcon(i);
                image_list1.Images.Add(icon);
                image_list2.Images.Add(icon);
                listView1.Items.Add(i, index++);
            }
        }
    }
}
