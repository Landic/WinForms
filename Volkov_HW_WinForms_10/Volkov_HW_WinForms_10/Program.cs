using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;

namespace Volkov_HW_WinForms_10
{
    internal class Program
    {
        //static void Output2(object list)
        //{
        //    if (list is List<int> list2)
        //    {
        //        foreach (var i in list2)
        //        {
        //            Console.WriteLine(i);
        //        }
        //    }
        //}

        internal class Bank
        {
            int money;
            string name;
            int percent;
            Thread thread;

            public Bank(string name)
            {
                money = 0;
                this.name = name;
                percent = 0;
            }

            public void Input()
            {
                Console.WriteLine("Enter money");
                money = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter percent");
                percent= int.Parse(Console.ReadLine());
                thread = new Thread(new ThreadStart(Save));
                thread.IsBackground = true;
                thread.Name = "save";
                thread.Start();
            }

            public int Money
            {
                get { return money; }
                set 
                { 
                    money = value;
                    thread = new Thread(new ThreadStart(Save));
                    thread.IsBackground = true;
                    thread.Name = "save";
                    thread.Start();
                }
            }

            public int Percent
            {
                get { return percent; }
                set
                {
                    percent = value;
                    thread = new Thread(new ThreadStart(Save));
                    thread.IsBackground = true;
                    thread.Name = "save";
                    thread.Start();
                }
            }

            public void Save()
            {
                using(StreamWriter writer = new StreamWriter("../../Save.txt", true))
                {
                    writer.WriteLine("Name -> " + name);
                    writer.WriteLine("Money -> " + money);
                    writer.WriteLine("Percent -> " + percent);
                }
                thread.Abort();
            }
        }

        static void Main(string[] args)
        {
            // TASK 1 //

            //List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //Thread thread = new Thread(new ParameterizedThreadStart(Output2));
            //thread.IsBackground = true;
            //thread.Name = "Output collection";
            //thread.Start(list);

            // TASK 2 //

            Bank obj = new Bank("MonoBank");
            obj.Input();
            obj.Input();
            obj.Percent = 10;
        }
    }
}
