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
	public partial class Hasta_Detay : Form
	{
		public Hasta_Detay()
		{
			InitializeComponent();
		}

        public string tc;

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void lblHastaDetayTC_Click(object sender, EventArgs e)
        {

        }

        private void Hasta_Detay_Load(object sender, EventArgs e)
        {

            //Ad soyad çekme
            lblHastaDetayTC.Text = tc;
            SqlCommand komut = new SqlCommand("select hastaAD,hastaSOYAD from tbl_HASTALAR where hastaTC=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",lblHastaDetayTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblHastaDetayAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();


            //Randevu geçmişi
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_RANDEVULAR where randevuHASTATC = "+tc,bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Branşları çekme
            SqlCommand komut2 = new SqlCommand("select bransAD from tbl_BRANSLAR", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }


        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();
            SqlCommand komut3 = new SqlCommand("select doktorAD,doktorSOYAD from tbl_DOKTORLAR where doktorBRANS=@p1",bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", cmbBrans.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbDoktor.Items.Add(dr3[0] + "  " + dr3[1]);
            }
            bgl.baglanti().Close(); 
        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_RANDEVULAR where randevuBRANS = '" + cmbBrans.Text +"'" + "and randevuDOKTOR = '" + cmbDoktor.Text + "'and randevuDURUM = 0", bgl.baglanti()); ;
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        
        
        }

        private void lnkHastaDetayBilgileriDuzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hasta_Bilgileri_Duzenle fr = new Hasta_Bilgileri_Duzenle();
            fr.TCno = lblHastaDetayTC.Text;
            fr.Show();


        }

        private void label8_Click(object sender, EventArgs e)
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            txtHastaDetayRandevuID.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnHastaDetayRandevuAl_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tbl_RANDEVULAR set randevuDURUM = 1,randevuHASTATC = @p1, randevuHASTASIKAYET= @p2 where randevuID = @p3",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",lblHastaDetayTC.Text);
            komut.Parameters.AddWithValue("@p2",rchHastaSikayet.Text);
            komut.Parameters.AddWithValue("@p3",txtHastaDetayRandevuID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Alındı. Bu pencereyi kapatabilirsiniz.","Bilgilendirme.",MessageBoxButtons.OK,MessageBoxIcon.Information);
        
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
