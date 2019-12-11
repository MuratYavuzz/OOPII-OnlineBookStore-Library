using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;

namespace _10._05._2018
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
        }

        private void panelLeft_Paint(object sender, PaintEventArgs e)
        {
            DateTime Zaman = DateTime.Now;
            lbltarih.Text = Zaman.ToLongDateString();
            Timer t = new Timer();
            t.Enabled = true;
            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
        }
        void t_Tick(object sender, EventArgs e)
        {
            lblsaat.Text = DateTime.Now.ToLongTimeString();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUserLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormUserLogin form2 = new FormUserLogin();
            form2.ShowDialog();
        }

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAdminLogin form3 = new FormAdminLogin();
            form3.ShowDialog();
        }
    }
    }

