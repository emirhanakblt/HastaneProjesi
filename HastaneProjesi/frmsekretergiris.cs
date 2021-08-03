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
    public partial class frmsekretergiris : Form
    {
        public frmsekretergiris()
        {
            InitializeComponent();
        }
        sqlbaglanti yb = new sqlbaglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from tbl_sekreter where SekreterTc=@p1 and SekreterSifre=@p2",yb.baglantı());
            komut.Parameters.AddWithValue("@p1",maskedtc.Text);
            komut.Parameters.AddWithValue("@p2",hastasifre.Text);
            SqlDataReader hg = komut.ExecuteReader();
            if(hg.Read())
            {
                frmsekreterdetay frm3 = new frmsekreterdetay();
                frm3.sekretertc = maskedtc.Text;
                frm3.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
            }
            yb.baglantı().Close();
        }
    }
}
