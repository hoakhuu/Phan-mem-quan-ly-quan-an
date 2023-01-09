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
    public partial class fmFixMenu : Form
    {
        public fmFixMenu()
        {
            InitializeComponent();
        }

        private void fmFixMenu_Load(object sender, EventArgs e)
        {
            loadDanhMuc();
        }


        void loadDanhMuc()
        {
            BUS.DanhMuc_BUS d = new BUS.DanhMuc_BUS();
            DataTable table = new DataTable();
            table = d.DanhMuc();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                cbDanhMuc.Items.Add(table.Rows[i]["Tenloai"].ToString());
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

                //BUS.Menu_BUS m=new BUS.Menu_BUS();
                //string idmon = m.tnagMaMon();
                //m.AddMenu(idmon, txtTenMon.Text, txtDonGia.Text, namePic, cbDanhMuc.Text);
                pictureBox1.Image = Image.FromFile(@"..\Resources\" + namePic);
                //this.Controls.Clear();
                //this.InitializeComponent();
                //MessageBox.Show(tenhinh[tenhinh.Length-1]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BUS.Menu_BUS m = new BUS.Menu_BUS();
            string idmon = m.tnagMaMon();


            string idloai = m.LayidLoai(cbDanhMuc.Text);
            m.AddMenu(idmon, txtTenMon.Text, txtDonGia.Text, namePic, idloai);
            MessageBox.Show("Thêm món ăn thành công");
            this.Close();
        }

        private void cbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
