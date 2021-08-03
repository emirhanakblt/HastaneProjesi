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
    public partial class frmrandevulistesi : Form
    {
        public frmrandevulistesi()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        private void frmrandevulistesi_Load(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            SqlDataAdapter tg = new SqlDataAdapter("Select * from tbl_randevular",bgl.baglantı());
            tg.Fill(tbl);
            dataGridView1.DataSource = tbl;
        }
        
        
    }
}
