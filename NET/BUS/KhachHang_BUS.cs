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
    public class khachhang_BUS
    {
        string name;
        string phone;
        public khachhang_BUS()
        {

        }

        public khachhang_BUS(string name, string phone)
        {
            this.name = name;
            this.phone = phone;
        }

        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }


        public string MaKHdec()
        {

            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "SELECT  MaKH FROM KhachHang ";
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




            //SqlConnection con = Connect.HamKetNoi();
            //SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.Text;
            //con.Open();
            //command.CommandText = "SELECT TOP 1 MaKH FROM KhachHang ORDER BY MaKH DESC";
            //command.Connection = con;
            //SqlDataReader reader = command.ExecuteReader();
            //string kq = "";
            //while (reader.Read())
            //{

            //    string masp = reader.GetString(0);
            //    int dem = masp.Length - 1;
            //    int demm = int.Parse(masp.Substring(1, dem)) + 1;
            //    string dau = masp.Substring(0, 2);
            //    kq = dau + demm;

            //}
            //reader.Close();
            //return kq;
        }

       public void insertInforKhach (string ten, string phonee)
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();

            string idkh = MaKHdec();
            command.CommandText = "insert into dbo.KhachHang values ('" + idkh+ "',N'"+ten+"','"+phonee+"')";
            command.Connection = con;
            int kq = command.ExecuteNonQuery();
        }


        public void updateTrangThai(string maban, string makh)
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();

            string idkh = MaKHdec();
            command.CommandText = "insert into Đặt values('12-2-2022','" + maban+"','"+makh+"','1')";
            command.Connection = con;
            int kq = command.ExecuteNonQuery();
            MessageBox.Show("Đặt bàn thành công!! Chúc quý khách ngon miệng");


        }


        public string LayIDKhachHanh ( string tenkh)//lấy id khách hàng khi truyền tên KH
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "select Makh from KhachHang where Tenkh='"+tenkh+"'";
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

        //select Tenkh from KhachHang k, đặt d where d.Makh = k.Makh and d.MaDatBan='B02'


        public string LayTenKH_TruyenSB(string soban)//lấy id khách hàng khi truyền tên KH
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "select Tenkh from KhachHang k, đặt d where d.Makh = k.Makh and d.MaDatBan='"+soban+"'";
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


        public DataTable LayTenKHSDT_TruyenSB(string soban)//lấy id khách hàng khi truyền tên KH
        {
         
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "select Tenkh, Sdt from KhachHang k, đặt d where d.Makh = k.Makh and d.MaDatBan='" + soban + "'";
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
