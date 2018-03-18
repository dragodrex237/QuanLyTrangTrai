using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanLyTrangTrai
{
    class Loai
    {
        private static Loai instance;

        internal static Loai Instance
        {
            get { if (instance == null) { instance = new Loai(); } return Loai.instance; }
            private set { Loai.instance = value; }
        }
        private Loai() { }

        SqlConnection cnn;
        string cnstr;

        public void Init()
        {
            cnstr = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            cnn = new SqlConnection(cnstr);
        }

        /*public DataTable LoadTableLoai(string sql)
        {
            Init();
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }*/

        public bool SaveTableVatNuoi(DataTable dt)
        {
            try
            {
                Init();
                SqlDataAdapter daVN = new SqlDataAdapter();
                //Insert cho VatNuoi
                SqlCommand cmd = new SqlCommand("insert into Loai(ma_loai, ten_loai, soluongVN, soluongCH) values(@ma_loai, @ten_loai, 0, 0)", cnn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@ma_loai", SqlDbType.NVarChar, 50, "ma_loai");
                cmd.Parameters.Add("@ten_loai", SqlDbType.NVarChar, 50, "ten_loai");
                daVN.InsertCommand = cmd;

                //Delete cho VatNuoi
                cmd = new SqlCommand("delete from Loai where ma_loai = @ma_loai", cnn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@ma_loai", SqlDbType.NVarChar, 50, "ma_loai");
                daVN.DeleteCommand = cmd;

                //Update cho VatNuoi
                cmd = new SqlCommand("update Loai set ten_loai = @ten_loai where ma_loai = @ma_loai", cnn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@ma_loai", SqlDbType.NVarChar, 50, "ma_loai");
                cmd.Parameters.Add("@ten_loai", SqlDbType.NVarChar, 50, "ten_loai");
                daVN.UpdateCommand = cmd;

                daVN.Update(dt);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
