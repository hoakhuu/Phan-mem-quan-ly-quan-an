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
    public partial class fmChon : Form
    {
        string name;
        string numb;
        public fmChon()
        {
            InitializeComponent();
        }

        public fmChon(string tenkh, string soban)
        {
            InitializeComponent();
            this.name = tenkh;
            this.numb = soban;
            
        }


        public string Name1 { get => name; set => name = value; }
        public string Numb { get => numb; set => numb = value; }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            BUS.OrderMon_BUS or = new BUS.OrderMon_BUS();
            string soban=or.LayidBan(lbSobanHuy.Text);
            BUS.khachhang_BUS khh = new BUS.khachhang_BUS();
            string kh = khh.LayIDKhachHanh(lbtenKh.Text);
            BUS.BanAn_BUS ba=new BUS.BanAn_BUS();
            ba.xoaDatBan(soban);
            this.Close();
        }

        private void fmCancel_Load(object sender, EventArgs e)
        {
            lbSobanHuy.Text = numb;
            lbtenKh.Text = name;
            lbTrangThai.Text = "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BUS.OrderMon_BUS or = new BUS.OrderMon_BUS();
            string soban = or.LayidBan(lbSobanHuy.Text);
            BUS.BanAn_BUS khh = new BUS.BanAn_BUS();
            khh.UpTrangThai(soban);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
