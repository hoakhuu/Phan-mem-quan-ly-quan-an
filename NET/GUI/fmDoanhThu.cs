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
    public partial class fmDoanhThu : Form
    {
        public fmDoanhThu()
        {
            InitializeComponent();
        }

        private void fmDoanhThu_Load(object sender, EventArgs e)
        {
            loadthang();
            loadDT();

        }

        void loadDT()
        {
            BUS.HoaDon_BUS h = new BUS.HoaDon_BUS();
            dtgvDT.DataSource = h.DoanhThu();

        }
        void loadthang()
        {
            cbMto.Items.Add("1");
            cbMto.Items.Add("2");
            cbMto.Items.Add("3");
            cbMto.Items.Add("4");
            cbMto.Items.Add("5");
            cbMto.Items.Add("6");
            cbMto.Items.Add("7");
            cbMto.Items.Add("8");
            cbMto.Items.Add("9");
            cbMto.Items.Add("10");
            cbMto.Items.Add("11");
            cbMto.Items.Add("12");
        }

        private void dtgvDT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            BUS.HoaDon_BUS h = new BUS.HoaDon_BUS();
            dtgvDT.DataSource = h.DoanhThu(cbMto.Text);
        }
    }
}
