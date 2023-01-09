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
    public partial class fmThanhToan : Form
    {
        public fmThanhToan()
        {
            InitializeComponent();
        }

        public fmThanhToan(string tenkh, string soban, string sdt)
        {
            InitializeComponent();
            this.tenkh = tenkh;
            this.soban = soban;
            this.sdt = sdt;
        }

        string tenkh;
        string soban;
        string sdt;

        public string Tenkh { get => tenkh; set => tenkh = value; }
        public string Soban { get => soban; set => soban = value; }
        public string Sdt { get => sdt; set => sdt = value; }

        private void fmThanhToan_Load(object sender, EventArgs e)
        {
            lbBan.Text = Soban;
            lbSDT.Text = Sdt;
            lbTenKH.Text = Tenkh;
            BUS.OrderMon_BUS o = new BUS.OrderMon_BUS();
            string idban = o.LayidBan(lbBan.Text);
            BUS.HoaDon_BUS h = new BUS.HoaDon_BUS();
            dtgvThanhToan.DataSource = h.HoaDon(idban);
            lbTong.Text= h.TongTien(idban);
        }

        private void dtgvThanhToan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            BUS.HoaDon_BUS hd = new BUS.HoaDon_BUS();
            string idls=hd.MaMLCdec();
            hd.insertLishSu(idls, lbTenKH.Text, lbTong.Text, lbBan.Text);
            BUS.BanAn_BUS b = new BUS.BanAn_BUS();
            BUS.OrderMon_BUS o = new BUS.OrderMon_BUS();
            string idban=o.LayidBan(lbBan.Text);
            b.XoaTrangThai(idban);

            MessageBox.Show("Hẹn gặp lại quý khách");
            this.Close();
        }
    }
}
