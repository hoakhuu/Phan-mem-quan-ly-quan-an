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
    public class OrderMon_BUS
    {

        //public DataTable orderMonAn(string tenmon, string soban, string soluong, string thanhtien)
        //{
        //    SqlConnection con = Connect.HamKetNoi();
        //    SqlCommand command = new SqlCommand();
        //    command.CommandType = CommandType.Text;
        //    con.Open();
        //    command.CommandText = "select * from đặt where MaDatBan=( select MaDatBan from Ban where SoBan=" + id + ")";
        //    command.Connection = con;

        //    SqlDataAdapter da = new SqlDataAdapter();
        //    da.SelectCommand = command;
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    return dt;
        //}

        string kq = "";

        public string MaHDdec ()
        {

            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "SELECT Mahd FROM HoaDon ";
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
            //command.CommandText = "SELECT TOP 1 Mahd FROM HoaDon ORDER BY Mahd DESC";
            //command.Connection = con;
            //SqlDataReader reader = command.ExecuteReader();
            
            //while( reader.Read())
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

        public string loadhinh (string tenmon)
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "select Hinh from Mon where Tenmon=N'"+tenmon+"'";
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

        public string MaCTHDdec()
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "SELECT MaCTHD FROM CTHD";
            command.Connection = con;
            SqlDataReader reader = command.ExecuteReader();

            
            string masp ="";
            int dem=0 ;
            int max=0 ;
            int flag = 0;

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
                else if (flag ==0)
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


        public string MaMondec()
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "SELECT MaMon FROM Mon";
            command.Connection = con;
            SqlDataReader reader = command.ExecuteReader();


            string masp = "";
            int dem = 0;
            int max = 0;
            int flag = 0;

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



        public DataTable  KTRMaHD()
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "select * from HoaDon";
            command.Connection = con;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public DataTable inforMonMenu( string mamon)
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "select Tenmon,DonGia,Hinh,MaLoai from Mon where MaMon='"+mamon+"'";
            command.Connection = con;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public string MaHDofBan(string soban)
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "select Mahd from HoaDon, Ban where Ban.SoBan = "+soban+" and  HoaDon.MaDatBan = Ban.MaDatBan";
            command.Connection = con;
            SqlDataReader reader = command.ExecuteReader();
            string aa = "";
            while (reader.Read())
            {
                aa= reader.GetString(0);
                
            }
            reader.Close();
            return aa;
        }

        public string LayMaMon(string tenmonn) // lấy mã món khi truyền vào tên món
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "select MaMon from dbo.Mon where Tenmon=N'"+tenmonn+"'";
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



        public void insertCTHD(string sl, string tt, string mamon, string mahd,string maCTDH)
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "insert into CTHD values("+sl+","+tt+",'"+ mamon + "','"+ mahd + "','"+maCTDH+"')";
            command.Connection = con;
           int kq=command.ExecuteNonQuery();
           
        }


        public void suamon(string idmon, string tenmon, string dongia, string hinh, string maloai)
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "update Mon set Tenmon=N'"+tenmon+"',DonGia="+dongia+",Hinh='"+hinh+"',Maloai='"+maloai+"' where MaMon='"+idmon+"'";
            command.Connection = con;
            int kq = command.ExecuteNonQuery();

        }


        //public void dropMonMenu(string mamon)
        //{
        //    SqlConnection con = Connect.HamKetNoi();
        //    SqlCommand command = new SqlCommand();
        //    command.CommandType = CommandType.Text;
        //    con.Open();
        //    command.CommandText = "delete from Mon where MaMon ='"+mamon+"'";
        //    command.Connection = con;
        //    int kq = command.ExecuteNonQuery();

        //}


        public void insertHH(string mahd,string datban, string idNV)
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            
            command.CommandText = "insert into dbo.HoaDon values ('"+mahd+"','12-3-2022','"+idNV+"','"+datban+"')";
            command.Connection = con;
            int kq = command.ExecuteNonQuery();

        }

        public string LayidBan(string soban) // Lấy id của bàn khi truyền vào số bàn
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "select MaDatBan from dbo.Ban where SoBan="+soban+"";
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


        //DELETE FROM CTHD WHERE MaMon=''
        public void dropMon(string maCTHD)
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();

            command.CommandText = "DELETE FROM CTHD WHERE MaCTHD='"+maCTHD+"'";
            command.Connection = con;
            int kq = command.ExecuteNonQuery();
            MessageBox.Show("Xóa thành công món ăn");
        }


        public void updateSL(string maCTHD,string sll,string tt)
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();

            command.CommandText = "Update CTHD set Sl="+sll+", ThanhTien="+tt+" where maCTHD='"+maCTHD+"'";
            command.Connection = con;
            int kq = command.ExecuteNonQuery();
            MessageBox.Show("Thay đổi thành công");
        }

        public void updateTinhTrangtable(string maban)
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();

            command.CommandText = "update d";
            command.Connection = con;
            int kq = command.ExecuteNonQuery();
        }




    }
}
