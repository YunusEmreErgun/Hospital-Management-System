using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hms
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti() {

            SqlConnection baglan = new SqlConnection("Data Source=yunusemre\\SQLEXPRESS;Initial Catalog=Hastane_Yonetim_Sistemi;Integrated Security=True");
            baglan.Open();
            return baglan;

        }
    }
}
