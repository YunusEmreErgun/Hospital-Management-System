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
	public partial class Hasta_Kayit : Form
	{
		public Hasta_Kayit()
		{
			InitializeComponent();
		}

		sqlbaglantisi bgl = new sqlbaglantisi();

        private void btnHastaKayit_Click(object sender, EventArgs e)
        {
			SqlCommand komut = new SqlCommand("insert into tbl_HASTALAR (hastaAD,hastaSOYAD,hastaTC,hastaTELEFON,hastaSIFRE,hastaCINSIYET) values (@p1,@p2,@p3,@p4,@p5,@p6) ", bgl.baglanti());
			komut.Parameters.AddWithValue("@p1", txtHastaKayitAd.Text);
            komut.Parameters.AddWithValue("@p2", txtHastaKayitSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskHastaKayitTC.Text);
            komut.Parameters.AddWithValue("@p4", mskHastaKayitTelNo.Text);
            komut.Parameters.AddWithValue("@p5", txtHastaSifre.Text);
            komut.Parameters.AddWithValue("@p6", cmbHastaKayitCinsiyet.Text);


            komut.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız Gerçekleşmiştir Pencereyi Kapatabilirsiniz","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void Hasta_Kayit_Load(object sender, EventArgs e)
        {

        }
    }
}
