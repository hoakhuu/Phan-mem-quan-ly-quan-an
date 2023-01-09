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
    public partial class fmSuaMon : Form
    {
        public fmSuaMon()
        {
            InitializeComponent();
        }

        private void fmSuaMon_Load(object sender, EventArgs e)
        {

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


        string ten = "";
        private void buttonMenu_Click(object sender, EventArgs e)
        {
            ten = ((Button)sender).Text;
            btnSua.Enabled = true;
          

        }

        private void btnThem_Click(object sentender, EventArgs e)
        {
            panel1.BackColor = SystemColors.Control;
            btnSua.Enabled = false;
            
            fmFixMenu f = new fmFixMenu();
            f.ShowDialog();
        }

      

        private void btnSua_Click(object sender, EventArgs e)
        {
            panel1.BackColor = SystemColors.Info;
            string[] mang;
            mang = ten.Split('\n');


            string tenne;
            tenne = mang[1];


            BUS.OrderMon_BUS fm = new BUS.OrderMon_BUS();
            string s = fm.LayMaMon(tenne);

            DataTable table = new DataTable();
            table = fm.inforMonMenu(s);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                string tenmon = table.Rows[i]["Tenmon"].ToString();
                string giaban = table.Rows[i]["DonGia"].ToString();
                string maloai = table.Rows[i]["MaLoai"].ToString();
                string hinh = table.Rows[i]["Hinh"].ToString();

                BUS.Menu_BUS m = new BUS.Menu_BUS();
                string tenloai = m.LaytenLoai(maloai);

                fmSuaMenu d = new fmSuaMenu(tenmon, giaban, tenloai, hinh);
                d.ShowDialog();


            }
            loadMenu();
        }

        private void hảiSảnToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
