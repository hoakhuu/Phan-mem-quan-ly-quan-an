using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Configuration;
using NET.DAL;

namespace NET.BUS
{
    public class HoaDon_BUS
    {
        public HoaDon_BUS()
        {

        }

        public DataTable CTHoaDon(string idBan)
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "select Tenmon,Sl,DonGia,Thanhtien,MaCTHD from Ban b, HoaDon hd, CTHD c, Mon m where b.MaDatBan='"+idBan+"' and b.MaDatBan=hd.MaDatBan and c.Mahd = hd.Mahd and c.MaMon=m.MaMon";
            command.Connection = con;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable HoaDon(string idBan)
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "select m.Tenmon,m.DonGia,sum(Sl) as SoLuong,sum(ThanhTien) as ThanhTien from HoaDon h, CTHD c, Ban b, Mon m where b.MaDatBan='"+idBan+"' and b.MaDatBan=h.MaDatBan and c.Mahd=h.Mahd and m.MaMon = c.MaMon group by m.Tenmon, m.DonGia";
            command.Connection = con;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public string TongTien(string idBan) 
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "select convert(varchar(10),sum(ThanhTien),101) from HoaDon h, CTHD c, Ban b where b.MaDatBan='"+idBan+"' and b.MaDatBan=h.MaDatBan and c.Mahd=h.Mahd";
            command.Connection = con;
            SqlDataReader reader = command.ExecuteReader();
            string aa = "";
            while (reader.Read())
            {
                aa = reader.GetString(0);

            }
            reader.Close();
            return aa;
        }

        public string MaMLCdec()
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "SELECT MaLichSu from LichSu";
            command.Connection = con;
            SqlDataReader reader = command.ExecuteReader();


            string masp = ""; int dem = 0; int max = 0; int flag = 0;

            while (reader.Read())
            {
                if (flag == 1)
                {
                    string masp1 = reader.GetString(0);
                    int dem1 = masp1.Length - 1;
                    int demm1 = int.Parse(masp1.Substring(1, dem1));

                    if (max > demm1)
                    {
                        max = max;
                    }
                    else
                    {
                        max = demm1;
                    }
                }
                else if (flag == 0)
                {
                    masp = reader.GetString(0);
                    dem = masp.Length - 1;
                    max = int.Parse(masp.Substring(1, dem));
                    flag = 1;
                }

            }
            max = max + 1;
            string dau = masp.Substring(0, 2);
            string kq = dau + max;
            reader.Close();
            return kq;
        }

        public void insertLishSu(string mls, string tkh, string thanhtoan ,string soban)
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
           int gio = DateTime.Now.Hour;
            int phut = DateTime.Now.Minute;
            int giay = DateTime.Now.Second;
            string d = gio + ":" + phut + ":" + giay;
            string s = DateTime.Now.ToString("MM-dd-yyyy");
            string sss= "insert into LichSu  values('" + mls + "','" + tkh + "','" + s + "','" + d + "'," + thanhtoan + "," + soban + ")";
            command.CommandText = sss;
            command.Connection = con;
            int kq = command.ExecuteNonQuery();

        }

        public DataTable LichSuGiaoDich()
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "select * from LichSu";
            command.Connection = con;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        //select* from LichSu where Ngay>'2022-12-10' and Ngay<'2022-12-13' 

        public DataTable LichSuGiaoDichFromTo(string to, string from)
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "select* from LichSu where Ngay>'"+to+"' and Ngay<'"+from+"' ";
            command.Connection = con;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }

        public DataTable DoanhThu()
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "select MONTH(ngay) as N'Tháng', sum(ThanhToan) as N'Doanh Thu' from LichSu group by MONTH(ngay)";
            command.Connection = con;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable DoanhThu(string thanh)
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "select MONTH(ngay) as N'Tháng', sum(ThanhToan) as N'Doanh Thu'  from LichSu where MONTH(ngay)='"+thanh+"' group by  MONTH(ngay)";
            command.Connection = con;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
