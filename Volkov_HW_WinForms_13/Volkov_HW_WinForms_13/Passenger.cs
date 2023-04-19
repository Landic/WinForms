using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volkov_HW_WinForms_13
{
    internal class Passenger
    {
        public Flight flight { get; set; }
        public int weight {get; set; }

        public string NS { get; set; }

        public int CountItems { get; set; }

        
        public Passenger()
        {
            flight= new Flight();
            weight=0;
            NS = string.Empty;
            CountItems = 0;
        }

        public Passenger(Flight flight,int weight, string NS, int CountItems)
        {
            this.flight = flight;
            this.weight = weight;
            this.NS = NS;
            this.CountItems = CountItems;
        }

        public override string ToString()
        {
            return $"{flight} {NS} {CountItems} {weight}";
        }
    }
}
