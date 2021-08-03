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
    public partial class frmhastakayit : Form
    {
        public frmhastakayit()
        {
            InitializeComponent();
        }

        private void frmhastakayit_Load(object sender, EventArgs e)
        {
            
        }
        sqlbaglanti sg = new sqlbaglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_hastalar(Hastaad,HastaSoyad,HastaTc,HastaTelefon,HastaSifre,HastaCinsiyet) values (@p1,@p2,@p3,@p4,@p5,@p6)",sg.baglantı());
            komut.Parameters.AddWithValue("@p1" , textBox3.Text);
            komut.Parameters.AddWithValue("@p2" , textBox1.Text);
            komut.Parameters.AddWithValue("@p3" , maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p4" , maskedTextBox2.Text);
            komut.Parameters.AddWithValue("@p5" , textBox4.Text);
            komut.Parameters.AddWithValue("@p6" , textBox2.Text);
            komut.ExecuteNonQuery();
            sg.baglantı().Close();
            MessageBox.Show("Başarıyla kayıt olundu!");
        }
    }
}
