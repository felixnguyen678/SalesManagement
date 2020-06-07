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
    public partial class DoiNoiGiao : Form
    {
        public DoiNoiGiao()
        {
            InitializeComponent();
        }
        private int doi()
        {
            int a = -1;
            using (SqlConnection con = new SqlConnection(Dataconnection.connectionstring))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_DoiNoiGiao", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MaDon", SqlDbType.VarChar).Value = Md.Text;
                    cmd.Parameters.Add("@ten", SqlDbType.VarChar).Value = ten.Text;
                    cmd.Parameters.Add("@sdt", SqlDbType.Int).Value = Convert.ToInt32(dt.Text);
                    cmd.Parameters.Add("@tinh", SqlDbType.VarChar).Value = tinh.Text;
                    cmd.Parameters.Add("@huyen", SqlDbType.VarChar).Value = huyen.Text;
                    cmd.Parameters.Add("@xa", SqlDbType.VarChar).Value = phuong.Text;
                    cmd.Parameters.Add("@diachi", SqlDbType.VarChar).Value = dc.Text;
                    cmd.Parameters.Add("loai", SqlDbType.VarChar).Value = loai.Text;

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
            if (doi() > 0)
                MessageBox.Show("Doi thanh cong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Doi that bai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
