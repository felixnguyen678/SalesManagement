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
    public partial class timkiemsanphambanchaynhat : Form
    {
        public timkiemsanphambanchaynhat()
        {
            InitializeComponent();
        }
        private void laydata()
        {
            using (SqlConnection con1 = new SqlConnection(Dataconnection.connectionstring))
            {

                con1.Open();
                String sql = "SELECT dbo.SANPHAM.tensanpham,dbo.CHITIETDONHANG.id_sanpham FROM dbo.SANPHAM  JOIN dbo.CHITIETDONHANG  ON SANPHAM.id_sanpham=CHITIETDONHANG.id_sanpham GROUP BY dbo.CHITIETDONHANG.id_sanpham,dbo.SANPHAM.tensanpham HAVING SUM(dbo.CHITIETDONHANG.soluong) >= ALL(SELECT SUM(dbo.CHITIETDONHANG.soluong) FROM dbo.CHITIETDONHANG GROUP BY dbo.CHITIETDONHANG.id_sanpham)";
                SqlCommand cmd = new SqlCommand(sql, con1);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con1.Close();
                dataGridView1.DataSource = dt;
            }
        }

        private void timkiemsanphambanchaynhat_Load(object sender, EventArgs e)
        {
            laydata();
        }


    }

}
