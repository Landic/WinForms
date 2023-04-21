using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volkov_HW_WinForms_15
{
    internal class Firm
    {
        public string fullname { get; set; }
        public string datebirthday { get; set; }
        string phone;
        string adress;
        public int numberhome { get; set; }
        int apartmentnumber;

        public Firm()
        {
            fullname= string.Empty;
            datebirthday = string.Empty;
            phone= string.Empty;
            adress= string.Empty;
            numberhome= 0;
            apartmentnumber= 0;
        }

        public Firm(string fullname, string datebirthday, string phone, string adress, int numberhome, int apartmentnumber)
        {
            this.fullname = fullname;
            this.datebirthday = datebirthday;
            this.phone = phone;
            this.adress = adress;
            this.numberhome = numberhome;
            this.apartmentnumber = apartmentnumber;
        }

        public override string ToString()
        {
            return $"{fullname} - {datebirthday} - {phone} - {adress} - {numberhome} - {apartmentnumber}";
        }
    }
}
