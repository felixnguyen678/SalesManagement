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
    public partial class ThanhToan : Form
    {
        public ThanhToan()
        {
            InitializeComponent();
        }
        private int Thanh_toan()
        {
            int a = -1;
            using (SqlConnection con = new SqlConnection(Dataconnection.connectionstring))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_ThanhToan", con);
                    cmd.CommandType = CommandType.StoredProcedure;                   

                    cmd.Parameters.Add("@MaDon", SqlDbType.VarChar).Value = textBox1.Text;
                    cmd.Parameters.Add("@MaHang", SqlDbType.VarChar).Value = textBox2.Text;
                    if (string.IsNullOrEmpty(textBox3.Text))
                        cmd.Parameters.Add("@SoSao", SqlDbType.Int).Value = a;
                    else
                        cmd.Parameters.Add("@SoSao", SqlDbType.Int).Value = Convert.ToInt32(textBox3.Text);
                    cmd.Parameters.Add("@DG", SqlDbType.VarChar).Value = textBox4.Text;
                    cmd.Parameters.Add("@DGCT", SqlDbType.VarChar).Value = textBox5.Text;

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
            if ((Thanh_toan()) > 0)
                MessageBox.Show("Da giao hang va thanh toan", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Thay doi that bai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
