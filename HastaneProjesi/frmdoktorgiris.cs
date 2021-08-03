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
    public partial class frmdoktorgiris : Form
    {
        public frmdoktorgiris()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from tbl_doktorlar where DoktorTc=@p1 and DoktorSifre=@p2",bgl.baglantı());
            komut.Parameters.AddWithValue("@p1",maskedtc.Text);
            komut.Parameters.AddWithValue("@p2", hastasifre.Text);
            SqlDataReader tb = komut.ExecuteReader();
            if(tb.Read())
            {
                frmdoktordetay frmm = new frmdoktordetay();
                frmm.tc = maskedtc.Text;
                frmm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı");
            }
        }

        private void frmdoktorgiris_Load(object sender, EventArgs e)
        {
           
        }
    }
}
