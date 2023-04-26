using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp5.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp5
{
    class Controller
    {
        public string GetBookName(string bookname)
        {
            Database db = new Database();
            string rez = db.Find(bookname);
          
            if(rez!=null)
            {
                return rez.ToString();
            }
            return "Книга не найдена!";
        }

        public string GetBookAutor(string author)
        {
            Database db = new Database();
            string rez = db.FindAutor(author);

            if (rez != null)
            {
                return rez.ToString();
            }
            return "Книга не найдена!";
        }
    }
}
