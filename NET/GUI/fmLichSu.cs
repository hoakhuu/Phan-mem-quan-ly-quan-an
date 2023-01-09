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
    public partial class fmLichSu : Form
    {
        public fmLichSu()
        {
            InitializeComponent();
        }

        private void fmLichSu_Load(object sender, EventArgs e)
        {
            loadLS();
        }

        void loadLS()
        {
            BUS.HoaDon_BUS h = new BUS.HoaDon_BUS();
            dtgvLS.DataSource = h.LichSuGiaoDich();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BUS.HoaDon_BUS h = new BUS.HoaDon_BUS();
            dtgvLS.DataSource = h.LichSuGiaoDichFromTo(mskTo.Text, mskFrom.Text);
        }
    }
}
