using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5.Model
{
    class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }

        public Book() { }
        public Book(string n, string a)
        {
            Name = n;
            Author = a;
        }
        public override string ToString()
        {
            return $"{Name}\t{Author}\n";
        }


    }
}
