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
    public partial class frmsekreterdetay : Form
    {
        public frmsekreterdetay()
        {
            InitializeComponent();
        }
        
        //GLOBAL ALAN
        public string sekretertc;
        sqlbaglanti th = new sqlbaglanti();
        
        
        
        
        
        private void frmsekreterdetay_Load(object sender, EventArgs e)
        {
          label1.Text = sekretertc;
            //AD SOYAD
            SqlCommand komut = new SqlCommand("Select SekreterAdSoyad from tbl_sekreter where SekreterTc=@p1 ",th.baglantı());
            komut.Parameters.AddWithValue("@p1",label1.Text);
            SqlDataReader gt = komut.ExecuteReader();
            while(gt.Read())
            {
                label2.Text = gt[0].ToString();
            }
            th.baglantı().Close();
            //BRANSLARI ÇEKME
            DataTable dt1 = new DataTable();
            SqlDataAdapter hg = new SqlDataAdapter("Select BransAd from tbl_brans",th.baglantı());
            hg.Fill(dt1);
            dataGridView1.DataSource = dt1;
            //DOKTORLARI ÇEKME
            DataTable dt2 = new DataTable();
            SqlDataAdapter gh2 = new SqlDataAdapter("Select (DoktorAd + '  ' + DoktorSoyad) as 'Doktorlar',DoktorBrans From tbl_doktorlar",th.baglantı());
            gh2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            //BRANŞLARI ÇEKME
            SqlCommand komut5 = new SqlCommand("Select BransAd from tbl_brans",th.baglantı());
            SqlDataReader ht = komut5.ExecuteReader();
            while(ht.Read())
            {
                comboBox1.Items.Add(ht[0]);
            }

            th.baglantı().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           //Randevu EKLEME
            SqlCommand komutkaydet = new SqlCommand("insert into tbl_randevular(RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values (@r1,@r2,@r3,@r4)",th.baglantı());
            komutkaydet.Parameters.AddWithValue("@r1",maskedTextBox1.Text);
            komutkaydet.Parameters.AddWithValue("@r2",maskedTextBox3.Text);
            komutkaydet.Parameters.AddWithValue("@r3",comboBox1.Text);
            komutkaydet.Parameters.AddWithValue("@r4",comboBox2.Text);
            komutkaydet.ExecuteNonQuery();
            th.baglantı().Close();
            MessageBox.Show("Randevu Oluşturuldu");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BRANSLARI COMBOBOXA ÇEKME
            comboBox2.Items.Clear();
            SqlCommand komut7 = new SqlCommand("Select DoktorAd,DoktorSoyad from tbl_doktorlar where DoktorBrans=@h1",th.baglantı());
            komut7.Parameters.AddWithValue("@h1", comboBox1.Text);
            SqlDataReader bn = komut7.ExecuteReader();
            while(bn.Read())
            {
                comboBox2.Items.Add(bn[0]+ " " +bn[1]);
            }
            th.baglantı().Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut8 = new SqlCommand("insert into tbl_duyurular (Duyuru) values (@f1)",th.baglantı());
            komut8.Parameters.AddWithValue("@f1", richTextBox1.Text);
            komut8.ExecuteNonQuery();
            th.baglantı().Close();
            MessageBox.Show("Duyuru Oluşturuldu");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmdoktorpaneli fhg = new frmdoktorpaneli();
            fhg.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmbranş tgh = new frmbranş();
            tgh.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmrandevulistesi ght = new frmrandevulistesi();
            ght.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut9 = new SqlCommand("update tbl_randevular set RandevuTarih=@k1, RandevuSaat=@k2,RandevuBrans=@k3 where RandevuDoktor=@k4  ", th.baglantı());
            komut9.Parameters.AddWithValue("@k1", maskedTextBox1.Text);
            komut9.Parameters.AddWithValue("@k2", maskedTextBox3.Text);
            komut9.Parameters.AddWithValue("@k3", comboBox1.Text);
            komut9.Parameters.AddWithValue("@k4", comboBox2.Text);
            


            komut9.ExecuteNonQuery();
            th.baglantı().Close();
            MessageBox.Show("Güncelleme başarıyla gerçekleşti");
        }
    }
}
