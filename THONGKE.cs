using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nl
{
    public partial class THONGKE : Form
    {
        public SqlConnection conn = new SqlConnection();
        nl.tangmatudong ham = new tangmatudong();
        SqlConnection con;
        public THONGKE()
        {
            InitializeComponent();
        }
        
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        tangmatudong _sv = new tangmatudong();
        private void Form1_Load(object sender, EventArgs e)
        {
            ham.Ketnoi(conn);
            ham.HienthiDulieuDG(dataGridView1, "SELECT * FROM tblBaixe", conn);
           
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult f = MessageBox.Show("Ban co that su muon thoat ?", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if ( f == DialogResult.Yes)
            {
                Form1 fmQL = new Form1();
                fmQL.Show();
            }    
        }

        
        private void button6_Click(object sender, EventArgs e)
        {
            DateTime bdtn = dtpngaybatdau.Value;
            DateTime dn = dtpngaykethuc.Value;
            string sql = "SELECT * FROM tblBaigiuxe WHERE thoigiantra >= @bdtn AND ngaygiantra <= @dn";
            SqlCommand comd = new SqlCommand(sql, conn);
            comd.Parameters.AddWithValue("@bdtn", bdtn);
            comd.Parameters.AddWithValue("@dn", dn);
            SqlDataAdapter ad = new SqlDataAdapter(comd);
            DataTable dl = new DataTable();
            ad.Fill(dl);
            dataGridView1.DataSource = dl;
            decimal tc = 0;
            foreach (DataRow row in dl.Rows)
            {
                tc += Convert.ToDecimal(row["dongia"]);
            }
            txtgiatien.Text = $"{((float)tc)}";
        }

        private void txtmaxe_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime bdtn = dtpngaybatdau.Value;
            DateTime dn = dtpngaykethuc.Value;
            string sql = "SELECT * FROM tblBaixe WHERE thoigiantra >= @bdtn AND thoigiantra <= @dn";
            SqlCommand comd = new SqlCommand(sql, conn);
            comd.Parameters.AddWithValue("@bdtn", bdtn);
            comd.Parameters.AddWithValue("@dn", dn);
            SqlDataAdapter ad = new SqlDataAdapter(comd);
            DataTable dl = new DataTable();
            ad.Fill(dl);
            dataGridView1.DataSource = dl;
            decimal tc = 0;
            foreach (DataRow row in dl.Rows)
            {
                tc += Convert.ToDecimal(row["dongia"]);
            }
            txtgiatien.Text = $"{((float)tc)}";
        }
    }
}
