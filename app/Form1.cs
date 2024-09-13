using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace nl
{
    public partial class Form1 : Form
    {
        public bool isThoat = true;
        public SqlConnection conn = new SqlConnection();
        nl.tangmatudong ham = new nl.tangmatudong();
        SqlConnection con;
        public Form1()
        {
            InitializeComponent();
        }
      


        private void Form1_Load(object sender, EventArgs e)
        {
            ham.Ketnoi(conn);
            ham.HienthiDulieuDG(dataGridView1, "SELECT * FROM tblBaixe", conn);

            string sql_maxnv = "SELECT MAX(SUBSTRING(masoxe,3, 2)) FROM tblBaixe";
            SqlCommand comd = new SqlCommand(sql_maxnv, conn);
            SqlDataReader reader = comd.ExecuteReader();
            if (reader.Read())
            {
                int manvmoi = Convert.ToInt16(reader.GetValue(0).ToString()) + 1;
                if (manvmoi < 10)
                {
                    txtmaxe.Text = "X00" + manvmoi;
                }
                else if (manvmoi < 100)
                {
                    txtmaxe.Text = "X0" + manvmoi;
                }
                else
                {
                    txtmaxe.Text = "X" + manvmoi;
                }
                //textBox1.Enabled = false;
            }
            reader.Close();
        

        }



        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            txtmaxe.Text = listView1.SelectedItems[0].SubItems[0].Text;
            txtdongia.Text = listView1.SelectedItems[0].SubItems[1].Text;
            cbotinhtrang.Text = listView1.SelectedItems[0].SubItems[2].Text;
            cboloaixe.Text = listView1.SelectedItems[0].SubItems[3].Text;
            dtpngaybatdau.Text = listView1.SelectedItems[0].SubItems[4].Text;
            dtpngaykethuc.Text = listView1.SelectedItems[0].SubItems[5].Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //            listView1.Items.Clear();
            //            ketnoi.Open();
            //            sql = @"Insert Into tblBaixe(loaixe, masoxe, trangthaixe, dongia, thoigiannhan, thoigiantra)
            //VALUES           (N'"+cboloaixe.Text+@"',N'"+txtmaxe.Text+@"',N'"+cbotinhtrang.Text+@"',N'"+txtdongia.Text+ @"',N'"+dtpngaybatdau.Text + @"',N'"+dtpngaykethuc.Text + @"')";
            //            thuchien = new SqlCommand(sql, ketnoi);
            //            thuchien.ExecuteNonQuery();
            //            ketnoi.Close();
             string sql_maxnv = "SELECT MAX(SUBSTRING(masoxe,3, 2)) FROM tblBaixe";
            SqlCommand comd = new SqlCommand(sql_maxnv, conn);
            SqlDataReader reader = comd.ExecuteReader();
            if (reader.Read())
            {
                int manvmoi = Convert.ToInt16(reader.GetValue(0).ToString()) + 1;
                if (manvmoi < 10)
                {
                    txtmaxe.Text = "X00" + manvmoi;
                }
                else if (manvmoi < 100)
                {
                    txtmaxe.Text = "X0" + manvmoi;
                }
                else
                {
                    txtmaxe.Text = "X" + manvmoi;
                }
                //textBox1.Enabled = false;
            }
            reader.Close();
            string masoxe = txtmaxe.Text;
            string dongia = txtdongia.Text;
            string loaixe = cb.Text;
            string tinhtrang = cbotinhtrang.Text;
            
            DateTime thoigiannhan = Convert.ToDateTime(dtpngaybatdau.Text);
            DateTime thoigiantra = Convert.ToDateTime(dtpngaykethuc.Text);
           
            string sql_luu = "INSERT INTO tblBaixe VALUES ( N'" + loaixe + "','" + masoxe + "', N'" + tinhtrang + "','" + dongia + "', '" + thoigiannhan.ToString("yyyy-MM-dd") + "', '" + thoigiantra.ToString("yyyy-MM-dd") + "' )";

                    ham.CapNhat(sql_luu, conn);

                    ham.HienthiDulieuDG(dataGridView1, "SELECT * FROM tblBaixe", conn);

                }

            

        private void button2_Click(object sender, EventArgs e)
        {
            //            listview1.items.clear();
            //            ketnoi.open();
            //            sql = @"update tblbaixe set
            //              loaixe = n'"+cboloaixe.text+@"', masoxe = n'"+txtmaxe.text+@"', trangthaixe = n'"+cbotinhtrang.text+@"',dongia = n'" + txtdongia.text + @",n'" + dtpngaybatdau.text + @"',n'" + dtpngaykethuc.text + @"''
            //where       ( loaixe = n'" + cboloaixe.text + @"')";
            //            thuchien = new sqlcommand(sql, ketnoi);
            //            thuchien.executenonquery();
            //            ketnoi.close();
            //            hienthi();
            string masoxe1 = txtmaxe.Text;
            string dongia1 = txtdongia.Text;
            string loaixe1 = cb.Text;
            string tinhtrang1 = cbotinhtrang.Text;

            DateTime thoigiannhan = Convert.ToDateTime(dtpngaybatdau.Text);
            DateTime thoigiantra = Convert.ToDateTime(dtpngaykethuc.Text);

            string sqlUpdate = "UPDATE tblBaixe SET loaixe = N'" + loaixe1 + "',trangthaixe = N'" + tinhtrang1 + "', dongia = '" + dongia1 + "',thoigiannhan = '" + thoigiannhan + "',thoigiantra = '" + thoigiantra + "' WHERE masoxe='" + masoxe1 + "'";
            ham.CapNhat(sqlUpdate, conn);

            ham.HienthiDulieuDG(dataGridView1, "SELECT * FROM tblBaixe", conn);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //listView1.Items.Clear();
            //ketnoi.Open();
            //sql = @"Delete FROM tblBaixe Where (masoxe = N'"+txtmaxe.Text+@"')";
            //thuchien = new SqlCommand(sql, ketnoi);
            //thuchien.ExecuteNonQuery();
            //ketnoi.Close();
            //hienthi();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int r = dataGridView1.CurrentCell.RowIndex;
                    string mahv = dataGridView1.Rows[r].Cells[1].Value.ToString();

                    ;
                    string sql = "DELETE FROM tblBaixe WHERE masoxe = '" + mahv + "'";


                    ham.CapNhat(sql, conn);

                    ham.HienthiDulieuDG(dataGridView1, "SELECT * FROM tblBaixe", conn);
                    MessageBox.Show("Xóa thành công.", "Thông báo");


                }
                else if (dialogResult == DialogResult.No)
                {
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn một hàng để xóa.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult f = MessageBox.Show("Ban co that su muon thoat ?", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if ( f == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }    
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form3 = new Form2();
            form3.Show();
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            THONGKE form1 = new THONGKE();
                form1.Show();
        }

        private void txtmaxe_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button7_Click(object sender, EventArgs e)
        {
          

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                string maxe = row.Cells["masoxe"].Value.ToString();
                string dongia = row.Cells["dongia"].Value.ToString();
                string loaixe = row.Cells["loaixe"].Value.ToString();
                string trangthai = row.Cells["trangthaixe"].Value.ToString();
                string thoigiannhan = row.Cells["thoigiannhan"].Value.ToString();
                string thoigiantra = row.Cells["thoigiantra"].Value.ToString();


                txtdongia.Text = dongia;
                txtmaxe.Text = maxe;
                cb.Text= loaixe;
                cbotinhtrang.Text= trangthai;
                dtpngaybatdau.Text = thoigiannhan;
                dtpngaykethuc.Text = thoigiantra;
               



            }
        }

        
    }
}
