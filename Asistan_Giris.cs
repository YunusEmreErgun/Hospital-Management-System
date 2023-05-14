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
	public partial class Asistan_Giris : Form
	{
		public Asistan_Giris()
		{
			InitializeComponent();
		}

		sqlbaglantisi bgl = new sqlbaglantisi();


        private void btnAsistanGirisi_Click(object sender, EventArgs e)
        {

			SqlCommand komut = new SqlCommand("Select * From tbl_ASISTANLAR Where asistanTC = @p1 and asistanSIFRE = @p2", bgl.baglanti());
			komut.Parameters.AddWithValue("@p1", mskAsistanTC.Text);
			komut.Parameters.AddWithValue("@p2",txtAsistanSifre.Text);
			SqlDataReader dr = komut.ExecuteReader();

			if (dr.Read())
			{
				Asistan_Detay frs = new Asistan_Detay();
				frs.TCNumara = mskAsistanTC.Text;
				frs.Show();
				this.Hide();
			}
			else
			{
				MessageBox.Show("Hatalı TC Kimlik Numarası !!","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
			bgl.baglanti().Close();
        }

        private void Asistan_Giris_Load(object sender, EventArgs e)
        {
			
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Anasayfa fr = new Anasayfa();
            fr.Show();
            this.Hide();
        }
    }
}
