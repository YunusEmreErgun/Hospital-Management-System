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
	public partial class Doktor_Bilgileri_Duzenle : Form
	{
		public Doktor_Bilgileri_Duzenle()
		{
			InitializeComponent();
		}

		sqlbaglantisi bgl = new sqlbaglantisi();
		public string tc;
        private void Doktor_Bilgileri_Duzenle_Load(object sender, EventArgs e)
        {
			mskDoktorBilgileriTC.Text = tc;

			SqlCommand komut = new SqlCommand("select * from tbl_DOKTORLAR where doktorTC = @p1", bgl.baglanti());
			komut.Parameters.AddWithValue("@p1",mskDoktorBilgileriTC.Text);
			SqlDataReader dr = komut.ExecuteReader();
			while (dr.Read())
			{
				txtDoktorBilgileriAd.Text = dr[1].ToString();
				txtDoktorBilgileriSoyad.Text = dr[2].ToString();
				cmbDoktorBilgileriBrans.Text = dr[3].ToString();
				txtDoktorBilgileriSifre.Text = dr[5].ToString();
			}
			bgl.baglanti().Close();
        }

        private void btnDoktorBilgileriDuzenle_Click(object sender, EventArgs e)
        {
			SqlCommand komut = new SqlCommand("update tbl_DOKTORLAR set doktorAD = @p1, doktorSOYAD = @p2, doktorBRANS = @p3, doktorSIFRE = @p4 where doktorTC = @p5",bgl.baglanti());
			komut.Parameters.AddWithValue("@p1",txtDoktorBilgileriAd.Text);
			komut.Parameters.AddWithValue("@p2",txtDoktorBilgileriSoyad.Text);
			komut.Parameters.AddWithValue("@p3",cmbDoktorBilgileriBrans.Text);
			komut.Parameters.AddWithValue("@p4",txtDoktorBilgileriSifre.Text);
			komut.Parameters.AddWithValue("@p5",mskDoktorBilgileriTC.Text);
			komut.ExecuteNonQuery();
			bgl.baglanti().Close();
			MessageBox.Show("Bilgileriniz Güncellenmiştir. Bu pencereyi kapatabilirsiniz.","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);

		}

        private void cmbDoktorBilgileriBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
