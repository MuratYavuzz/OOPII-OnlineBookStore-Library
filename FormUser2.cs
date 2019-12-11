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

    public partial class FormUser2 : Form
    {
        public FormUser2()
        {
            InitializeComponent();
        }
        public int Secim(int secim)
        {
            return secim;
        }

        private void pcbxbooks_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormBook.veri = 1;
            FormBook form1 = new FormBook();
            form1.ShowDialog();
     
        }

        private void label1_Click(object sender, EventArgs e)
        {

            this.Hide();
            FormBook.veri = 1;
            FormBook form1 = new FormBook();
            form1.ShowDialog();

        }

        private void pcbxmagazines_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormBook.veri = 2;
            FormMagazines form1 = new FormMagazines();
            form1.ShowDialog();
     

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormBook.veri = 2;
            FormMagazines form1 = new FormMagazines();
            form1.ShowDialog();

        }

        private void pcbxmusiccds_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormBook.veri = 3;
            FormMusicCD formy = new FormMusicCD();
            formy.ShowDialog();


        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormBook.veri = 3;
            FormMusicCD formy = new FormMusicCD();
            formy.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
