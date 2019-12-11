using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace _10._05._2018
{
    public class Book : Product
    {
        private int bookISBN;
        private string bookAuthor;
        private string bookPublisher;
        public bool Error;
        private GetSqlConnect con;

        public int BookISBN_
        {
            get { return bookISBN; }
            set { bookISBN = value; }
        }
        public string BookAuthor_
        {
            get { return bookAuthor; }
            set { bookAuthor = value; }
        }
        public string BookPublisher_
        {
            get { return bookPublisher; }
            set { bookPublisher = value; }
        }
      
    }
}
