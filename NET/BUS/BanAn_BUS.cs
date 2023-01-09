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
    public class BanAn_BUS
    {

        string madat;
        int soban;
        string trangthai;

        public BanAn_BUS()
        {

        }
        public BanAn_BUS(string madat, int soban, string trangthai)
        {
            this.madat = madat;
            this.soban = soban;
            this.trangthai = trangthai;
        }

        public string Madat { get => madat; set => madat = value; }
        public int Soban { get => soban; set => soban = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }


        public DataTable getDataTTBanDat()
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand("getBanDaDat", con);
            command.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable loadInforBan(string id)
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();
            command.CommandText = "select * from đặt where MaDatBan=( select MaDatBan from Ban where SoBan=" + id + ")";
            command.Connection=con;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //DELETE FROM đặt WHERE MaDatBan=''

        public void xoaDatBan( string idban)
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();

            command.CommandText = "DELETE FROM đặt WHERE MaDatBan='"+idban+"'";
            command.Connection = con;
            int kq = command.ExecuteNonQuery();
            MessageBox.Show("Hủy đặt bàn thành công");

        }


        public void UpTrangThai(string idban)
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();

            command.CommandText = "update đặt set TrangThai = 2 where MaDatBan = '"+idban+"'";
            command.Connection = con;
            int kq = command.ExecuteNonQuery();
            MessageBox.Show("Hãy trải nghiệm thôi nào.");


        }


        public void XoaTrangThai(string idban)
        {
            SqlConnection con = Connect.HamKetNoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            con.Open();

            command.CommandText = "delete from đặt where MaDatBan='"+idban+"'";
            command.Connection = con;
            int kq = command.ExecuteNonQuery();
            

        }
    }
}
