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
namespace Nhaquanly
{
    public partial class theodoidoanhthu : Form
    {
        public theodoidoanhthu()
        {
            InitializeComponent();
        }
        private void laydata()
        {
            using (SqlConnection con1 = new SqlConnection(Dataconnection.connectionstring))
            {

                con1.Open();
                String sql = "select a.id_nguoiban,a.id_daily, SUM(dongia) as TONGDOANHTHU from DAILY a, CHITIETHANG_DAILY b, CHITIETDONHANG c where a.id_daily = b.id_daily and b.id_sanpham = c.id_sanpham group by a.id_nguoiban, a.id_daily";
                SqlCommand cmd = new SqlCommand(sql, con1);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con1.Close();
                dataGridView1.DataSource = dt;
            }
        }

        private void theodoidoanhthu_Load(object sender, EventArgs e)
        {
            laydata();
        }
    }
}
