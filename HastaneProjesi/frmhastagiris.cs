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
    public partial class frmhastagiris : Form
    {
        public frmhastagiris()
        {
            InitializeComponent();
        }

        sqlbaglanti mt = new sqlbaglanti();
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmhastakayit hk = new frmhastakayit();
            
            hk.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("Select* from tbl_hastalar where HastaTc=@p1 and HastaSifre=@P2", mt.baglantı());
            komut1.Parameters.AddWithValue("@p1", maskedtc.Text);
            komut1.Parameters.AddWithValue("@p2", hastasifre.Text);
            SqlDataReader sb = komut1.ExecuteReader();
            if(sb.Read())
            {
                frmhastadetay hd = new frmhastadetay();
                 hd.tc = maskedtc.Text;
                hd.Show();
               
                
                this.Hide();
            }
            else
            {
                MessageBox.Show("TC kimlik veya Sifre Hatalı!");
            }
            mt.baglantı().Close();
        }
    }
}
