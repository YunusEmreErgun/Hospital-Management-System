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
	public partial class Hasta_Bilgileri_Duzenle : Form
	{
		public Hasta_Bilgileri_Duzenle()
		{
			InitializeComponent();
		}

		public string TCno;

		sqlbaglantisi bgl = new sqlbaglantisi();

        private void Hasta_Bilgileri_Duzenle_Load(object sender, EventArgs e)
        {
			mskHastaBilgileriTC.Text = TCno;

			SqlCommand komut = new SqlCommand("Select * From tbl_HASTALAR Where hastaTC = @p1",bgl.baglanti());
			komut.Parameters.AddWithValue("@p1", mskHastaBilgileriTC.Text);
			SqlDataReader dr = komut.ExecuteReader();
			while (dr.Read())
			{
				txtHastaBilgileriAd.Text = dr[1].ToString();
				txtHastaBilgileriSoyad.Text = dr[2].ToString();
				mskHastaBilgileriTelNo.Text = dr[4].ToString();
				txtHastaBilgileriSifre.Text = dr[5].ToString();
				cmbHastaBilgileriCinsiyet.Text = dr[6].ToString();
			}
			bgl.baglanti().Close();
        }

        private void btnHastaBilgileriDuzenle_Click(object sender, EventArgs e)
        {
			SqlCommand komut2 = new SqlCommand("Update tbl_HASTALAR set hastaAD = @p1, hastaSOYAD = @p2, hastaTELEFON = @p3, hastaSIFRE = @p4, hastaCINSIYET = @p5 Where hastaTC = @p6",bgl.baglanti());

			komut2.Parameters.AddWithValue("@p1", txtHastaBilgileriAd.Text);
            komut2.Parameters.AddWithValue("@p2", txtHastaBilgileriSoyad.Text);
            komut2.Parameters.AddWithValue("@p3", mskHastaBilgileriTelNo.Text);
            komut2.Parameters.AddWithValue("@p4", txtHastaBilgileriSifre.Text);
            komut2.Parameters.AddWithValue("@p5", cmbHastaBilgileriCinsiyet.Text);
            komut2.Parameters.AddWithValue("@p6", mskHastaBilgileriTC.Text);

			komut2.ExecuteNonQuery();
			bgl.baglanti().Close();

			MessageBox.Show("Bilgileriniz Güncellendi. Pencereyi Kapatabilirsiniz!","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Warning);

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Anasayfa fr = new Anasayfa();
            fr.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Anasayfa fr = new Anasayfa();
            fr.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Hasta_Giris fr = new Hasta_Giris();
            fr.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Hasta_Detay fr = new Hasta_Detay();
            fr.Show();
            this.Hide();
        }
    }
}
