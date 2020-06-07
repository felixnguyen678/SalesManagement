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
    public partial class timkiemtheogiatien : Form
    {
        public timkiemtheogiatien()
        {
            InitializeComponent();
        }
        private bool timkiemtheogia(DataTable dt)
        {
            using (SqlConnection con1 = new SqlConnection(Dataconnection.connectionstring))
            {

                con1.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con1;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "timkiemtheogiatien";
                try
                {
                    if (!string.IsNullOrEmpty(textGia1.Text))
                    {
                        cmd.Parameters.Add(new SqlParameter("@gia1", Convert.ToInt32(textGia1.Text)));
                    }
                    else
                        cmd.Parameters.Add(new SqlParameter("@gia1", DBNull.Value));
                    if (!string.IsNullOrEmpty(textGia2.Text))
                        cmd.Parameters.Add(new SqlParameter("@gia2", Convert.ToInt32(textGia2.Text)));
                    else
                        cmd.Parameters.Add(new SqlParameter("@gia2", DBNull.Value));
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
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            bool k = timkiemtheogia(dt);
            dataGridView1.DataSource = dt;
         }
    }
}
