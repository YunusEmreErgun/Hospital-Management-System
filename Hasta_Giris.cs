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

namespace hms
{
    public partial class Hasta_Giris : Form
    {
        public Hasta_Giris()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void lnkHastaKayitYap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hasta_Kayit fr = new Hasta_Kayit();
            fr.Show();
        }

        private void btnHastaGirisi_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("Select * From tbl_HASTALAR Where hastaTC = @p1 and hastaSIFRE = @p2", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", mskHastaTC.Text);
            komut.Parameters.AddWithValue("@p2", txtHastaSifre.Text);

            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                Hasta_Detay fr = new Hasta_Detay();
                fr.tc = mskHastaTC.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı TC veya Şifre !");
            }

            bgl.baglanti().Close();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Anasayfa fr = new Anasayfa();
            fr.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Anasayfa fr = new Anasayfa();
            fr.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Anasayfa fr = new Anasayfa();
            fr.Show();
            this.Hide();
        }
    }
}
