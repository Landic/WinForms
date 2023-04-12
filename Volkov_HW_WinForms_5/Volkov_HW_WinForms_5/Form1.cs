using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Volkov_HW_WinForms_5
{
    public partial class Form1 : Form
    {
        double temp;
        MainMenu mymenu;
        MenuItem reset, exit, menu, next;

        ContextMenuStrip contextmenu;
        ToolStripMenuItem menu2, next2;

        Form2 form2;
        Form3 form3;
        Form4 form4;

        int i;

        public static double priceA95 { get; set; }
        public static double priceA952 { get; set; }
        public static double diesel { get; set; }
        public static double Gaz { get; set; }

        public static double HotDog { get; set; }
        public static double Coffee { get; set; }
        public static double CocaCola { get; set; }
        public static double Sendwich { get; set; }

        public Form1()
        {
            InitializeComponent();
            this.Text = "ОККО";
            priceA95 = 48.99;
            priceA952 = 51.00;
            diesel = 48.99;
            Gaz = 21.99;
            HotDog = 68.00;
            Coffee = 54;
            CocaCola = 33;
            Sendwich = 59;
            i = 0;
            temp = 0;
            mymenu = new MainMenu();

            menu = new MenuItem("Menu");
            menu.Select += new EventHandler(SelectMenu1);
            mymenu.MenuItems.Add(menu);

            next = new MenuItem("Next Client");
            next.Click += new EventHandler(SaveAndNext);
            next.Select += new EventHandler(SelectMenu1);
            menu.MenuItems.Add(next);

            reset = new MenuItem("Reset");
            reset.Select += new EventHandler(Reset);
            mymenu.MenuItems.Add(reset);

            exit = new MenuItem("Exit");
            exit.Select += new EventHandler(Exit);
            mymenu.MenuItems.Add(exit);

            Menu = mymenu;


            contextmenu = new ContextMenuStrip();
            menu2 = new ToolStripMenuItem("Menu");
            next2 = new ToolStripMenuItem("Next Client");
            next2.Click += new EventHandler(SaveAndNext);
            menu2.DropDownItems.Add(next2);
            contextmenu.Items.Add(menu2);
            contextmenu.Items.Add("Reset");
            contextmenu.Items[1].Click += new EventHandler(Reset);
            contextmenu.Items.Add("Exit");
            contextmenu.Items[2].Click += new EventHandler(Exit);
            ContextMenuStrip = contextmenu;

        }

        

        private void Exit(object sender, EventArgs e)
        {
            Close();
        }

        private void Reset(object sender, EventArgs e)
        {
            label7.Text = "0";
            temp = 0;
        }

        private void SelectMenu1(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;

        }

        private void SaveAndNext(object sender, EventArgs e)
        {
            i++;
            using (StreamWriter wr = new StreamWriter("SaveClient.txt", true))
            {
                wr.WriteLine("Client " + i);
                wr.WriteLine("Type fuel -> " + form2.GetComboText);
                wr.WriteLine("Price fuel -> " + form2.GetPriceFuel);
                wr.WriteLine("Buy litr -> " + form2.GetLitr);
                wr.WriteLine("\n\nCafe");
                wr.WriteLine("Hot dog -> " + form3.HotDog);
                wr.WriteLine("Coffee -> " + form3.Cafe);
                wr.WriteLine("Coca-Cola -> " + form3.CocaCola);
                wr.WriteLine("Sendwich -> " + form3.Sendwich);
                wr.WriteLine("\n\nTotal price -> " + label7.Text + "\n\n");
            }

            Reset(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form2 = new Form2();
            form2.ParentForm1 = this;
            DialogResult rez = form2.ShowDialog();
            if(rez == DialogResult.OK)
            {
                temp += Convert.ToDouble(form2.GetText);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form3 = new Form3();
            form3.ParentForm1 = this;
            DialogResult rez = form3.ShowDialog();
            if (rez == DialogResult.OK)
            {
                temp += form3.GetCafe;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label7.Text = temp.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            form4 = new Form4();
            form4.ParentForm1 = this;
            DialogResult rez = form4.ShowDialog();
            if (rez == DialogResult.Cancel)
            {
            }
        }
    }
}
