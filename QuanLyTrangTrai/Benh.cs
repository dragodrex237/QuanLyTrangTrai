using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanLyTrangTrai
{
    class Benh
    {
        private static Benh instance;

        internal static Benh Instance
        {
            get { if (instance == null) { instance = new Benh(); } return Benh.instance; }
            private set { Benh.instance = value; }
        }
        private Benh() { }

        SqlConnection cnn;
        string cnstr;

        public void Init()
        {
            cnstr = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            cnn = new SqlConnection(cnstr);
        }
        /*public DataTable LoadTableBenh(string sql)
        {
            Init();
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }*/
        public bool SaveTableBenh(DataTable dt)
        {
            try
            {
                Init();
                SqlDataAdapter daVN = new SqlDataAdapter();
                //Insert cho VatNuoi
                SqlCommand cmd = new SqlCommand("insert into Benh(ma_benh, ten_benh, ma_loai) values(@ma_benh, @ten_benh, @ma_loai)", cnn);
                cmd.Parameters.Add("@ma_benh", SqlDbType.NVarChar, 50, "ma_benh");
                cmd.Parameters.Add("@ten_benh", SqlDbType.NVarChar, 50, "ten_benh");
                cmd.Parameters.Add("@ma_loai", SqlDbType.NVarChar, 50, "ma_loai");
                daVN.InsertCommand = cmd;

                //Delete cho VatNuoi
                cmd = new SqlCommand("delete from Benh where ma_benh = @ma_benh", cnn);
                cmd.Parameters.Add("@ma_benh", SqlDbType.NVarChar, 50, "ma_benh");
                daVN.DeleteCommand = cmd;

                //Update cho VatNuoi
                cmd = new SqlCommand("update Benh set ten_benh = @ten_benh, ma_loai = @ma_loai where ma_benh = @ma_benh", cnn);
                cmd.Parameters.Add("@ma_benh", SqlDbType.NVarChar, 50, "ma_benh");
                cmd.Parameters.Add("@ten_benh", SqlDbType.NVarChar, 50, "ten_benh");
                cmd.Parameters.Add("@ma_loai", SqlDbType.NVarChar, 50, "ma_loai");
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
