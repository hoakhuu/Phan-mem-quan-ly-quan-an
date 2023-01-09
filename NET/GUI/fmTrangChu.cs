using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NET.BUS;

namespace NET.GUI
{
    public partial class fmTrangChu : System.Windows.Forms.Form
    {
        string dn;
        string mk;
        string mlg;

        public string Dn { get => dn; set => dn = value; }
        public string Mk { get => mk; set => mk = value; }
        public string Mlg { get => mlg; set => mlg = value; }

        public fmTrangChu()
        {
            InitializeComponent();
            if (dn != "admin" && mk != "123")
            {
                quảnLýToolStripMenuItem.Enabled = false;
                MessageBox.Show("Dff");
            }

        }

        public fmTrangChu(string dn, string mk,string mlg)
        {
            InitializeComponent();
            this.dn = dn;
            this.mk = mk;
            this.mlg = mlg;
            if (dn == "admin" && mk == "123")
            {
                quảnLýToolStripMenuItem.Enabled = true;
                lbidnv.Text = "*";
                lbNhanVien.Text = "admin";
            }
            else
            {
                quảnLýToolStripMenuItem.Enabled = false;
                BUS.NhanVien_BUS nv = new BUS.NhanVien_BUS();
                DataTable table = new DataTable();
                table = nv.inforNV(mlg);
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    lbidnv.Text = table.Rows[i]["Manv"].ToString();
                    lbNhanVien.Text= table.Rows[i]["Tennv"].ToString();
                }



            }
        }

        private void fmTrangChu_Load(object sender, EventArgs e)
        {
            
            comboBox1.Items.Add("Bàn đặt trước");
            comboBox1.Items.Add("Bàn đang hoạt động");
            loadTable();
            loadMenu();
            
        }

        void loadMenu()
        {
            BUS.Menu_BUS b = new BUS.Menu_BUS();
            panel1.Controls.Clear();
            DataTable table = new DataTable();
            table = b.getMenu();
            int vttrai = 10;//giá trị trái ban đầu của button (left)
            int vttren = 10;//giá trị trái ban đầu của button (top)
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Button buttonMoi = new Button(); //(2) new mới đối tượng,
                                                 //(3) thêm vào Control của form hiện tại,
                buttonMoi.Left = vttrai; //(4) thông tin vị trí trái (Left)
                buttonMoi.Top = vttren;//(4)thông tin vị trí trên (Top)
                string hinh = table.Rows[i]["Hinh"].ToString();
                buttonMoi.TextAlign = ContentAlignment.BottomCenter;
                buttonMoi.ImageAlign = ContentAlignment.TopCenter;
                buttonMoi.Image = Image.FromFile(@"..\Resources\" + hinh);
                //buttonMoi.Image = MyProject.Properties.Resources.
                string tenn = table.Rows[i]["Tenmon"].ToString();
                string dg = table.Rows[i]["DonGia"].ToString();
                buttonMoi.Text = dg + '\n' + tenn;
                buttonMoi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;

                buttonMoi.Name = "btnMon" + tenn; //(5) tên button mới
                                                  //(6) Kích thước button mới
                buttonMoi.Size = new System.Drawing.Size(180, 180);


                string trangthai = table.Rows[i]["TrangThai"].ToString();

                if (trangthai == "Còn")
                {
                    buttonMoi.BackColor = System.Drawing.Color.Blue;
                }
                else
                {
                    buttonMoi.BackColor = System.Drawing.Color.GreenYellow;
                }



                if ((i + 1) % 5 != 0)
                {
                    vttrai = vttrai + 190; //Moi button cach nhau 10
                                           //(chiều cao =20 + khoảng cách =10)
                }
                else if ((i + 1) % 5 == 0)
                {

                    vttrai = 10;
                    vttren += 190;
                }

                panel1.Controls.Add(buttonMoi);
                buttonMoi.Click += new EventHandler(buttonMenu_Click);
            }

        }


