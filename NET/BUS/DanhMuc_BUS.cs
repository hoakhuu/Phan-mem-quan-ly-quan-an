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
    public class DanhMuc_BUS
    {




        public DataTable DanhMuc() // Lấy thong tin nv khi truyền id dang nhap
        {

            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "select TenLoai from Loai";

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
