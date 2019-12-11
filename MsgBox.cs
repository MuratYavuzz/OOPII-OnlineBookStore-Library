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
    public partial class MsgBox : Form
    {
        public MsgBox()
        {
            InitializeComponent();
        }
        GetSqlConnect user = GetSqlConnect.getUser();

        private void button1_Click(object sender, EventArgs e)
        { 
            MessageBox.Show("Invoince sent to this E-Mail Adress: " + user.customer_email,"Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Hide();
            Purchase form4 = new Purchase();
            form4.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Invoince sent to this Your MobilePhone","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            Purchase form4 = new Purchase();
            form4.ShowDialog();
                 

        }
    }
}
