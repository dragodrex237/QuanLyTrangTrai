using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanLyTrangTrai
{
    class LichSuBenh
    {
        private static LichSuBenh instance;

        internal static LichSuBenh Instance
        {
            get { if (instance == null) { instance = new LichSuBenh(); } return LichSuBenh.instance; }
            private set { LichSuBenh.instance = value; }
        }
        private LichSuBenh() { }

        SqlConnection cnn;
        string cnstr;

        public void Init()
        {
            cnstr = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            cnn = new SqlConnection(cnstr);
        }
        /*public DataTable LoadTableLSB(string sql)
        {
            Init();
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }*/
        public bool SaveTableLSB(DataTable dt)
        {
            try
            {
                Init();
                SqlDataAdapter daVN = new SqlDataAdapter();
                //Insert cho VatNuoi
                SqlCommand cmd = new SqlCommand("ThemLSB", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ma_vatnuoi", SqlDbType.NVarChar, 50, "ma_vatnuoi");
                cmd.Parameters.Add("@ma_benh", SqlDbType.NVarChar, 50, "ma_benh");
                cmd.Parameters.Add("@ma_thuoc", SqlDbType.NVarChar, 50, "ma_thuoc");
                daVN.InsertCommand = cmd;

                //Delete cho VatNuoi
                cmd = new SqlCommand("XoaLSB", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ma_LS", SqlDbType.NVarChar, 50, "ma_LS");
                daVN.DeleteCommand = cmd;

                //Update cho VatNuoi
                cmd = new SqlCommand("SuaLSB", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ma_LS", SqlDbType.NVarChar, 50, "ma_LS");
                cmd.Parameters.Add("@ma_vatnuoi", SqlDbType.NVarChar, 50, "ma_vatnuoi");
                cmd.Parameters.Add("@ma_benh", SqlDbType.NVarChar, 50, "ma_benh");
                cmd.Parameters.Add("@ma_thuoc", SqlDbType.NVarChar, 50, "ma_thuoc");
                daVN.UpdateCommand = cmd;

                daVN.Update(dt);

                return true;
            }
            catch
            {
                throw;
                return false;
            }
        }
    }
}
