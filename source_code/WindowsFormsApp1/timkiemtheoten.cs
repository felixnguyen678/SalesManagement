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
    public partial class tim : Form
    {
        public tim()
        {
            InitializeComponent();
        }
        private bool checkdata()
        {
            if (string.IsNullOrEmpty(TextTenSanPham.Text))
            {
                MessageBox.Show("Bạn chưa nhập Tên Sản Phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TextTenSanPham.Focus();
                return false;
            }
            return true;
        }
        private bool timkiemtheoten(DataTable dt)
        {
            using (SqlConnection con1 = new SqlConnection(Dataconnection.connectionstring))
            {

                con1.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con1;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "timkiemtheoten";
                if (checkdata())
                {
                    try
                    {
                        cmd.Parameters.Add(new SqlParameter("@chuoi", TextTenSanPham.Text));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            {
                                if (reader.HasRows)
                                {
                                    dt.Load(reader);
                                    con1.Close();
                                    return true;
                                }
                                else
                                {
                                    con1.Close();
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
            DataTable dt = new DataTable(); 
            bool k = timkiemtheoten(dt);
            dataGridViewtktt.DataSource = dt;
        }
    }
}
