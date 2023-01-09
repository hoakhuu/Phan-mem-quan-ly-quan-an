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


namespace NET.DAL
{
    internal class Connect
    {


        public static SqlConnection HamKetNoi()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=QUANLY_NHAHANG;Integrated Security=True");
            return conn;
        }
    }
}
