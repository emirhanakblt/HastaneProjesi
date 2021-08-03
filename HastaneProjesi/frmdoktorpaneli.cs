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
    public partial class frmdoktorpaneli : Form
    {
        public frmdoktorpaneli()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();

        private void frmdoktorpaneli_Load(object sender, EventArgs e)
        {
            SqlCommand komut7 = new SqlCommand("Select BransAd from tbl_brans ", bgl.baglantı());
            SqlDataReader bn = komut7.ExecuteReader();
            while (bn.Read())
            {
                comboBox1.Items.Add(bn[0]);
            }
            bgl.baglantı().Close();
            DataTable dt2 = new DataTable();
            SqlDataAdapter gh2 = new SqlDataAdapter("Select * From tbl_doktorlar", bgl.baglantı());
            gh2.Fill(dt2);
            dataGridView1.DataSource = dt2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           //VERİ EKLEME
            SqlCommand komut = new SqlCommand("insert into tbl_doktorlar (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTc,DoktorSifre) values (@p1,@p2,@p3,@p4,@p5)",bgl.baglantı());
            komut.Parameters.AddWithValue("@p1",textBox1.Text);
            komut.Parameters.AddWithValue("@p2",textBox2.Text);
            komut.Parameters.AddWithValue("@p3",comboBox1.Text);
            komut.Parameters.AddWithValue("@p4",maskedTextBox2.Text);
            komut.Parameters.AddWithValue("@p5",textBox3.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Kayıt başarıyla gerçekleşti");
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //VERİLERİ TEXTBOXLARA ÇAĞIRMA
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            maskedTextBox2.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           //SİLME
            SqlCommand komut1 = new SqlCommand("delete from tbl_doktorlar where DoktorTc=@h1",bgl.baglantı());
            komut1.Parameters.AddWithValue("@h1",maskedTextBox2.Text);
            komut1.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Başarıyla Silindi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
           //GÜNCELLEME
            SqlCommand komut2 = new SqlCommand("update tbl_doktorlar set DoktorAd=@k1, DoktorSoyad=@k2,DoktorBrans=@k3,DoktorSifre=@k5 where DoktorTc=@k4",bgl.baglantı());
            komut2.Parameters.AddWithValue("@k1", textBox1.Text);
            komut2.Parameters.AddWithValue("@k2", textBox2.Text);
            komut2.Parameters.AddWithValue("@k3", comboBox1.Text);
            komut2.Parameters.AddWithValue("@k4", maskedTextBox2.Text);
            komut2.Parameters.AddWithValue("@k5", textBox3.Text);
            komut2.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Güncelleme başarıyla gerçekleşti");

        }

        
    }
}
