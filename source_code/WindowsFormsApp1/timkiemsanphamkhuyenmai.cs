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
    public partial class timkiemsanphamkhuyenmai : Form
    {
        public timkiemsanphamkhuyenmai()
        {
            InitializeComponent();
        }
        private void laydata()
        {
            using (SqlConnection con1 = new SqlConnection(Dataconnection.connectionstring))
            {

                con1.Open();
                String sql = "SELECT dbo.SANPHAM.id_sanpham,dbo.SANPHAM.tensanpham FROM dbo.SANPHAM WHERE gia <> giagoc";
                SqlCommand cmd = new SqlCommand(sql, con1);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con1.Close();
                dataGridView1.DataSource = dt;
            }
        }

        private void timkiemsanphamkhuyenmai_Load(object sender, EventArgs e)
        {
            laydata();
        }
    }
}
