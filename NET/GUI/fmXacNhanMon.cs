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
    public partial class fmXacNhanMon : Form
    {
        string datmon;
        int sl;
        string hinh;
        int dg;
        int tt;
        string ban;
        string idnv;
        public fmXacNhanMon()
        {
            InitializeComponent();
        }

        public fmXacNhanMon(string datmon, int dg, string sb,string manv)
        {
            InitializeComponent();
            this.datmon = datmon;
            this.dg = dg;
            this.Idnv = manv;
            this.Ban = sb;
        }

      
        public string Datmon { get => datmon; set => datmon = value; }
        public int Sl { get => sl; set => sl = value; }
        public string Hinh { get => hinh; set => hinh = value; }
        public int Dg { get => dg; set => dg = value; }
        public int Tt { get => tt; set => tt = value; }
        public string Ban { get => ban; set => ban = value; }
        public string Idnv { get => idnv; set => idnv = value; }

        private void fmXacNhanMon_Load(object sender, EventArgs e)
        {
            lbTenMon.Text = Datmon;
            lbDongia.Text = Dg.ToString();
            lbban.Text = Ban;
            BUS.OrderMon_BUS f= new BUS.OrderMon_BUS();
            string hinh=f.loadhinh(lbTenMon.Text);
            pictureBox1.Image= Image.FromFile(@"..\Resources\" + hinh);

        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {

            int kq = int.Parse(lbDongia.Text) * int.Parse(txtSL.Text);
            lbThanhTien.Text = kq.ToString();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }


       

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            //ktra mã hóa đơn của bàn đó đã có hay chưa
            BUS.OrderMon_BUS b = new BUS.OrderMon_BUS();
          
            //Insert

            DataTable table = new DataTable();
            table = b.KTRMaHD();
            int flag = 0;
            string maban = b.MaHDofBan(lbban.Text);
            string mamon = b.LayMaMon(lbTenMon.Text);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string mhd = table.Rows[i]["Mahd"].ToString();
                if (mhd == maban)
                {
                    BUS.OrderMon_BUS o = new BUS.OrderMon_BUS();

                    string matang = o.MaCTHDdec();

                    b.insertCTHD(txtSL.Text, lbThanhTien.Text, mamon, mhd,matang);
                    flag = 1;
                    break;


                }
            }
            if (flag == 0)
            {
                string idban = b.LayidBan(lbban.Text);

                string mahd = b.MaHDdec();
                //Tạo Hóa đơn
                b.insertHH(mahd, idban,idnv);

                //Tạo Chi tiết hóa đơn
                BUS.OrderMon_BUS o = new BUS.OrderMon_BUS();

                string matang = o.MaCTHDdec();

                b.insertCTHD(txtSL.Text, lbThanhTien.Text, mamon, mahd,matang);
                //string a="btn"
                //if()//Lóoad màu trạng thái.

             }

            MessageBox.Show("Đã đặt thành công");
            this.Close();

        }

        private void btnHuyDat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
