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

namespace HastaneProjesi
{
    public partial class frmdoktorbilgidüzenle : Form
    {
        public frmdoktorbilgidüzenle()
        {
            InitializeComponent();
        }
        public string tcdok;
        sqlbaglanti bgl = new sqlbaglanti();
        private void frmdoktorbilgidüzenle_Load(object sender, EventArgs e)
        {
           maskedTextBox1.Text = tcdok;
            SqlCommand komut = new SqlCommand("Select * from tbl_doktorlar where DoktorTc=@p1",bgl.baglantı());
            komut.Parameters.AddWithValue("@p1",maskedTextBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                textBox3.Text = dr[1].ToString();
                textBox1.Text = dr[2].ToString();
                comboBox1.Text = dr[3].ToString();
                textBox4.Text = dr[5].ToString();
            }
            bgl.baglantı().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update tbl_doktorlar set DoktorAd=@h1,DoktorSoyad=@h2,DoktorBrans=@h3,DoktorSifre=@h4 where DoktorTc=@h5",bgl.baglantı());
            komut2.Parameters.AddWithValue("@h1",textBox3.Text);
            komut2.Parameters.AddWithValue("@h2",textBox1.Text);
            komut2.Parameters.AddWithValue("@h3",comboBox1.Text);
            komut2.Parameters.AddWithValue("@h4",textBox4.Text);
            komut2.Parameters.AddWithValue("@h5",maskedTextBox1.Text);
            komut2.ExecuteNonQuery();
            bgl.baglantı().Close();

            MessageBox.Show("Güncelleme yapıldı!");
        }
    }
}
