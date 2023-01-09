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
    public class NhanVien_BUS
    {
        public string LoginNV(string tendn, string mk) // Lấy id của bàn khi truyền vào số bàn
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "select maLogin from Login where Tenlogin='"+tendn+"' and Matkhau='"+mk+"'";
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

        public DataTable inforNV(string iddn) // Lấy thong tin nv khi truyền id dang nhap
        {
           
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "select Manv, Tennv from NhanVien where maLogin='" + iddn + "'";
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
