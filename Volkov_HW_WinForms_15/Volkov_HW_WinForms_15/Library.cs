using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volkov_HW_WinForms_15
{
    internal class Library
    {
        public int ticket { get; set; }
        string surname;
        public string namebook { get; set; } 
        string publishinghouse;
        int yearcreate;
        string datetakebook;
        public string datereturnbook { get; set; }

        public Library()
        {
            ticket = 0;
            surname= string.Empty;
            namebook = string.Empty;
            publishinghouse= string.Empty;
            yearcreate = 0;
            datetakebook = string.Empty;
            datereturnbook = string.Empty;
        }

        public Library(int ticket, string surname, string namebook, string publishinghouse, int yearcreate, string datetakebook, string datereturnbook)
        {
            this.ticket = ticket;
            this.surname = surname;
            this.namebook = namebook;
            this.publishinghouse = publishinghouse;
            this.yearcreate = yearcreate;
            this.datetakebook = datetakebook;
            this.datereturnbook = datereturnbook;
        }

        public override string ToString()
        {
            return $"{ticket} || {surname} || {namebook} || {publishinghouse} || {yearcreate} || {datetakebook} || {datereturnbook}";
        }
    }
}
