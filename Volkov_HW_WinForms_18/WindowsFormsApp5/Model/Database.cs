using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp5.Model
{
    class Database
    {
        public string Find(string bookName)
        {
            string name = string.Empty;
            using (XmlReader reader = XmlReader.Create("Book.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Book")
                    {
                        string nametemp = reader.GetAttribute("Name");
                        string author = reader.GetAttribute("Author");

                        if (nametemp.Contains(bookName))
                        {
                            nametemp += "\t" + author;
                            name += nametemp + "\t\t";
                        }
                    }
                }
            }
            if(name != string.Empty)
            {
                return name;
            }
            return null;
        }

        public string FindAutor(string author)
        {
            string autor = string.Empty;
            using (XmlReader reader = XmlReader.Create("Book.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Book")
                    {
                        string autortemp = reader.GetAttribute("Author");
                        string name = reader.GetAttribute("Name");

                        if (autortemp.Contains(author))
                        {
                            autortemp += "\t" + name;
                            autor += autortemp + "\t\t";
                        }
                    }
                }
            }
            if (autor != string.Empty)
            {
                return autor;
            }
            return null;
        }

    }
}
