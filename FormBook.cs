using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace _10._05._2018
{
    public partial class FormBook : Form
    {
        static public int veri = 0;

        public FormBook()
        {
            InitializeComponent();
        }

        Book book = new Book();
        Magazines magazine = new Magazines();
        MusicCDs musiccd = new MusicCDs();
        ItemToPurchase purchase;
        ShoppingCart shopping;
        GetSqlConnect user = GetSqlConnect.getUser();
        SqlConnection conn = new SqlConnection(@"Data Source=MURAT\MURATSQLSERVER;Initial Catalog=e-library;User ID=Murat Yavuz;Password=123456");
        private void FormUser1_Load(object sender, EventArgs e)
        {
            conn.Open();

            dtProducts.Visible = false;
            if (veri == 1)
            {


                string Select = "Select Book.ProductID AS ÜrünID, Book.Author AS Yazarı, Book.Publisher AS Yayıncı, Products.Price AS ÜrünFiyatı From Book Inner Join Products On Book.ProductID = Products.ProductID ";
                SqlDataAdapter da = new SqlDataAdapter(Select, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dtProducts.DataSource = dt;
                conn.Close();
                label3.Text = "Welcome " + user.username;

                shopping = new ShoppingCart(user.customer_ID);
            }
            if (veri == 2)
            {


                string Select = "Select Magazines.ProductID AS ÜrünID, Magazines.Issue AS BasımTarihi, Magazines.Type AS Türü, Products.Price AS ÜrünFiyatı From Magazines Inner Join Products On Magazines.ProductID = Products.ProductID ";
                SqlDataAdapter da = new SqlDataAdapter(Select, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dtProducts.DataSource = dt;
                conn.Close();
                label3.Text = "Welcome " + user.username;

                shopping = new ShoppingCart(user.customer_ID);
            }
            if (veri == 3)
            {


                string Select = "Select MusicCD.ProductID AS ÜrünID, MusicCD.Singer AS Sanatçı, MusicCD.Type AS Türü, Products.Price AS ÜrünFiyatı From MusicCD Inner Join Products On MusicCD.ProductID = Products.ProductID ";
                SqlDataAdapter da = new SqlDataAdapter(Select, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dtProducts.DataSource = dt;
                conn.Close();
                label3.Text = "Welcome " + user.username;

                shopping = new ShoppingCart(user.customer_ID);
            }

        }

        private void addshoppingcart_Click(object sender, EventArgs e)
        {
            Book tmp = new Book();
            dtProducts.CurrentCell = dtProducts.Rows[0].Cells[0];

            if (dtProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please Select Products !");
            }
            else
            {
                foreach (DataGridViewRow row in dtProducts.Rows)
                {

                    if (row.Selected == true)
                    {
                        tmp.ProductID = int.Parse(row.Cells[0].Value.ToString());
                        purchase = new ItemToPurchase(tmp, 1);
                        shopping.AddProductToShoppingCart(purchase);
                    }
                }

                //dtlistshpcrd.DataSource = shopping.PrintShoppingCartProducts();
                lbltutar.Text = shopping.PaymentAmount().ToString() + "TL";

            }

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = shopping.m_customerID;
            using (conn)
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM ShoppingCart " + "WHERE CustomerId=@Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", i);
                    int rows = cmd.ExecuteNonQuery();

                }
            }

            user.watch.Stop();
            MessageBox.Show("Time spent on the system: " + user.watch.Elapsed.Seconds + " seconds", "Time stamp");

            this.Hide();
            FormUserLogin formlog = new FormUserLogin();
            formlog.ShowDialog();
            conn.Close();
        }



        private void lbltutar_Click(object sender, EventArgs e)
        {
        }




        //private void btnRemoveProduct_Click(object sender, EventArgs e)
        //{
        //    MusicCDs tmp = new MusicCDs();
        //    if (dtProducts.SelectedRows.Count == 0)
        //    {
        //        MessageBox.Show("Please Select Products !");
        //    }
        //    else
        //    {
        //        foreach (DataGridViewRow row in dtlistshpcrd.Rows)
        //        {
        //            if (row.Selected == true)
        //            {
        //                tmp.ProductID = int.Parse(row.Cells[0].Value.ToString());
        //                purchase = new ItemToPurchase(tmp, 1);
        //                shopping.RemoveProductToShoppingCart(purchase);
        //            }
        //        }
        //    }

        //    dtlistshpcrd.DataSource = shopping.PrintShoppingCartProducts();
        //    lbltutar.Text = shopping.PaymentAmount().ToString() + "TL";

        //}

        private void btnsatınal_Click(object sender, EventArgs e)
        {
            this.Hide();
            Purchase formPurchase = new Purchase();
            formPurchase.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormUser2 formx = new FormUser2();
            formx.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Book tmp = new Book();
            dtProducts.CurrentCell = dtProducts.Rows[1].Cells[0];

            if (dtProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please Select Products !");
            }
            else
            {
                foreach (DataGridViewRow row in dtProducts.Rows)
                {

                    if (row.Selected == true)
                    {
                        tmp.ProductID = int.Parse(row.Cells[0].Value.ToString());
                        purchase = new ItemToPurchase(tmp, 1);
                        shopping.AddProductToShoppingCart(purchase);
                    }
                }

                //dtlistshpcrd.DataSource = shopping.PrintShoppingCartProducts();
                lbltutar.Text = shopping.PaymentAmount().ToString() + "TL";

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Book tmp = new Book();
            dtProducts.CurrentCell = dtProducts.Rows[2].Cells[0];

            if (dtProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please Select Products !");
            }
            else
            {
                foreach (DataGridViewRow row in dtProducts.Rows)
                {

                    if (row.Selected == true)
                    {
                        tmp.ProductID = int.Parse(row.Cells[0].Value.ToString());
                        purchase = new ItemToPurchase(tmp, 1);
                        shopping.AddProductToShoppingCart(purchase);
                    }
                }

                //dtlistshpcrd.DataSource = shopping.PrintShoppingCartProducts();
                lbltutar.Text = shopping.PaymentAmount().ToString() + "TL";

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Book tmp = new Book();
            dtProducts.CurrentCell = dtProducts.Rows[3].Cells[0];

            if (dtProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please Select Products !");
            }
            else
            {
                foreach (DataGridViewRow row in dtProducts.Rows)
                {

                    if (row.Selected == true)
                    {
                        tmp.ProductID = int.Parse(row.Cells[0].Value.ToString());
                        purchase = new ItemToPurchase(tmp, 1);
                        shopping.AddProductToShoppingCart(purchase);
                    }
                }

                //dtlistshpcrd.DataSource = shopping.PrintShoppingCartProducts();
                lbltutar.Text = shopping.PaymentAmount().ToString() + "TL";

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Book tmp = new Book();
            dtProducts.CurrentCell = dtProducts.Rows[4].Cells[0];

            if (dtProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please Select Products !");
            }
            else
            {
                foreach (DataGridViewRow row in dtProducts.Rows)
                {

                    if (row.Selected == true)
                    {
                        tmp.ProductID = int.Parse(row.Cells[0].Value.ToString());
                        purchase = new ItemToPurchase(tmp, 1);
                        shopping.AddProductToShoppingCart(purchase);
                    }
                }

                //dtlistshpcrd.DataSource = shopping.PrintShoppingCartProducts();
                lbltutar.Text = shopping.PaymentAmount().ToString() + "TL";

            }
        }
    }
}
