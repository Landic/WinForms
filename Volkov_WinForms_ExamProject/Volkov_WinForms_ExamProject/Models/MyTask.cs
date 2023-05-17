using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Volkov_WinForms_ExamProject.Models
{
    internal class MyTask
    {
        public string NameTask { get; set; }
        public bool Complete { get; set; }
        public DateTime EndTask { get; set; }
        public bool ImportantTask { get; set; }

        public MyTask()
        {
            Complete = false;
            NameTask= string.Empty;
            EndTask = DateTime.Now;
            ImportantTask = false;
        }

        public MyTask(string nameTask, bool complete, DateTime endTask, bool importantTask)
        {
            NameTask = nameTask;
            Complete = complete;
            EndTask = endTask;
            ImportantTask = importantTask;
        }
    }
}
