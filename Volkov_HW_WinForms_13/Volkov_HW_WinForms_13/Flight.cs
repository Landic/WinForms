using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volkov_HW_WinForms_13
{
    internal class Flight
    {
        public string CityCountry { get; set; }

        public DateTime datetime { get; set; }

        public string timeflight {get; set; }
        
        public Flight()
        {
            datetime = DateTime.Now;
            CityCountry = string.Empty;
            timeflight = string.Empty;
        }

        public Flight(string cityCountry, DateTime datetime, string timeflight)
        {
            this.CityCountry = cityCountry;
            this.datetime = datetime;
            this.timeflight = timeflight;
        }

        public override string ToString()
        {
            return $"{CityCountry} {datetime}";
        }
    }
}
