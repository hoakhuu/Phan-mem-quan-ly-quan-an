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
    public partial class fmFirst : Form
    {
        public fmFirst()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fmDangNhap f=new fmDangNhap();
            this.Hide();
            f.ShowDialog();
        }
    }
}
