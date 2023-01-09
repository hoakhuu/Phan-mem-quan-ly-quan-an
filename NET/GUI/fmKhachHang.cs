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
    public partial class fmKhachHang : Form
    {
        public fmKhachHang()
        {
            InitializeComponent();
        }
        string num;
        string id;

        public string Num { get => num; set => num = value; }
        public string Id { get => id; set => id = value; }

        public fmKhachHang( string num, string id)
        {
            InitializeComponent();
            this.Num = num;
            this.Id = id;
        }

        private void button3_Click(object sender, EventArgs e)
        {



            BUS.khachhang_BUS b = new BUS.khachhang_BUS();

            //Insert
            b.insertInforKhach(txtKhachHang.Text, txtSDT.Text);

            //update trang thái bàn
            BUS.OrderMon_BUS o = new BUS.OrderMon_BUS();
            string d=o.LayidBan(lbNumT.Text);

            b.updateTrangThai(d, lbCode.Text);
            this.Close();


        }

        private void fmKhachHang_Load(object sender, EventArgs e)
        {
            lbCode.Text = id;
            lbNumT.Text = num;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
