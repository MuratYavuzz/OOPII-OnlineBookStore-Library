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

    public partial class Purchase : Form
    {
        ShoppingCart shopping;
        GetSqlConnect user = GetSqlConnect.getUser();
        SqlConnection conn = new SqlConnection(@"Data Source=MURAT\MURATSQLSERVER;Initial Catalog=e-library;User ID=Murat Yavuz;Password=123456");
        ItemToPurchase purchase;
        public Purchase()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Purchase_Load(object sender, EventArgs e)
        {
            shopping = new ShoppingCart(user.customer_ID);
            dtpurchased.DataSource = shopping.PrintShoppingCartProducts();
            lbltutarpurchase.Text = shopping.PaymentAmount().ToString() + " TL";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormUser2 formUser = new FormUser2();
            formUser.ShowDialog();
        }

        private void addshoppingcart_Click(object sender, EventArgs e)
        {
            int quant = shopping.PlaceOrder();
            if (comboBox1.Text == "Cash")
            {
                DialogResult question;
                question = MessageBox.Show("These " + quant + " Items Will be Taken with Cash", "Purchasing", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (question == DialogResult.OK)
                {
                    MsgBox form2 = new MsgBox();
                    form2.ShowDialog();
                }
            }

            else
            {

                DialogResult question;
                question = MessageBox.Show("These " + quant + " Items Will be Taken with Credit Card", "Purchasing", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (question == DialogResult.OK)
                {
                    MsgBox form2 = new MsgBox();
                    form2.ShowDialog();
                }
            }
        }

        private void dtpurchased_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MusicCDs tmp = new MusicCDs();
            if (dtpurchased.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please Select Products !");
            }
            else
            {
                foreach (DataGridViewRow row in dtpurchased.Rows)
                {
                    if (row.Selected == true)
                    {
                        tmp.ProductID = int.Parse(row.Cells[0].Value.ToString());
                        purchase = new ItemToPurchase(tmp, 1);
                        shopping.RemoveProductToShoppingCart(purchase);
                    }
                }
            }

            dtpurchased.DataSource = shopping.PrintShoppingCartProducts();
            lbltutarpurchase.Text = shopping.PaymentAmount().ToString() + "TL";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult question;
            question = MessageBox.Show("Are you Sure Want to Cancel the Order?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (question == DialogResult.OK)
            {
                int i = shopping.m_customerID;
                using (conn)
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM ShoppingCart " + "WHERE CustomerId=@Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", i);
                        int rows = cmd.ExecuteNonQuery();
                        lbltutarpurchase.Text = shopping.PaymentAmount().ToString() + "TL";

                    }
                }
                conn.Close();
                dtpurchased.DataSource = null;
            }
                
              

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
