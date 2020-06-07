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

namespace WindowsFormsApp1
{
    public partial class TrangThai : Form
    {
        public TrangThai()
        {
            InitializeComponent();
            dataGridView1.Visible= false;
        }
        private bool kt()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            { 
                textBox1.Focus();
                return false;
            }
            return true;
        }

        private bool tt()
        {
            if (!kt()) return false;
            using (SqlConnection con = new SqlConnection(Dataconnection.connectionstring))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TinhTrangGiao";
                cmd.Parameters.Add(new SqlParameter("@MaDon", textBox1.Text));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    
                    if (reader.HasRows)
                    {
                        con.Close();
                        dataGridView1.DataSource = dt;
                        dataGridView1.Visible = true;
                        return true;
                    }
                    else
                    {
                        con.Close();
                        MessageBox.Show("Don khong ton tai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tt();
        }
    }
}
