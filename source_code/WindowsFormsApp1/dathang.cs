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
    public partial class dathang : Form
    {
        public dathang()
        {
            InitializeComponent();
        }
        private bool checkdata()
        {
            if (string.IsNullOrEmpty(textMKhach.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mã Khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textMKhach.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textNVien.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mã Nhân Viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textNVien.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textTen.Text))
            {
                MessageBox.Show("Bạn chưa nhập Tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textTen.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textSDT.Text))
            {
                MessageBox.Show("Bạn chưa nhập Số Điện Thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textSDT.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textTinh.Text))
            {
                MessageBox.Show("Bạn chưa nhập Tỉnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textTinh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textHuyen.Text))
            {
                MessageBox.Show("Bạn chưa nhập Huyện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textHuyen.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textXa.Text))
            {
                MessageBox.Show("Bạn chưa nhập Xã", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textXa.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textDiaChi.Text))
            {
                MessageBox.Show("Bạn chưa nhập Địa Chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textDiaChi.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textLoaiDC.Text))
            {
                MessageBox.Show("Bạn chưa nhập Loại Địa Chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textLoaiDC.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textHTGH.Text))
            {
                MessageBox.Show("Bạn chưa nhập Hình Thức Giao Hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textHTGH.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textHTTT.Text))
            {
                MessageBox.Show("Bạn chưa nhập Hình Thức Thanh Toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textHTTT.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textPhuPhi.Text))
            {
                MessageBox.Show("Bạn chưa nhập Phụ Phí", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textPhuPhi.Focus();
                return false;
            }
            return true;
        }

        private bool dathangq()
        {
            using (SqlConnection con1 = new SqlConnection(Dataconnection.connectionstring))
            {

                con1.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con1;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_DatHang";
                if (checkdata())
                {
                    try
                    {
                        cmd.Parameters.Add(new SqlParameter("@MaKhach", textMKhach.Text));
                        cmd.Parameters.Add(new SqlParameter("@Ma_NV", textNVien.Text));
                        cmd.Parameters.Add(new SqlParameter("@ten", textTen.Text));
                        cmd.Parameters.Add(new SqlParameter("@sdt", Convert.ToInt32(textSDT.Text)));
                        cmd.Parameters.Add(new SqlParameter("@tinh", textTinh.Text));
                        cmd.Parameters.Add(new SqlParameter("@huyen", textHuyen.Text));
                        cmd.Parameters.Add(new SqlParameter("@Xa", textXa.Text));
                        cmd.Parameters.Add(new SqlParameter("@diachi", textDiaChi.Text));
                        cmd.Parameters.Add(new SqlParameter("@loai", textLoaiDC.Text));
                        cmd.Parameters.Add(new SqlParameter("@Thanhtoan", textHTTT.Text));
                        cmd.Parameters.Add(new SqlParameter("@Giao", textHTGH.Text));
                        cmd.Parameters.Add(new SqlParameter("PhuPhi", Convert.ToInt32(textPhuPhi.Text)));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            {
                                if (reader.HasRows)
                                {
                                    con1.Close();
                                    return true;
                                }
                                else
                                {
                                    con1.Close();
                                    MessageBox.Show("Bạn chưa đăng kí khách hàng hoặc chưa chọn hàng để mua", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return false;
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        con1.Close();
                        return false;
                    }
                }
                else
                {
                    con1.Close();
                    return false;
                }
            }   
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool k = dathangq();
            if (k == true)
            {
                MessageBox.Show("Bạn Đã đặt hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
