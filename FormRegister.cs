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
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=MURAT\MURATSQLSERVER;Initial Catalog=e-library;User ID=Murat Yavuz;Password=123456";

        private void btnregister_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("CustomerAdd", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Name", txtregname.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Username", txtregusername.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Adress", txtregadress.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Email", txtregemail.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Password", txtregpassword.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show(" Registiration is Succeed ","INFORMATION",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            //GetSqlConnect connect = GetSqlConnect.getIntance();
            //SqlCommand sqlCmd = new SqlCommand("CustomerAdd", connect.getConnect());



        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormUserLogin form2 = new FormUserLogin();
            form2.ShowDialog();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
