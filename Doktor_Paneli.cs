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
	public partial class Doktor_Paneli : Form
	{
		public Doktor_Paneli()
		{
			InitializeComponent();
		}

		sqlbaglantisi bgl = new sqlbaglantisi();

        private void Doktor_Paneli_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_DOKTORLAR", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;


            //BRANŞ PANELİ

            SqlCommand komut2 = new SqlCommand("Select bransAD From tbl_BRANSLAR",bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbDrPanelBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void btnDrPanelEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_DOKTORLAR (doktorAD,doktorSOYAD,doktorBRANS,doktorTC,doktorSIFRE) values (@d1,@d2,@d3,@d4,@d5)",bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", txtDrPanelAd.Text);
            komut.Parameters.AddWithValue("@d2", txtDrPanelSoyad.Text);
            komut.Parameters.AddWithValue("@d3", cmbDrPanelBrans.Text);
            komut.Parameters.AddWithValue("@d4", mskDrPanelTC.Text);
            komut.Parameters.AddWithValue("@d5", txtDrPanelSifre.Text);


            komut.ExecuteNonQuery();

            bgl.baglanti().Close();

            MessageBox.Show("Doktor Eklenmiştir. Pencereyi Kapatabilirsiniz.","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnDrPanelSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from tbl_DOKTORLAR where doktorTC=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",mskDrPanelTC.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Silinmiştir. Pencereyi Kapatabilirsiniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtDrPanelAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtDrPanelSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbDrPanelBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskDrPanelTC.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtDrPanelSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        

        private void btnDrPanelGuncelle_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("Update tbl_DOKTORLAR set doktorAD =@d1, doktorSOYAD = @d2, doktorBRANS = @d3, doktorSIFRE = @d5 where doktorTC = @d4", bgl.baglanti());

            komut.Parameters.AddWithValue("@d1", txtDrPanelAd.Text);
            komut.Parameters.AddWithValue("@d2", txtDrPanelSoyad.Text);
            komut.Parameters.AddWithValue("@d3", cmbDrPanelBrans.Text);
            komut.Parameters.AddWithValue("@d4", mskDrPanelTC.Text);
            komut.Parameters.AddWithValue("@d5", txtDrPanelSifre.Text);

            komut.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Doktor Güncellendi. Pencereyi Kapatabilirsiniz!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Anasayfa fr = new Anasayfa();
            fr.Show();
            this.Hide();
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Asistan_Detay fr = new Asistan_Detay();
            fr.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Anasayfa fr = new Anasayfa();
            fr.Show();
            this.Hide();
        }

        private void mskDrPanelTC_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
