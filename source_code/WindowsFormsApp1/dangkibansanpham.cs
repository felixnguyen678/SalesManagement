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
    public partial class dangkibansanpham : Form
    {
        public dangkibansanpham()
        {
            InitializeComponent();
        }
        private bool checkdata()
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mã Người Bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mã Sản Phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mã Loại Hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Bạn chưa nhập Hãng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Bạn chưa nhập thông tin chi tiết", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox5.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Bạn chưa nhập Giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox6.Focus();
                return false;
            }
            return true;
        }
        private bool dksp()
        {
            if (checkdata())
            {
                int a = -1;
                using (SqlConnection con = new SqlConnection(Dataconnection.connectionstring))
                {
                    con.Open();
                    try
                    {
                        SqlCommand cmd = new SqlCommand("dangkibansanpham", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id_nguoiban", textBox1.Text));
                        cmd.Parameters.Add(new SqlParameter("@tensanpham", textBox2.Text));
                        cmd.Parameters.Add(new SqlParameter("@id_loaihang", textBox3.Text));
                        cmd.Parameters.Add(new SqlParameter("@hang", textBox4.Text));
                        cmd.Parameters.Add(new SqlParameter("@thongtinchitiet", textBox5.Text));
                        cmd.Parameters.Add(new SqlParameter("@Gia", Convert.ToInt32(textBox6.Text)));
                        a = cmd.ExecuteNonQuery();
                        if (a > 0) return true;
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
                    return false;
                }
            }
            else
                return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool k = dksp();
            if(k==true)
            {
                MessageBox.Show("Đăng kí thành công","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Đăng kí thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
