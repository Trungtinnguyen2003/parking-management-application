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
using System.IO;


namespace nl
{
    public partial class Form3 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=Nienluan;Integrated Security=True");
        public Form3()
        {
            InitializeComponent();
            LoadData();
        }

       


        void LoadData()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from HinhAnh", conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if(open.ShowDialog() == DialogResult.OK){
                pictureBox1.Image = Image.FromFile(open.FileName);
                this.Text = open.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //byte[] b = ImageToByteArray(pictureBox1.Image);
            byte[] b = PathToByteArray(this.Text);
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into HinhAnh values(@ten, @hinh)", conn);
            cmd.Parameters.Add("@ten", txtTenHinh.Text);
            cmd.Parameters.Add("@hinh", b);
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadData();
        }

        // chuyển image sang byte[]
        byte[] ImageToByteArray(Image img){
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }
        // chuyển file sang image
        byte[] PathToByteArray(string path){
            //MemoryStream m = new MemoryStream();
            //Image img = Image.FromFile(path);
            //img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            //return m.ToArray();

            //có thể dùng classFile để chuyển
            return File.ReadAllBytes(path);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            txtTenHinh.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
            byte[] b = (byte[])dataGridView1.Rows[r].Cells[1].Value;
            pictureBox2.Image = ByteArrayToImage(b);
        }

        //chuyển từ byte[] sang image để gán cho pictucebox2
        Image ByteArrayToImage(byte[] b)
        {
            MemoryStream m = new MemoryStream(b);
            return Image.FromStream(m);
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
