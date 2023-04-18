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

namespace Volkov_HW_WinForms_9
{
    public partial class Form1 : Form
    {
        string path;
        ImageList image_list1;
        ImageList image_list2;

        public Form1()
        {
            InitializeComponent();
            // инициализация treeView
            treeView1.Nodes.Add(new TreeNode("My Computer", 0, 0));
            foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                if (di.IsReady)
                {
                    TreeNode driveNode = new TreeNode(di.Name, 1, 1);
                    driveNode.Tag = di.RootDirectory;
                    treeView1.Nodes[0].Nodes.Add(driveNode);
                    driveNode.Nodes.Add(new TreeNode());
                }
            }
            image_list1 = new ImageList();
            image_list2 = new ImageList();
            image_list1.ColorDepth = ColorDepth.Depth32Bit;
            image_list1.ImageSize = new Size(32, 32);
            listView1.SmallImageList = image_list1;
            image_list2.ColorDepth = ColorDepth.Depth32Bit;
            image_list2.ImageSize = new Size(16, 16);
            listView1.LargeImageList = image_list1;
            listView1.SmallImageList = image_list2;

            path = "C:\\";
            DirectoryInfo di2 = new DirectoryInfo(path);
            Icon icon = new Icon("icon.ico");                
            image_list1.Images.Add(icon);
            image_list2.Images.Add(icon);
            foreach (DirectoryInfo dir in di2.GetDirectories())
            {

                ListViewItem lvi = new ListViewItem(dir.Name, 0);
                lvi.Tag = dir;
                listView1.Items.Add(lvi);
            }
            foreach (FileInfo file in di2.GetFiles())
            {
                icon = Icon.ExtractAssociatedIcon(file.FullName);
                image_list1.Images.Add(icon);
                image_list2.Images.Add(icon);
                ListViewItem lvi = new ListViewItem(file.Name, image_list1.Images.Count - 1);
                lvi.Tag = file;
                listView1.Items.Add(lvi);
            }
        }


        private void listView1_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
