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
    public partial class frmbilgidüzenle : Form
    {
        public frmbilgidüzenle()
        {
            InitializeComponent();
        }
        public string TC;
        sqlbaglanti yh = new sqlbaglanti();
        private void frmbilgidüzenle_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Text = TC;
           
            //TC KİMLİĞE GÖRE BİLGİLERİ METİNLERE TAŞIDIK
            SqlCommand komut = new SqlCommand("Select * from tbl_hastalar where HastaTc=@p1 ",yh.baglantı());
            komut.Parameters.AddWithValue("@p1",maskedTextBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                textBox3.Text = dr[1].ToString();
                textBox1.Text = dr[2].ToString();
                maskedTextBox2.Text = dr[4].ToString();
                textBox4.Text = dr[5].ToString();
                textBox2.Text = dr[6].ToString();
            }
            yh.baglantı().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //GÜNCELLEME YAPIYORUZ BURDA
            SqlCommand komut2 = new SqlCommand("update tbl_hastalar set Hastaad=@p2,HastaSoyad=@p3,HastaTelefon=@p4,HastaSifre=@p5,HastaCinsiyet=@p6 where HastaTc=@p7",yh.baglantı());
            komut2.Parameters.AddWithValue("@p2", textBox3.Text);
            komut2.Parameters.AddWithValue("@p3", textBox1.Text);
            komut2.Parameters.AddWithValue("@p4", maskedTextBox2.Text);
            komut2.Parameters.AddWithValue("@p5", textBox4.Text);
            komut2.Parameters.AddWithValue("@p6", textBox2.Text);
            komut2.Parameters.AddWithValue("@p7", maskedTextBox1.Text);
            komut2.ExecuteNonQuery();
            yh.baglantı().Close();
            MessageBox.Show("Başarıyla Güncellendi");

        }
    }
}
