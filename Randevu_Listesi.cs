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
	public partial class Randevu_Listesi : Form
	{
		public Randevu_Listesi()
		{
			InitializeComponent();
		}

		sqlbaglantisi bgl = new sqlbaglantisi();

        private void Randevu_Listesi_Load(object sender, EventArgs e)
        {
			DataTable dt = new DataTable();
			SqlDataAdapter da = new SqlDataAdapter("Select * from tbl_RANDEVULAR",bgl.baglanti());
			da.Fill(dt);
			dataGridView1.DataSource = dt;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Anasayfa fr = new Anasayfa();
            fr.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Anasayfa fr = new Anasayfa();
            fr.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Asistan_Detay fr = new Asistan_Detay();
            fr.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            Asistan_Detay asstdetay = new Asistan_Detay();
            asstdetay.Appid = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            asstdetay.AppDate = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            asstdetay.AppClock = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            asstdetay.AppSpc = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            asstdetay.AppDoctor = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            if ((bool)dataGridView1.Rows[secilen].Cells[5].Value)
            {
                asstdetay.AppSt = true;
            }
            else
            {
                asstdetay.AppSt = false;
            }
            asstdetay.AppPtIn = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            asstdetay.Show();
            this.Hide();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
