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
    public partial class frmbranş : Form
    {
        public frmbranş()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();

        private void frmbranş_Load(object sender, EventArgs e)
        {
            DataTable tb = new DataTable();
            SqlDataAdapter tb2 = new SqlDataAdapter("Select * from tbl_Brans",bgl.baglantı());
            tb2.Fill(tb);
            dataGridView1.DataSource = tb;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_Brans (BransAd) values (@p1)", bgl.baglantı());
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Kayıt başarıyla gerçekleşti");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("delete from tbl_Brans where BransAd=@h1", bgl.baglantı());
            komut1.Parameters.AddWithValue("@h1",textBox2.Text);
            komut1.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Başarıyla Silindi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update tbl_Brans set BransAd=@k5 where Bransıd=@k4", bgl.baglantı());
            komut2.Parameters.AddWithValue("@k5", textBox2.Text);
            komut2.Parameters.AddWithValue("@k4", textBox1.Text);
            
            komut2.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Güncelleme başarıyla gerçekleşti");

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

        }
    }
}
