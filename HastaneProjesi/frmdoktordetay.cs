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
    public partial class frmdoktordetay : Form
    {
        public frmdoktordetay()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        public string tc;
        private void frmdoktordetay_Load(object sender, EventArgs e)
        {
            label1.Text = tc;
            SqlCommand komut = new SqlCommand("Select DoktorAd, DoktorSoyad from tbl_doktorlar where DoktorTc=@p1",bgl.baglantı());
            komut.Parameters.AddWithValue("@p1", label1.Text);
            SqlDataReader gk = komut.ExecuteReader();
            while(gk.Read())
            {
                label2.Text = gk[0]+" "+gk[1];
            }
            bgl.baglantı().Close();
            //RANDEVU TABLOSU
            DataTable dtt = new DataTable();
            SqlDataAdapter mg = new SqlDataAdapter("Select * from tbl_randevular where RandevuDoktor='" + label2.Text + "'", bgl.baglantı());
            mg.Fill(dtt);
            dataGridView1.DataSource = dtt;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmduyurular fth = new frmduyurular();
            fth.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmdoktorbilgidüzenle dbd = new frmdoktorbilgidüzenle();
            dbd.tcdok = label1.Text;
            dbd.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            richTextBox1.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
