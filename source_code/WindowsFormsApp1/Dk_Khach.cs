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
    public partial class Dk_Khach : Form
    {
        public Dk_Khach()
        {
            InitializeComponent();
        }
        private int dk()
        {
            int a = -1;
            using (SqlConnection con = new SqlConnection(Dataconnection.connectionstring))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_Dk_Khach", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@tenKhachHang", SqlDbType.VarChar).Value = textBox1.Text;
                    cmd.Parameters.Add("@sdt", SqlDbType.Int).Value = Convert.ToInt32(textBox2.Text);
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = textBox3.Text;
                    cmd.Parameters.Add("@gioitinh", SqlDbType.VarChar).Value = comboBox1.Text;
                    cmd.Parameters.Add("@NS", SqlDbType.DateTime).Value = dateTimePicker1.Text;

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
            if (dk() > 0)
                MessageBox.Show("Dang ky thanh cong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Dang ky that bai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
