using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HastaneProjesi
{
    class sqlbaglanti
    {
        public SqlConnection baglantı()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-M4Q4SMD\\SQLEXPRESS;Initial Catalog=Hastane_Projesi;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
