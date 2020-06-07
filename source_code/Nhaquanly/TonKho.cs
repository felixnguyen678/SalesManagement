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
    public partial class TonKho : Form
    {
        public TonKho()
        {
            InitializeComponent();
        }
        private void laydata()
        {
            using (SqlConnection con1 = new SqlConnection(Dataconnection.connectionstring))
            {

                con1.Open();
                String sql = "select a.id_daily, a.id_sanpham, a.soluong from CHITIETHANG_DAILY a";
                SqlCommand cmd = new SqlCommand(sql, con1);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con1.Close();
                dataGridView1.DataSource = dt;
            }
        }
        private void TonKho_Load(object sender, EventArgs e)
        {
            laydata();
        }
    }
}
