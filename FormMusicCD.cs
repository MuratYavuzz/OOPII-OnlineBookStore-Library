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
    public partial class FormMusicCD : Form
    {
        public FormMusicCD()
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

        private void FormMusicCD_Load(object sender, EventArgs e)
        {
            conn.Open();

            dtmusic.Visible = false;
            string Select = "Select MusicCD.ProductID AS ÜrünID, MusicCD.Singer AS Sanatçı, MusicCD.Type AS Türü, Products.Price AS ÜrünFiyatı From MusicCD Inner Join Products On MusicCD.ProductID = Products.ProductID ";
            SqlDataAdapter da = new SqlDataAdapter(Select, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtmusic.DataSource = dt;
            conn.Close();
            label3.Text = "Welcome " + user.username;

            shopping = new ShoppingCart(user.customer_ID);
        }

        private void label20_Click(object sender, EventArgs e)
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

        private void btnsatınal_Click(object sender, EventArgs e)
        {
            this.Hide();
            Purchase formPurchase = new Purchase();
            formPurchase.ShowDialog();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormUser2 formx = new FormUser2();
            formx.ShowDialog();
        }

        private void btmildavis_Click(object sender, EventArgs e)
        {
            MusicCDs tmp = new MusicCDs();
            dtmusic.CurrentCell = dtmusic.Rows[0].Cells[0];

            if (dtmusic.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please Select Products !");
            }
            else
            {
                foreach (DataGridViewRow row in dtmusic.Rows)
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

        private void btnmichael_Click(object sender, EventArgs e)
        {
            MusicCDs tmp = new MusicCDs();
            dtmusic.CurrentCell = dtmusic.Rows[1].Cells[0];

            if (dtmusic.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please Select Products !");
            }
            else
            {
                foreach (DataGridViewRow row in dtmusic.Rows)
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

        private void btnpink_Click(object sender, EventArgs e)
        {
            MusicCDs tmp = new MusicCDs();
            dtmusic.CurrentCell = dtmusic.Rows[2].Cells[0];

            if (dtmusic.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please Select Products !");
            }
            else
            {
                foreach (DataGridViewRow row in dtmusic.Rows)
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

        private void btneric_Click(object sender, EventArgs e)
        {
            MusicCDs tmp = new MusicCDs();
            dtmusic.CurrentCell = dtmusic.Rows[3].Cells[0];

            if (dtmusic.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please Select Products !");
            }
            else
            {
                foreach (DataGridViewRow row in dtmusic.Rows)
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

        private void btnzeki_Click(object sender, EventArgs e)
        {
            MusicCDs tmp = new MusicCDs();
            dtmusic.CurrentCell = dtmusic.Rows[4].Cells[0];

            if (dtmusic.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please Select Products !");
            }
            else
            {
                foreach (DataGridViewRow row in dtmusic.Rows)
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

        private void btnsıla_Click(object sender, EventArgs e)
        {
            MusicCDs tmp = new MusicCDs();
            dtmusic.CurrentCell = dtmusic.Rows[5].Cells[0];

            if (dtmusic.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please Select Products !");
            }
            else
            {
                foreach (DataGridViewRow row in dtmusic.Rows)
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
