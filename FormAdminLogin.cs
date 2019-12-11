using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10._05._2018
{
    public partial class FormAdminLogin : Form
    {
        public FormAdminLogin()
        {
            InitializeComponent();
        }

        private void FormAdminLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnadminsign_Click(object sender, EventArgs e)
        {
            if (txtadminname.Text == "Uc Silahsorler" && txtadminpassword.Text == "123456")
            {

            }
            else
                MessageBox.Show("Wrong Name or Password! Please check...","WARNING",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin form3 = new FormLogin();
            form3.ShowDialog();
        }
    }
}
