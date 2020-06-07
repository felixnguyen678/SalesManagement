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
    public partial class ThemVaoGio : Form
    {
        public ThemVaoGio()
        {
            InitializeComponent();
        }
        private int them()
        {
            int a = -1;
            using (SqlConnection con = new SqlConnection(Dataconnection.connectionstring))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_ThemVaoGio", con);
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
            if (them() > 0)
                MessageBox.Show("Them thanh cong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Them that bai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
