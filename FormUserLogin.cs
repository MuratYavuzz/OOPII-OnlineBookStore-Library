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
using System.Collections;

namespace _10._05._2018
{
    public partial class FormUserLogin : Form
    {
        

        public FormUserLogin()
        {
            InitializeComponent();
        }

        SqlConnection conn= new SqlConnection(@"Data Source=MURAT\MURATSQLSERVER;Initial Catalog=e-library;User ID=Murat Yavuz;Password=123456");

  
        
        private void btnregister_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRegister form1 = new FormRegister();
            form1.ShowDialog();
      
        }
    
        private void btnsign_Click(object sender, EventArgs e)
        {
            GetSqlConnect user = GetSqlConnect.getUser();
            if (txtUserName.Text == "" || txtUserPassword.Text == "")
            {
                MessageBox.Show("Please Fill in the Fields!","WARNING",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                if (user.Login(txtUserName.Text, txtUserPassword.Text) == true)
                {
                    MessageBox.Show("Access Succeed!");
                    this.Hide();
                    FormUser2 form = new FormUser2();
                    form.ShowDialog();

                }
                else
                {
                    MessageBox.Show("User Not Found !", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin form = new FormLogin();
            form.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
