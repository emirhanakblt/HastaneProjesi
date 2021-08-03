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
    public partial class frmhastadetay : Form
    {
        public frmhastadetay()
        {
            InitializeComponent();
        }
        public string tc;
        
        sqlbaglanti bgl = new sqlbaglanti();
        private void frmhastadetay_Load(object sender, EventArgs e)
        {
            
            label1.Text = tc;
            //AD SOYAD ÇEKME
            SqlCommand komut2 = new SqlCommand("select Hastaad,HastaSoyad From tbl_hastalar where HastaTc=@p1", bgl.baglantı());
            komut2.Parameters.AddWithValue("@p1", label1.Text);
            SqlDataReader mt = komut2.ExecuteReader();
            while (mt.Read())
            {
                label2.Text = mt[0] + " " + mt[1];
            }
                bgl.baglantı().Close();
            //Randevu Geçmişi
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From tbl_randevular where HastaTc="+ tc,bgl.baglantı());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            //BRANŞLARI ÇEKME
            SqlCommand komut3 = new SqlCommand("Select BransAd From tbl_brans",bgl.baglantı());
            SqlDataReader br = komut3.ExecuteReader();
            while(br.Read())
            {
                comboBox1.Items.Add(br[0]);
            }

            bgl.baglantı().Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            SqlCommand komut4 = new SqlCommand("Select DoktorAd,DoktorSoyad from tbl_doktorlar where DoktorBrans=@p5",bgl.baglantı());
            komut4.Parameters.AddWithValue("@p5", comboBox1.Text);
            SqlDataReader tv = komut4.ExecuteReader();
            while(tv.Read())
            {
                comboBox2.Items.Add(tv[0] + " " + tv[1]);
            }
            bgl.baglantı().Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable kll = new DataTable();
            SqlDataAdapter fr = new SqlDataAdapter("Select * from tbl_randevular where RandevuBrans='" + comboBox1.Text + "'" + "and RandevuDoktor='" + comboBox2.Text + "' and RandevuDurum=0", bgl.baglantı());
            fr.Fill(kll);
            dataGridView2.DataSource = kll;
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmbilgidüzenle fr6 = new frmbilgidüzenle();
            

          
             fr6.TC = label1.Text;
                 fr6.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut10 = new SqlCommand("update tbl_randevular set RandevuDurum=1,HastaTC=@d1,HastaSikayet=@d2 where Randevuıd=@d3",bgl.baglantı());
            komut10.Parameters.AddWithValue("@d1",label1.Text);
            komut10.Parameters.AddWithValue("@d2",richTextBox1.Text);
            komut10.Parameters.AddWithValue("@d3",textBox3.Text);
            komut10.ExecuteNonQuery();
            MessageBox.Show("Randevu Aldınız!");
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            textBox3.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            
        }

        
    }
}
