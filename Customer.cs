using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace _10._05._2018
{
    class Customer
    {
        private GetSqlConnect database;
        public bool error;
        private int CustomerID_;
        private string Name_;
        private string Adress_;
        private string Email_;
        private string Username_;
        private string Password_;
        public string CustomerError;
        public int CustomerID
        {
            get { return CustomerID_; }
        }
        public string CustomerName
        {
            get { return Name_; }
            set { Name_ = value; }
        }
        public string CustomerAdress
        {
            get { return Adress_; }
            set { Adress_ = value; }
        }
        public string CustomerEmail
        {
            get { return Email_; }
            set { Email_ = value; }
        }
        public string CustomerUsername
        {
            get { return Username_; }
            set { Username_ = value; }
        }
        public string CustomerPassword
        {
            get { return Password_; }
            set { Password_ = value; }
        }
        public Customer() { }
       
    }
}
