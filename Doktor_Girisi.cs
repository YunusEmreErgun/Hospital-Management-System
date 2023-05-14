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
    public partial class Doktor_Girisi : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public Doktor_Girisi()
        {
            InitializeComponent();
        }

        private void btnDoktorGirisi_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from tbl_DOKTORLAR where doktorTC = @p1 and doktorSIFRE  = @p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",mskDoktorTC.Text);
            komut.Parameters.AddWithValue("@p2",txtDoktorSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Doktor_Detay fr = new Doktor_Detay();
                fr.tc = mskDoktorTC.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Şifre veya TC No Yanlış Lütfen Tekrar Deneyin.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            bgl.baglanti().Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Anasayfa fr = new Anasayfa();
            fr.Show();
            this.Hide();
        }

        private void Doktor_Girisi_Load(object sender, EventArgs e)
        {

        }
    }
}
