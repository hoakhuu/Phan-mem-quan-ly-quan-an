using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NET.GUI
{
    public partial class fmDangNhap : Form
    {
        public fmDangNhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BUS.NhanVien_BUS nv = new BUS.NhanVien_BUS();
            string manv = nv.LoginNV(txtDN.Text, txtMK.Text);
            
            if(manv!="")
            {
                fmTrangChu fm = new fmTrangChu(txtDN.Text, txtMK.Text, manv);
                this.Hide();
                fm.ShowDialog();

            }
            else if(txtDN.Text=="admin" && txtMK.Text=="123")
            {
                fmTrangChu fm = new fmTrangChu(txtDN.Text, txtMK.Text,"0");
                this.Hide();
                fm.ShowDialog();
            }
            else if(manv=="")
            {
                
                MessageBox.Show("Mật khẩu sai!");
            }


               
               
            
            
        }

        private void fmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
