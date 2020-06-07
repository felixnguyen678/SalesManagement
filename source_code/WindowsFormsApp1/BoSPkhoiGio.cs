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
    public partial class BoSPkhoiGio : Form
    {
        public BoSPkhoiGio()
        {
            InitializeComponent();
        }

        private int xoa()
        {
            int a = -1;
            using (SqlConnection con = new SqlConnection(Dataconnection.connectionstring))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_BoSPKhoiGio", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MaKhach", SqlDbType.VarChar).Value = textBox1.Text;
                    cmd.Parameters.Add("@MaSP", SqlDbType.VarChar).Value = textBox2.Text;
                    cmd.Parameters.Add("@soLuong", SqlDbType.Int).Value = Convert.ToInt32(textBox3.Text);

                    a = cmd.ExecuteNonQuery();
                    if (a > 0) return a;
                }
                catch (Exception e)
                {
                    MessageBox.Show(Convert.ToString(e), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return a;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (xoa() > 0)
                MessageBox.Show("Xoa thanh cong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Xoa that bai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