        void loadTable()
        {
            BUS.BanAn_BUS b = new BUS.BanAn_BUS();
            panel2.Controls.Clear();
            DataTable table = new DataTable();
            table = b.getDataTTBanDat();
            int vttrai = 10;//giá trị trái ban đầu của button (left)
            int vttren = 10;//giá trị trái ban đầu của button (top)
            for (int i = 0; i < table.Rows.Count; i++)
            {

                Button buttonMoi = new Button(); //(2) new mới đối tượng,

                buttonMoi.Left = vttrai; //(4) thông tin vị trí trái (Left)
                buttonMoi.Top = vttren;//(4)thông tin vị trí trên (Top)
                string tenn = table.Rows[i]["SoBan"].ToString();
                buttonMoi.Name = "btnBan" + tenn; //(5) tên button mới
                                                  //(6) Kích thước button mới
                string ss = buttonMoi.Name;


                buttonMoi.Size = new System.Drawing.Size(100, 40);
                string trangthai = table.Rows[i]["TrangThai"].ToString();
                if (trangthai == "1")
                {
                    buttonMoi.BackColor = System.Drawing.Color.Red;
                }
                else if (trangthai == "2")
                {
                    buttonMoi.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    buttonMoi.BackColor = System.Drawing.Color.Yellow;
                }
                buttonMoi.Text = tenn;
                if ((i + 1) % 3 != 0)
                {
                    vttrai = vttrai + 100; //Moi button cach nhau 10
                                           //(chiều cao =20 + khoảng cách =10)
                }
                else if ((i + 1) % 3 == 0)
                {
                    vttrai = 10;
                    vttren += 60;
                }

                panel2.Controls.Add(buttonMoi); //(3) thêm vào Control của form hiện tại,
                buttonMoi.Click += new EventHandler(buttonMoi_Click);
            }

        }


