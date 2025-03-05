using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCareManager
{
    public static class KetNoiCSDL
    {
        private static readonly string ChuoiKN = ConfigurationManager.ConnectionStrings["QuanLyChamSocThuCung"].ConnectionString;
        //Phuong thuc mo ket noi
        public static SqlConnection MoKetNoi()
        {
            SqlConnection conn = new SqlConnection(ChuoiKN);
            try
            {
                conn.Open();
            }
            catch(Exception ex)
            {
                throw new Exception("Loi khi ket noi csdl!" + ex.Message);
            }
            return conn;
        }
        //Phuong thuc dong ket noi
        public static void DongKetNoi(SqlConnection conn)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Loi khi dong ket noi csdl" + ex.Message);
            }
        }
    }
}
