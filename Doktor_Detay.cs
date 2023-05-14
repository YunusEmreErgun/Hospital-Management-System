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
	public partial class Doktor_Detay : Form
	{
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string tc;
        public Doktor_Detay()
		{
			InitializeComponent();
		}

        private void btnDoktorDetayCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void btnDoktorDetayBilgileriDuzenle_Click(object sender, EventArgs e)
        {
            Doktor_Bilgileri_Duzenle fr = new Doktor_Bilgileri_Duzenle();
            fr.tc = lblDoktorDetayTC.Text;
            fr.Show();
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

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Doktor_Detay_Load(object sender, EventArgs e)
        {
            lblDoktorDetayTC.Text = tc;

            //Doktor Ad Soyad
            SqlCommand komut = new SqlCommand("select doktorAD, doktorSOYAD from tbl_DOKTORLAR where doktorTC = @p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",lblDoktorDetayTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblHastaDetayDoktorDetayAdSoyad.Text = dr[0] + "  " + dr[1];
            }
            bgl.baglanti().Close();


            //Randevular
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_RANDEVULAR where randevuDOKTOR = '"+ lblHastaDetayDoktorDetayAdSoyad.Text +"'" ,bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnDoktorDetayDuyurular_Click(object sender, EventArgs e)
        {
            Duyurular fr = new Duyurular();
            fr.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            rchRandevuDetayi.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
