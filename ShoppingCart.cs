using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace _10._05._2018
{
    public class ShoppingCart
    {
        private GetSqlConnect conn;
        public int m_customerID { get; set; }
        public bool ShoppingCartError { get; set; }
        public string UrunDurumu { get; set; }
        public ShoppingCart(int customerID)
        {
            m_customerID = customerID;
        }
        int PQuantity = 0;
        int _PaymentAmount = 0;
        private int price;

        public void AddProductToShoppingCart(ItemToPurchase product)
        {
            int miktar = 0;
            conn = GetSqlConnect.getUser();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select ProductQuantity From ShoppingCart Where CustomerID = @cid and ProductID = @pid";
                cmd.Connection = conn.DatabaseConnectionOpen();
                cmd.Parameters.AddWithValue("@cid", m_customerID);
                cmd.Parameters.AddWithValue("@pid", product.Product.ProductID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        miktar = int.Parse(reader["ProductQuantity"].ToString());
                    }
                }

                if (miktar > 0)
                {
                    cmd.CommandText = "Update ShoppingCart Set ProductQuantity=@quant Where CustomerID = @cuid and ProductID = @puid";
                    cmd.Parameters.AddWithValue("@puid", product.Product.ProductID);
                    cmd.Parameters.AddWithValue("@cuid", m_customerID);
                    cmd.Parameters.AddWithValue("@quant", miktar + product.ProductQuantity);
                }
                else
                {
                    cmd.CommandText = "Insert Into ShoppingCart(CustomerID, ProductID, ProductQuantity) Values (@cuid, @puid, @quantity)";


                    cmd.Parameters.AddWithValue("@cuid", m_customerID);
                    cmd.Parameters.AddWithValue("@puid", product.Product.ProductID);
                    cmd.Parameters.AddWithValue("@quantity", product.ProductQuantity);
                }

                cmd.ExecuteNonQuery();
                ShoppingCartError = true;

            }


            catch (Exception f)
            {
                ShoppingCartError = false;
                UrunDurumu = f.ToString();

            }
        }


        public DataTable PrintShoppingCartProducts()
        {
            DataTable dt = new DataTable();
            conn = GetSqlConnect.getUser();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select ShoppingCart.ProductID AS ÜrünID, Products.Name AS ÜrünAdı, ShoppingCart.ProductQuantity AS ÜrünMiktarı, Products.Price AS ÜrünFiyatı,Products.Type From ShoppingCart Inner Join Products On ShoppingCart.ProductID = Products.ProductID Where ShoppingCart.CustomerID = @cid";
            cmd.Connection = conn.DatabaseConnectionOpen();

            cmd.Parameters.AddWithValue("@cid", m_customerID);

            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {

                adapter.Fill(dt);
            }


            return dt;
        }
        public void RemoveProductToShoppingCart(ItemToPurchase product)
        {
            int miktar = 0;
            conn = GetSqlConnect.getUser();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select ProductQuantity From ShoppingCart Where CustomerID=@custom and ProductID=@prod";
            cmd.Connection = conn.DatabaseConnectionOpen();
            cmd.Parameters.AddWithValue("@custom", m_customerID);
            cmd.Parameters.AddWithValue("@prod", product.Product.ProductID);
            //her @'li parametre farklı olmalı
            using (SqlDataReader read = cmd.ExecuteReader())
            {
                if (read.Read())
                {
                    miktar = int.Parse(read["ProductQuantity"].ToString());
                }
            }
            if (miktar > 1)
            {
                cmd.CommandText = "Update ShoppingCart Set ProductQuantity=@quant Where CustomerID = @custome and ProductID = @product";
                cmd.Parameters.AddWithValue("@product", product.Product.ProductID);
                cmd.Parameters.AddWithValue("@custome", m_customerID);
                cmd.Parameters.AddWithValue("@quant", miktar - product.ProductQuantity);
                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    if (read.Read())
                    {
                        price = int.Parse(read["Price"].ToString());
                    }
                    _PaymentAmount = _PaymentAmount - price * miktar;

                }

            }
            else
            {
                cmd.CommandText = "Delete From ShoppingCart Where CustomerID = @customer and ProductID = @productid";
                cmd.Parameters.AddWithValue("@productid", product.Product.ProductID);
                cmd.Parameters.AddWithValue("@customer", m_customerID);

                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    if (read.Read())
                    {
                        price = int.Parse(read["Price"].ToString());
                    }
                    _PaymentAmount = _PaymentAmount - price * 1;

                }
            }
            cmd.ExecuteNonQuery();
        }
        public int PaymentAmount()
        {
            _PaymentAmount = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn.DatabaseConnectionOpen();
            cmd.CommandText = "Select ShoppingCart.ProductQuantity, Products.Price, Products.Name, ShoppingCart.ProductID From ShoppingCart Inner Join Products On ShoppingCart.ProductID = Products.ProductID Where ShoppingCart.CustomerID = @cid";
            cmd.Parameters.AddWithValue("@cid", m_customerID);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    PQuantity += int.Parse(reader["ProductQuantity"].ToString());
                    _PaymentAmount += int.Parse(reader["ProductQuantity"].ToString()) * int.Parse(reader["Price"].ToString());
                }



            }
            return _PaymentAmount;
        }
        public int PlaceOrder()
        {
            int quantity = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn.DatabaseConnectionOpen();
            cmd.CommandText = "Select ShoppingCart.ProductQuantity, Products.Price, Products.Name, ShoppingCart.ProductID From ShoppingCart Inner Join Products On ShoppingCart.ProductID = Products.ProductID Where ShoppingCart.CustomerID = @cid";

            cmd.Parameters.AddWithValue("@cid", m_customerID);


            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    quantity += int.Parse(reader["ProductQuantity"].ToString());

                }
            }
            return quantity;

        }


    }
}


