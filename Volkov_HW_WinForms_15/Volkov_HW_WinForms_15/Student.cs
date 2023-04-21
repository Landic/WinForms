using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volkov_HW_WinForms_15
{
    internal class Student
    {
        public string fullname { get; set; }
        public int numbergroup { get; set; }
        public int gradephysic { get; set; }
        public int grademath { get; set; }
        public int gradeinformatics { get; set; }
        string datesession { get; set; }
        public int Averagegrade { get; set; }

        public Student()
        {
            fullname= string.Empty;
            numbergroup= 0;
            gradephysic= 0;
            grademath= 0;
            gradeinformatics= 0;
            datesession= string.Empty;
        }

        public Student(string fullname, int numbergroup, int gradephysic, int grademath, int gradeinformatics, string datesession)
        {
            this.fullname = fullname;
            this.numbergroup = numbergroup;
            this.gradephysic = gradephysic;
            this.grademath = grademath;
            this.gradeinformatics = gradeinformatics;
            this.datesession = datesession;
        }

        public override string ToString()
        {
            return $"{fullname} || {numbergroup} || {grademath} || {gradephysic} || {gradeinformatics} || {datesession}";
        }
    }
}
