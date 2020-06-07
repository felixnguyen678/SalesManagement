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
    public partial class HuyDat_1_SP : Form
    {
        public HuyDat_1_SP()
        {
            InitializeComponent();
        }

        private bool ktra()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mã đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Bạn chưa nhập số lượng hủy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return false;
            }
            return true;
        }

        private void Huy()
        {
            using (SqlConnection con1 = new SqlConnection(Dataconnection.connectionstring))
            {

                con1.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con1;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_HuyDat_1_sp";
                if (ktra())
                {
                    try
                    {
                        cmd.Parameters.Add(new SqlParameter("@MaDon", textBox1.Text));
                        cmd.Parameters.Add(new SqlParameter("@MaSP", textBox2.Text));
                        cmd.Parameters.Add(new SqlParameter("@soLuongHuy", Convert.ToInt32(textBox3.Text)));

                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: " + e);
                        Console.WriteLine(e.StackTrace);
                    }
                    finally
                    {
                        con1.Close();
                        con1.Dispose();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Huy();
        }
    }
}

