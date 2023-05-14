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
using System.Security.Cryptography.X509Certificates;

namespace hms
{
	public partial class Asistan_Detay : Form
	{
		public Asistan_Detay()
		{
			InitializeComponent();
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void label5_Click(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			Doktor_Paneli drpanel = new Doktor_Paneli();
			drpanel.Show();
			this.Hide();
		
		
		}

		private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
		{

		}

		public string TCNumara;
		public string secilen;
		sqlbaglantisi bgl = new sqlbaglantisi();

		public string Appid;
		public string AppDate;
		public string AppClock;
		public string AppSpc;
		public string AppDoctor;
		public bool AppSt;
		public string AppPtIn;



        private void Asistan_Detay_Load(object sender, EventArgs e)
        {
			txtAsistanRandevuPaneliID.Text = Appid;
			mskAsistanRandevuPaneliTarih.Text = AppDate;
			mskAsistanRandevuPaneliSaat.Text = AppClock;
			cmbAsistanRandevuPaneliBrans.Text = AppSpc;
			cmbAsistanRandevuPaneliDoktor.Text = AppDoctor;
			chkAsistanDetayDurum.Checked = AppSt;
			mskAsistanRandevuPaneliTC.Text = AppPtIn;

			//ASİSTAN BİLGİLERİ PANELİ

			lblAsistanDetayTC.Text = TCNumara;
			txtAsistanRandevuPaneliID.Text = secilen;

			SqlCommand komut1 = new SqlCommand("Select asistanADSOYAD From tbl_ASISTANLAR Where asistanTC = @p1", bgl.baglanti());
			komut1.Parameters.AddWithValue("@p1", lblAsistanDetayTC.Text);
			SqlDataReader dr1 = komut1.ExecuteReader();

			while (dr1.Read())
			{
				lblAsistanDetayAdSoyad.Text = dr1[0].ToString();
			}
			bgl.baglanti().Close();


			// RANDEVULAR PANELİ

			DataTable dt1 = new DataTable();
			SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_BRANSLAR",bgl.baglanti());
			da.Fill(dt1);
			dataGridView1.DataSource = dt1;

            //DOKTORLAR PANELİ

            DataTable dt2 = new DataTable();
			SqlDataAdapter da2 = new SqlDataAdapter("Select (doktorAD + '  ' + doktorSOYAD) as 'Doktorlar', doktorBRANS From tbl_DOKTORLAR", bgl.baglanti());
			da2.Fill(dt2);
			dataGridView2.DataSource = dt2;

			//BRANŞ COMBOBOX

			SqlCommand komut2 = new SqlCommand("Select bransAD From tbl_BRANSLAR",bgl.baglanti());
			SqlDataReader dr2 = komut2.ExecuteReader();
			while (dr2.Read())
			{
				cmbAsistanRandevuPaneliBrans.Items.Add(dr2[0]);
			}
			bgl.baglanti().Close();

            //DOKTOR COMBOBOX

            //cmbAsistanRandevuPaneliDoktor.Items.Clear();

            //SqlCommand komut = new SqlCommand("Select doktorAD,doktorSOYAD From tbl_DOKTORLAR Where doktorBRANS = @p1", bgl.baglanti());
            //komut.Parameters.AddWithValue("@p1", cmbAsistanRandevuPaneliBrans.Text);
            //SqlDataReader dr = komut.ExecuteReader();

            //cmbAsistanRandevuPaneliDoktor.Items.Clear();

            //while (dr.Read())
            //{
            //    cmbAsistanRandevuPaneliDoktor.Items.Add(dr[0] + "  " + dr[1]);
            //}
            //bgl.baglanti().Close();
        }

        private void btnAsistanDetayRandevuyuKaydet_Click(object sender, EventArgs e)
        {
			SqlCommand kaydetKomutu = new SqlCommand("Insert into tbl_RANDEVULAR (randevuTARIH,randevuSAAT,randevuBRANS,randevuDOKTOR) values (@r1,@r2,@r3,@r4)", bgl.baglanti());
			kaydetKomutu.Parameters.AddWithValue("@r1",mskAsistanRandevuPaneliTarih.Text);
			kaydetKomutu.Parameters.AddWithValue("@r2",mskAsistanRandevuPaneliSaat.Text);
			kaydetKomutu.Parameters.AddWithValue("@r3",cmbAsistanRandevuPaneliBrans.Text);
            kaydetKomutu.Parameters.AddWithValue("@r4", cmbAsistanRandevuPaneliDoktor.Text);

			kaydetKomutu.ExecuteNonQuery();
			bgl.baglanti().Close();
			MessageBox.Show("Randevu oluşturuldu. Bu pencereyi Kapatabilirsiniz!","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void cmbAsistanRandevuPaneliDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
					
		}

        private void cmbAsistanRandevuPaneliBrans_SelectedIndexChanged(object sender, EventArgs e)
        {

            //DOKTOR COMBOBOX

            cmbAsistanRandevuPaneliDoktor.Items.Clear();

            SqlCommand komut = new SqlCommand("Select doktorAD,doktorSOYAD From tbl_DOKTORLAR Where doktorBRANS = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbAsistanRandevuPaneliBrans.Text);
            SqlDataReader dr = komut.ExecuteReader();

            cmbAsistanRandevuPaneliDoktor.Items.Clear();

            while (dr.Read())
            {
                cmbAsistanRandevuPaneliDoktor.Items.Add(dr[0] + "  " + dr[1]);
            }
            bgl.baglanti().Close();
        }

        private void btnAsistanDetayDuyuruOlustur_Click(object sender, EventArgs e)
        {
			SqlCommand komut = new SqlCommand("Insert into tbl_DUYURULAR (duyuru) values (@d1)",bgl.baglanti());
			komut.Parameters.AddWithValue("@d1",rchAsistanDetayDuyuru.Text);
			komut.ExecuteNonQuery();
			bgl.baglanti().Close();
            MessageBox.Show("Randevu Oluşturuldu. Bu Pencereyi Kapatabilirsiniz! ", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAsistanDetayBransPaneli_Click(object sender, EventArgs e)
        {
			Brans_Paneli brnspaneli = new Brans_Paneli();
			brnspaneli.Show();
            this.Hide();
        }

        private void btnAsistanDetayRandevuListesi_Click(object sender, EventArgs e)
        {
            Randevu_Listesi rdvlist = new Randevu_Listesi();
            rdvlist.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Anasayfa fr = new Anasayfa();
            fr.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Anasayfa fr = new Anasayfa();
            fr.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAsistanDetayRandevuyuGuncelle_Click(object sender, EventArgs e)
        {
        }

        private void btnAsistanDetayDuyurular_Click(object sender, EventArgs e)
        {
			Duyurular duyurular = new Duyurular();
			duyurular.Show();
        }
    }
}
