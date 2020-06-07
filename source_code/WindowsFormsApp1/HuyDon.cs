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
    public partial class HuyDon : Form
    {
        public HuyDon()
        {
            InitializeComponent();
        }
        private int huy()
        {
            int a = -1;
            using (SqlConnection con = new SqlConnection(Dataconnection.connectionstring))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_HuyDon", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MaDon", SqlDbType.VarChar).Value = textBox1.Text;

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
            if (huy() > 0)
                MessageBox.Show("Huy thanh cong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Huy that bai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
