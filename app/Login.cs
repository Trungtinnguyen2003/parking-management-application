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
    public partial class Login : Form
    {
        public SqlConnection conn = new SqlConnection();
        tangmatudong ham = new tangmatudong();


        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            ham.Ketnoi(conn);
          //  ham.LoadComb(chucnang, "SELECT  tenTK,vaiTro FROM TAI_KHOAN ", conn, "vaiTro", "tenTK");
        }

        private void thoat(object sender, EventArgs e)
        {
            this.Close();
        }
       

        private void guna2Button1_Click(object sender, EventArgs e)
        {
        string tendn = txtUser.Text;
           string pass =guna2TextBox1.Text;
            string sql_dn = "SELECT taikhoan, password FROM dangnhap WHERE taikhoan = '" + tendn + "' AND password ='" + pass + "'";
            SqlCommand comd = new SqlCommand(sql_dn, conn);
            SqlDataReader reader = comd.ExecuteReader();
            if (reader.Read())
            {
                Form1 fmQL = new Form1();
                fmQL.Show();
            }
            else
            {
                MessageBox.Show("Thất Bại");
            }
            reader.Close();
        }

        private void F_DangXuat(object sender, EventArgs e)
        {
            (sender as Form1).isThoat=false;
            (sender as Form1).Close();
           // throw new NotImplementedException();
            this.Show();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }




