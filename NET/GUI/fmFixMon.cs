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
    public partial class fmFixMon : Form
    {
        public fmFixMon()
        {
            InitializeComponent();
        }

        public fmFixMon(string sl, string tenmon, string thanhtien, string soban, string dongia,string idd)
        {
            InitializeComponent();
            this.sl = sl;
            this.tenmon = tenmon;
            this.thanhtien = thanhtien;
            this.soban = soban;
            this.dongia = dongia;
            this.id = idd;
        }


        string sl;
        string tenmon;
        string thanhtien;
        string soban;
        string dongia;
        string id;

        public string Sl { get => sl; set => sl = value; }
        public string Tenmon { get => tenmon; set => tenmon = value; }
        public string Thanhtien { get => thanhtien; set => thanhtien = value; }
        public string Soban { get => soban; set => soban = value; }
        public string Dongia { get => dongia; set => dongia = value; }
        public string Id { get => id; set => id = value; }

        private void FixMon_Load(object sender, EventArgs e)
        {

            lbDongia.Text = Dongia;
            lbSoBaninfor.Text = Soban;
            lbTenMon.Text = Tenmon;
            lbThanhTien.Text = Thanhtien;
            lbslbd.Text = Sl;
            lbID.Text = Id;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            BUS.OrderMon_BUS m=new BUS.OrderMon_BUS();
           
            m.dropMon(lbID.Text);
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BUS.OrderMon_BUS m = new BUS.OrderMon_BUS();
            m.updateSL(lbID.Text, txtsl.Text,lbThanhTien.Text);
            this.Close();
        }

        private void txtsl_TextChanged(object sender, EventArgs e)
        {
            lbThanhTien.Text=(int.Parse(lbDongia.Text)*int.Parse(txtsl.Text)).ToString();
        }

        private void txtsl_TextChanged_1(object sender, EventArgs e)
        {
            lbThanhTien.Text = (int.Parse(lbDongia.Text) * int.Parse(txtsl.Text)).ToString();
        }
    }
}
