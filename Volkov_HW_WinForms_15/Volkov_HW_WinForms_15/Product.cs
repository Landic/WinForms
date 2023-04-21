using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volkov_HW_WinForms_15
{
    internal class Product
    {
        public string groupproduct { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public DateTime date { get; set; }

        public Product() 
        { 
            groupproduct= string.Empty;
            name= string.Empty;
            brand= string.Empty;
            date= DateTime.Now;
        }

        public Product(string groupproduct, string name, string brand, DateTime date)
        {
            this.groupproduct = groupproduct;
            this.name = name;
            this.brand = brand;
            this.date = date;
        }

        public override string ToString()
        {
            return $"{groupproduct} || {name} || {brand} || {date}";
        }
    }
}
