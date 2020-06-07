using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Initialtimkiem : Form
    {
        public Initialtimkiem()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            timkiemsanphambanchaynhat a = new timkiemsanphambanchaynhat();
            a.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tim a = new tim();
            a.ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            timkiemtheoloaihang a = new timkiemtheoloaihang();
            a.ShowDialog();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            timkiemtheohang a = new timkiemtheohang();
            a.ShowDialog();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            timkiemtheogiatien a = new timkiemtheogiatien();
            a.ShowDialog();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            timkiemsanphamkhuyenmai a = new timkiemsanphamkhuyenmai();
            a.ShowDialog();
        }
    }
}
