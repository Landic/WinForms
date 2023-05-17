using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volkov_WinForms_ExamProject.Models
{
    internal class MyDayTask
    {
        public string NameTask { get; set; }
        public bool Complete { get; set; }
        public DateTime EndTask { get; set; }
        public bool ImportantTask { get; set; }

        public MyDayTask()
        {
            Complete = false;
            NameTask = string.Empty;
            EndTask = DateTime.Now;
            ImportantTask = false;
        }

        public MyDayTask(string nameTask, bool complete, DateTime endTask, bool importantTask)
        {
            NameTask = nameTask;
            Complete = complete;
            EndTask = endTask;
            ImportantTask = importantTask;
        }
    }
}
