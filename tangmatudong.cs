﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace nl
{
    class tangmatudong
    {
        
        
            public void Ketnoi(SqlConnection conn)
            {
                string chuoiketnoi = @"Data Source=DESKTOP-R7KETFC\SQLEXPRESS;Initial Catalog=Nienluan;Integrated Security=True";
            conn.ConnectionString = chuoiketnoi;
                conn.Open();

            }

            public void HienthiDulieuDG(DataGridView dg, string sql, SqlConnection conn)
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset, "new table");
                dg.DataSource = dataset;
                dg.DataMember = "new table";

            }


            public void LoadComb(ComboBox comb, string sql, SqlConnection conn, string hienthi, string giatri)
            {
                SqlCommand comd = new SqlCommand(sql, conn);
                SqlDataReader reader = comd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);

                comb.DataSource = table;
                comb.DisplayMember = hienthi;
                comb.ValueMember = giatri;
                reader.Close();
            }
            public void CapNhat(string sql, SqlConnection conn)
            {
                SqlCommand comd = new SqlCommand(sql, conn);
                try
                {
                    comd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Your  query is: " + sql + " With the error is: " + e.Message);
                }

            }
        }
    }


