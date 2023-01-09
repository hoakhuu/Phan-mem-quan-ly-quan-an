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
    public class Menu_BUS
    {
        string tenmon;
        string name;
        string trangthai;
        string pc;
        int dongia;
        string maloai;


        public Menu_BUS()
        {
        }

        public Menu_BUS(string tenmon, string name, string trangthai, string pc, int dongia, string maloai)
        {
            this.tenmon = tenmon;
            this.name = name;
            this.trangthai = trangthai;
            this.pc = pc;
            this.dongia = dongia;
            this.maloai = maloai;
        }

        public string Tenmon { get => tenmon; set => tenmon = value; }
        public string Name { get => name; set => name = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
        public string Pc { get => pc; set => pc = value; }
        public int Dongia { get => dongia; set => dongia = value; }
        public string Maloai { get => maloai; set => maloai = value; }



        public DataTable getMenu()
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand("getMenu", con);
            command.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }


        public string Laytrangthaiban(string idsoban) // Lấy id của bàn khi truyền vào số bàn
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "select TrangThai from đặt where MaDatBan='"+idsoban+"' ";
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

        public string LaytenLoai(string idloai) // Lấy tenloai khi truyen idloai 
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "select Tenloai from Loai where Maloai =N'" + idloai + "'";
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



        public string LayidLoai(string tenmon) // Lấy idloai khi tryen ten loai
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "select Maloai from Loai where Tenloai =N'"+tenmon+"'";
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

        public void AddMenu(string id, string tenmon, string dongia, string hinh, string maloai)
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "insert into Mon values ('" + id + "',N'" + tenmon + "',N'còn'," + dongia + ",'" + hinh + "','" + maloai + "');";
            command.Connection = con;
            int kq = command.ExecuteNonQuery();

        }

        public string tnagMaMon ()
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "SELECT Mamon from Mon";
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

    }
}
