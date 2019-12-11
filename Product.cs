using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _10._05._2018
{
     public abstract class Product
    {
        private string ProductName;
        private float ProductPrice;
        public int ProductID;

        public string ProductName_
        {
            get { return ProductName; }
            set { ProductName = value; }
        }
        public float ProductPrice_
        {
            get { return ProductPrice; }
            set { ProductPrice = value; }
        }
        public int ProductID_
        {
            get { return ProductID; }
            set { ProductID = value; }
        }

    }

}

