using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Volkov_WinForms_ExamProject.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Volkov_WinForms_ExamProject
{
    internal class Controller
    {
        public List<MyTask> mytask;
        public List<MyDayTask> mydaytask;
        public List<ImportantTasks> importanttasks;

        public Controller()
        {
            mytask = new List<MyTask>();
            mydaytask = new List<MyDayTask>();
            importanttasks = new List<ImportantTasks>();
        }

        public void AddMyTask(string Name, bool Complete, bool Important, DateTime date)
        {
            mytask.Add(new MyTask(Name, Complete, date, Important));
        }

        public void AddMyDayTask(string Name, bool Complete, bool Important, DateTime date)
        {
            mydaytask.Add(new MyDayTask(Name, Complete, date, Important));
        }
        public void AddImportantTask(string Name, bool Complete, bool Important, DateTime date)
        {
            importanttasks.Add(new ImportantTasks(Name, Complete, date, Important));
        }

        public void SetData(DateTime date, int index)
        {
            mytask[index].EndTask = date;
        }

        public void SetNameMyTask(string name, int index)
        {
            mytask[index].NameTask = name;
        }

        public void SetNameMyDayTask(string name, int index)
        {
            mydaytask[index].NameTask = name;
        }

        public void SetNameImportantTask(string name, int index)
        {
            importanttasks[index].NameTask = name;
        }
    }
}
