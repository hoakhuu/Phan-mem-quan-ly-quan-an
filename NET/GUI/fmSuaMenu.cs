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
    public partial class fmSuaMenu : Form
    {
        public fmSuaMenu()
        {
            InitializeComponent();

        }

        public fmSuaMenu(string tenmon, string thanhtien, string danhmuc, string hinh)
        {
            InitializeComponent();
            this.tenmon = tenmon;
            this.thanhtien = thanhtien;
            this.danhmuc = danhmuc;
            this.hinh = hinh;
        }

        string tenmon;
        string thanhtien;
        string danhmuc;
        string hinh;

        public string Tenmon { get => tenmon; set => tenmon = value; }
        public string Thanhtien { get => thanhtien; set => thanhtien = value; }
        public string Danhmuc { get => danhmuc; set => danhmuc = value; }
        public string Hinh { get => hinh; set => hinh = value; }

        private void fmSuaMenu_Load(object sender, EventArgs e)
        {
            lbTenMon.Text= tenmon;
            lbDongia.Text= thanhtien;
            lbDanhMuc.Text= danhmuc;
            pictureBox1.Image = Image.FromFile(@"..\Resources\" + hinh);
            loadDanhMuc();
        }

        void loadDanhMuc()
        {
            BUS.DanhMuc_BUS d = new BUS.DanhMuc_BUS();
            DataTable table = new DataTable();
            table = d.DanhMuc();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                cbDM.Items.Add(table.Rows[i]["Tenloai"].ToString());
            }
        }


        string namePic = "";
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName;

                fileName = dlg.FileName;
                string[] tenhinh = fileName.Split(@"\");
                namePic = tenhinh[tenhinh.Length - 1];

              
                pictureBox2.Image = Image.FromFile(@"..\Resources\" + namePic);
               
            }
        }

        private void txtDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            BUS.OrderMon_BUS o =new BUS.OrderMon_BUS();

           string idmon= o.LayMaMon(lbTenMon.Text);
            BUS.Menu_BUS m = new BUS.Menu_BUS();
            string maloai = m.LayidLoai(cbDM.Text);

            o.suamon(idmon, txtTenmon.Text, txtDonGia.Text, namePic, maloai);
            MessageBox.Show("Chỉnh sửa thành công");
            this.Close();
        }
    }
}
