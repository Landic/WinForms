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

namespace Volkov_HW_WinForms_13
{
    public partial class Form1 : Form
    {
        List<Flight> flights;
        List<Passenger> passesenger;
        int index;
        Thread thread;

        public Form1()
        {
            InitializeComponent();
            flights= new List<Flight>() 
            { 
                new Flight("Kyiv", new DateTime(2023,11,20,23,45,0), "3:27:00"),
                new Flight("Lviv", new DateTime(2023,5,11,11,34,0), "4:35:00")
            };

            passesenger= new List<Passenger>() 
            { 
                new Passenger(flights[0],20,"Jack Vilson", 40),
                new Passenger(flights[0],10,"Joe Baiden", 30),
                new Passenger(flights[0],15,"Barak Obama", 25),
                new Passenger(flights[1],20,"Mark Vilson", 40)
            };
            foreach(var i in flights)
            {
                comboBox1.Items.Add(i);
            }
            index = 0;
            thread = null;
        }

        void AddList()
        {
            try 
            {
                Action act1 = delegate
                {
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    foreach (var i in passesenger)
                    {
                        if (flights[index] == i.flight)
                        {
                            listBox1.Items.Add(i.NS);
                            listBox2.Items.Add(i.CountItems + " Count Items " + i.weight + " kg");
                        }
                    }
                };
                act1.Invoke();
                Action act2 = delegate
                {
                    label1.Text = "Время полета: " + flights[index].timeflight;
                };
                act2.Invoke();
                Action act3 = delegate 
                {
                    int countweight = 0;
                    foreach(var i in passesenger) 
                    {
                        if (flights[index] == i.flight)
                        {
                            countweight += i.weight;
                        }
                    }
                    label2.Text = "Общий вес: " + countweight;
                };
                act3.Invoke();
            }
            catch(Exception ex) { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = comboBox1.SelectedIndex;
            thread = new Thread(new ThreadStart(AddList));
            thread.Start();
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(thread!= null) thread.Abort();
        }
    }
}
