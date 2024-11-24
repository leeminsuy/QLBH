using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlykhachsan12345
{
    public partial class Dangnhap1 : Form
    {
        public Dangnhap1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dangnhap1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (texttaikhoan.Text == "admin" && textmatkhau.Text == "admin")
            {
                fromchinh ds = new fromchinh();

                this.Hide();
                ds.Show();



            }

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();// bấm thoát ct
        }

        private void texttaikhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void textmatkhau_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
