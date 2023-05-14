using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hms
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void btn1HastaGirisi_Click(object sender, EventArgs e)
        {
            Hasta_Giris fr = new Hasta_Giris();
            fr.Show();
            this.Hide();
        }

        private void btn1DoktorGirisi_Click(object sender, EventArgs e)
        {
            Doktor_Girisi fr = new Doktor_Girisi();
            fr.Show();
            this.Hide();
        }

        private void btn1AsistanGirisi_Click(object sender, EventArgs e)
        {
            Asistan_Giris fr = new Asistan_Giris();
            fr.Show();
            this.Hide();
        }
    }
}
