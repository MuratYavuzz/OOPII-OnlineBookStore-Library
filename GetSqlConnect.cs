using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;

namespace _10._05._2018
{
    public class GetSqlConnect
    {
        SqlConnection myDBconnection = new SqlConnection(@"Data Source=MURAT\MURATSQLSERVER;Initial Catalog=e-library;User ID=Murat Yavuz;Password=123456");

        private static GetSqlConnect connectuser;
        public string username, password;
        public string email;
        public string customer_name;
        public string Error;
        public string customer_email;
        public int customer_ID;
        public Stopwatch watch;
        private GetSqlConnect()
        {
            watch = new Stopwatch();
            watch.Start();
        }

        public static GetSqlConnect getUser()
        {
            if (connectuser == null)
            {
                connectuser = new GetSqlConnect();
            }

            return connectuser;
        }
        public SqlConnection DatabaseConnectionOpen()
        {
            if (myDBconnection.State == System.Data.ConnectionState.Closed)
            {
                myDBconnection.Open();
            }

            return myDBconnection;
        }
        public void DatabaseConnectionClosed()
        {
            myDBconnection.Close();
        }


        public bool Login(string _username, string _password)
        {
            username = _username;
            password = _password;

            string query = "Select * From Customer Where Username=@Username and Password=@Password";

            try
            {
                myDBconnection.Open();
                SqlCommand cmd = new SqlCommand(query, myDBconnection);
                cmd.Parameters.AddWithValue("@Username", _username);
                cmd.Parameters.AddWithValue("@Password", _password);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        customer_name = reader["Name"].ToString();
                        customer_ID = int.Parse(reader["customerID"].ToString());
                        customer_email = reader["Email"].ToString();
                        return true;
                    }
                    else { return false; }
                }

            }
            catch (Exception f)
            {
                Error = "Database Failed!" + f.ToString();
                return false;
            }
            finally
            {
                myDBconnection.Close();
            }
        }
    }
}