        private void buttonMoi_Click(object sender, EventArgs e)
        {
            lbSoBan.Text = ((Button)sender).Text;
            BUS.BanAn_BUS b = new BUS.BanAn_BUS();
            
            DataTable table = new DataTable();
            table = b.loadInforBan(lbSoBan.Text);
            int flagg = 1;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string trangthai = table.Rows[i]["TrangThai"].ToString();
                if (trangthai == "1")
                {
                    label1.Text = "Bàn đã đạt";
                    flagg = 0;
                    BUS.OrderMon_BUS or = new OrderMon_BUS();
                    string id=or.LayidBan(lbSoBan.Text);

                    BUS.khachhang_BUS kh = new BUS.khachhang_BUS();
                    string tenkh=kh.LayTenKH_TruyenSB(id);

                    
                    fmChon c = new fmChon(tenkh,lbSoBan.Text);
                    c.Hide();
                    c.ShowDialog();

                    loadTable();
                }
                else if (trangthai == "2")
                {
                    label1.Text = "Đang hoạt động";

                    BUS.OrderMon_BUS d = new BUS.OrderMon_BUS();
                    string idTable= d.LayidBan(lbSoBan.Text);
                    BUS.HoaDon_BUS hd = new HoaDon_BUS();
                   datagvHoaDon.DataSource = hd.CTHoaDon(idTable);
                    flagg = 0;
                }
                
            }
            if(flagg==1)
            {
                label1.Text = "Bàn trống";
                
                BUS.OrderMon_BUS ore= new BUS.OrderMon_BUS();

                string layso = lbSoBan.Text;
                BUS.khachhang_BUS khh = new BUS.khachhang_BUS();
                string maa=khh.MaKHdec();
               datagvHoaDon.DataSource = null;
               datagvHoaDon.Rows.Clear();
               datagvHoaDon.Refresh();

                fmKhachHang kh = new fmKhachHang(layso, maa);
                kh.Hide();
                kh.ShowDialog();
                loadTable();
                
            }


        }



        private void buttonMenu_Click(object sender, EventArgs e)
        {
           string ten= ((Button)sender).Text;

            string[] mang;
            mang=ten.Split('\n');

            string soban = lbSoBan.Text;

            string tenne;
            int moneu;
          
            tenne=mang[1];
            moneu =int.Parse(mang[0]);

            BUS.OrderMon_BUS or=new BUS.OrderMon_BUS();
           string w= or.LayidBan(soban);
            BUS.Menu_BUS me=new BUS.Menu_BUS();
            string e3 = me.Laytrangthaiban(w);
            if (e3 == "2")//Đang hoạt động
            {
                fmXacNhanMon xn = new fmXacNhanMon(tenne, moneu, soban, lbidnv.Text);
                xn.Hide();
                xn.ShowDialog();
                BUS.OrderMon_BUS d = new BUS.OrderMon_BUS();
                string idTable = d.LayidBan(lbSoBan.Text);
                BUS.HoaDon_BUS hd = new HoaDon_BUS();
                datagvHoaDon.DataSource = hd.CTHoaDon(idTable);

                datagvHoaDon.Refresh();

            }





            //lbSoBan.Text = ((Button)sender).Text;
            
            //BUS.BanAn_BUS b = new BUS.BanAn_BUS();

            //DataTable table = new DataTable();
            //table = b.loadInforBan(lbSoBan.Text);
            //int flagg = 1;
            //for (int i = 0; i < table.Rows.Count; i++)
            //{
            //    string trangthai = table.Rows[i]["TrangThai"].ToString();
            //    if (trangthai == "1")
            //    {
            //        label1.Text = "Bàn đã đạt";
            //        flagg = 0;
            //    }
            //    else if (trangthai == "2")
            //    {
            //        label1.Text = "Đang hoạt động";
            //        flagg = 0;
            //    }

            //}
            //if (flagg == 1)
            //{
            //    label1.Text = "Bàn trống";
            //}



        }



        private void hảiSảnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            BUS.Menu_BUS b = new BUS.Menu_BUS();
            panel1.Controls.Clear();
            DataTable table = new DataTable();
            table = b.getMenu();

            int vttrai = 10;//giá trị trái ban đầu của button (left)
            int vttren = 25;//giá trị trái ban đầu của button (top)
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string loai = table.Rows[i]["MaLoai"].ToString();
                if (loai == "L002")
                {
                    Button buttonMoi = new Button(); //(2) new mới đối tượng,

                    buttonMoi.Left = vttrai; //(4) thông tin vị trí trái (Left)
                    buttonMoi.Top = vttren;//(4)thông tin vị trí trên (Top)

                    string hinh = table.Rows[i]["Hinh"].ToString();

                    buttonMoi.Image = Image.FromFile(@"..\Resources\" + hinh);
                    //buttonMoi.Image = MyProject.Properties.Resources.
                    string tenn = table.Rows[i]["Tenmon"].ToString();
                    buttonMoi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                    buttonMoi.ImageAlign = ContentAlignment.TopCenter;
                    buttonMoi.Name = "btnMon" + tenn; //(5) tên button mới
                                                      //(6) Kích thước button mới
                    buttonMoi.Size = new System.Drawing.Size(180, 180);

                    buttonMoi.Text = table.Rows[i]["MaMon"].ToString();
                    string trangthai = table.Rows[i]["TrangThai"].ToString();
                    string dg = table.Rows[i]["DonGia"].ToString();
                    buttonMoi.Text = dg + '\n' + tenn;

                    if (trangthai == "Còn")
                    {
                        buttonMoi.BackColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        buttonMoi.BackColor = System.Drawing.Color.Yellow;
                    }



                    if ((i + 1) % 5 != 0)
                    {
                        vttrai = vttrai + 190; //Moi button cach nhau 10
                                               //(chiều cao =20 + khoảng cách =10)
                    }
                    else if ((i + 1) % 5 == 0)
                    {

                        vttrai = 10;
                        vttren += 190;
                    }
                    panel1.Controls.Add(buttonMoi);
                    buttonMoi.Click += new EventHandler(buttonMenu_Click);
                }

            }
        }

        private void nôngSảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BUS.Menu_BUS b = new BUS.Menu_BUS();
            panel1.Controls.Clear();
            DataTable table = new DataTable();
            table = b.getMenu();

            int vttrai = 10;//giá trị trái ban đầu của button (left)
            int vttren = 25;//giá trị trái ban đầu của button (top)
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string loai = table.Rows[i]["MaLoai"].ToString();
                if (loai == "L003")
                {
                    Button buttonMoi = new Button(); //(2) new mới đối tượng,

                    buttonMoi.Left = vttrai; //(4) thông tin vị trí trái (Left)
                    buttonMoi.Top = vttren;//(4)thông tin vị trí trên (Top)

                    string hinh = table.Rows[i]["Hinh"].ToString();

                    buttonMoi.Image = Image.FromFile(@"..\Resources\" + hinh);
                    //buttonMoi.Image = MyProject.Properties.Resources.
                    string tenn = table.Rows[i]["Tenmon"].ToString();
                    buttonMoi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                    buttonMoi.ImageAlign = ContentAlignment.TopCenter;
                    buttonMoi.Name = "btnMon" + tenn; //(5) tên button mới
                                                      //(6) Kích thước button mới
                    buttonMoi.Size = new System.Drawing.Size(180, 180);

                    buttonMoi.Text = table.Rows[i]["MaMon"].ToString();
                    string trangthai = table.Rows[i]["TrangThai"].ToString();
                    string dg = table.Rows[i]["DonGia"].ToString();
                    buttonMoi.Text = dg + '\n' + tenn;

                    if (trangthai == "Còn")
                    {
                        buttonMoi.BackColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        buttonMoi.BackColor = System.Drawing.Color.Yellow;
                    }



                    if ((i + 1) % 5 != 0)
                    {
                        vttrai = vttrai + 190; //Moi button cach nhau 10
                                               //(chiều cao =20 + khoảng cách =10)
                    }
                    else if ((i + 1) % 5 == 0)
                    {

                        vttrai = 10;
                        vttren += 190;
                    }
                    panel1.Controls.Add(buttonMoi);
                    buttonMoi.Click += new EventHandler(buttonMenu_Click);
                }

            }
        }

        private void giảiKhátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BUS.Menu_BUS b = new BUS.Menu_BUS();
            panel1.Controls.Clear();
            DataTable table = new DataTable();
            table = b.getMenu();

            int vttrai = 10;//giá trị trái ban đầu của button (left)
            int vttren = 25;//giá trị trái ban đầu của button (top)
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string loai = table.Rows[i]["MaLoai"].ToString();
                if (loai == "L004")
                {
                    Button buttonMoi = new Button(); //(2) new mới đối tượng,

                    buttonMoi.Left = vttrai; //(4) thông tin vị trí trái (Left)
                    buttonMoi.Top = vttren;//(4)thông tin vị trí trên (Top)

                    string hinh = table.Rows[i]["Hinh"].ToString();

                    buttonMoi.Image = Image.FromFile(@"..\Resources\" + hinh);
                    //buttonMoi.Image = MyProject.Properties.Resources.
                    string tenn = table.Rows[i]["Tenmon"].ToString();
                    buttonMoi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                    buttonMoi.ImageAlign = ContentAlignment.TopCenter;
                    buttonMoi.Name = "btnMon" + tenn; //(5) tên button mới
                                                      //(6) Kích thước button mới
                    buttonMoi.Size = new System.Drawing.Size(180, 180);

                    buttonMoi.Text = table.Rows[i]["MaMon"].ToString();
                    string trangthai = table.Rows[i]["TrangThai"].ToString();
                    string dg = table.Rows[i]["DonGia"].ToString();
                    buttonMoi.Text = dg + '\n' + tenn;

                    if (trangthai == "Còn")
                    {
                        buttonMoi.BackColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        buttonMoi.BackColor = System.Drawing.Color.Yellow;
                    }



                    if ((i + 1) % 5 != 0)
                    {
                        vttrai = vttrai + 190; //Moi button cach nhau 10
                                               //(chiều cao =20 + khoảng cách =10)
                    }
                    else if ((i + 1) % 5 == 0)
                    {

                        vttrai = 10;
                        vttren += 190;
                    }
                    panel1.Controls.Add(buttonMoi);
                    buttonMoi.Click += new EventHandler(buttonMenu_Click);
                }

            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            BUS.Menu_BUS b = new BUS.Menu_BUS();
            panel1.Controls.Clear();
            DataTable table = new DataTable();
            table = b.getMenu();

            int vttrai = 10;//giá trị trái ban đầu của button (left)
            int vttren = 25;//giá trị trái ban đầu của button (top)
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string loai = table.Rows[i]["MaLoai"].ToString();
                if (loai == "L005")
                {
                    Button buttonMoi = new Button(); //(2) new mới đối tượng,

                    buttonMoi.Left = vttrai; //(4) thông tin vị trí trái (Left)
                    buttonMoi.Top = vttren;//(4)thông tin vị trí trên (Top)

                    string hinh = table.Rows[i]["Hinh"].ToString();

                    buttonMoi.Image = Image.FromFile(@"..\Resources\" + hinh);
                    //buttonMoi.Image = MyProject.Properties.Resources.
                    string tenn = table.Rows[i]["Tenmon"].ToString();
                    buttonMoi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                    buttonMoi.ImageAlign = ContentAlignment.TopCenter;
                    buttonMoi.Name = "btnMon" + tenn; //(5) tên button mới
                                                      //(6) Kích thước button mới
                    buttonMoi.Size = new System.Drawing.Size(180, 180);

                    buttonMoi.Text = table.Rows[i]["MaMon"].ToString();
                    string trangthai = table.Rows[i]["TrangThai"].ToString();
                    string dg = table.Rows[i]["DonGia"].ToString();
                    buttonMoi.Text = dg + '\n' + tenn;

                    if (trangthai == "Còn")
                    {
                        buttonMoi.BackColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        buttonMoi.BackColor = System.Drawing.Color.Yellow;
                    }



                    if ((i + 1) % 5 != 0)
                    {
                        vttrai = vttrai + 190; //Moi button cach nhau 10
                                               //(chiều cao =20 + khoảng cách =10)
                    }
                    else if ((i + 1) % 5 == 0)
                    {

                        vttrai = 10;
                        vttren += 190;
                    }
                    panel1.Controls.Add(buttonMoi);
                    buttonMoi.Click += new EventHandler(buttonMenu_Click);
                }

            }
        }

        private void trángMiệngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadMenu();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
          fmLichSu fm=new fmLichSu();
            fm.Hide();
            fm.ShowDialog();
        }

       
        private void button4_Click(object sender, EventArgs e)
        {
            string sban = lbSoBan.Text;
            BUS.khachhang_BUS kh = new BUS.khachhang_BUS();

            BUS.OrderMon_BUS o = new OrderMon_BUS();
            string mab = o.LayidBan(lbSoBan.Text);
            DataTable table = new DataTable();
            table = kh.LayTenKHSDT_TruyenSB(mab);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string tenkhh = table.Rows[i]["Tenkh"].ToString();
                string phone = table.Rows[i]["Sdt"].ToString();
                fmThanhToan m = new fmThanhToan(tenkhh, sban, phone);
                m.Hide();
                m.ShowDialog();
                break;
            }

            loadTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadTable();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BUS.BanAn_BUS b = new BUS.BanAn_BUS();
            panel2.Controls.Clear();
            DataTable table = new DataTable();
            table = b.getDataTTBanDat();
            int vttrai = 10;//giá trị trái ban đầu của button (left)
            int vttren = 10;//giá trị trái ban đầu của button (top)
            for (int i = 0; i < table.Rows.Count; i++)
            {

                Button buttonMoi = new Button(); //(2) new mới đối tượng,

                buttonMoi.Left = vttrai; //(4) thông tin vị trí trái (Left)
                buttonMoi.Top = vttren;//(4)thông tin vị trí trên (Top)
                string tenn = table.Rows[i]["SoBan"].ToString();
                buttonMoi.Name = "btnBan" + tenn; //(5) tên button mới
                                                  //(6) Kích thước button mới
                string ss = buttonMoi.Name;


                buttonMoi.Size = new System.Drawing.Size(100, 40);
                string trangthai = table.Rows[i]["TrangThai"].ToString();
                if (trangthai == "1" && comboBox1.Text == "Bàn đặt trước")
                {
                    buttonMoi.BackColor = System.Drawing.Color.Red;
                    panel2.Controls.Add(buttonMoi);
                    buttonMoi.Text = tenn;
                    if ((i + 1) % 3 != 0)
                    {
                        vttrai = vttrai + 100; //Moi button cach nhau 10
                                               //(chiều cao =20 + khoảng cách =10)
                    }
                    else if ((i + 1) % 3 == 0)
                    {
                        vttrai = 10;
                        vttren += 60;
                    }
                }

                else if (trangthai == "2" && comboBox1.Text == "Bàn đang hoạt động")
                {

                    buttonMoi.BackColor = System.Drawing.Color.Green;
                    panel2.Controls.Add(buttonMoi);
                    buttonMoi.Text = tenn;
                    if ((i + 1) % 3 != 0)
                    {
                        vttrai = vttrai + 100; //Moi button cach nhau 10
                                               //(chiều cao =20 + khoảng cách =10)
                    }
                    else if ((i + 1) % 3 == 0)
                    {
                        vttrai = 10;
                        vttren += 60;
                    }


                }
                

                //(3) thêm vào Control của form hiện tại,
                buttonMoi.Click += new EventHandler(buttonMoi_Click);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void datagvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = datagvHoaDon.Rows[e.RowIndex];
            string sb = lbSoBan.Text;
            string mon = Convert.ToString(row.Cells["Tenmon"].Value);
            string dongia = Convert.ToString(row.Cells["DonGia"].Value);
            string sl = Convert.ToString(row.Cells["Sl"].Value);
            string tt = Convert.ToString(row.Cells["Thanhtien"].Value);
            string id = Convert.ToString(row.Cells["MaCTHD"].Value);
            fmFixMon fm = new fmFixMon(sl, mon, tt, sb, dongia,id);
            fm.Hide();
            fm.ShowDialog();
            BUS.OrderMon_BUS d = new BUS.OrderMon_BUS();
            string idTable = d.LayidBan(lbSoBan.Text);
            BUS.HoaDon_BUS hd = new HoaDon_BUS();
            datagvHoaDon.DataSource = hd.CTHoaDon(idTable);


            datagvHoaDon.Refresh();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string sban = lbSoBan.Text;
            BUS.khachhang_BUS kh= new BUS.khachhang_BUS();

         BUS.OrderMon_BUS o = new OrderMon_BUS();
            string mab=o.LayidBan(lbSoBan.Text);
            DataTable table = new DataTable();
            table = kh.LayTenKHSDT_TruyenSB(mab);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string tenkhh = table.Rows[i]["Tenkh"].ToString();
                string phone = table.Rows[i]["Sdt"].ToString();
                fmThanhToan m = new fmThanhToan(tenkhh, sban, phone);
                m.Hide();
                m.ShowDialog();
                break;
            }

            loadTable();

        }

        private void datagvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void quảnLýThựcĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmSuaMon m =new fmSuaMon();
            m.Hide();
            m.ShowDialog();
        }

        private void quảnLýChiTiêuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmDoanhThu dt = new fmDoanhThu();
            dt.Hide();
            dt.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbidnv.Text = "";
            lbNhanVien.Text = "";
            fmDangNhap dn = new fmDangNhap(); 
            this.Hide();
            dn.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
