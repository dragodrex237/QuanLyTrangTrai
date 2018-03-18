using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanLyTrangTrai
{
    class Chuong
    {
        private static Chuong instance;

        internal static Chuong Instance
        {
            get { if (instance == null) { instance = new Chuong(); } return Chuong.instance; }
            private set { Chuong.instance = value; }
        }
        private Chuong() { }

        SqlConnection cnn;
        string cnstr;

        public void Init()
        {
            cnstr = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            cnn = new SqlConnection(cnstr);
        }
        /*public DataTable LoadTableChuong(string sql)
        {
            Init();
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }*/
        public bool SaveTableChuong(DataTable dt)
        {
            try
            {
                Init();
                SqlDataAdapter daVN = new SqlDataAdapter();
                //Insert cho VatNuoi
                SqlCommand cmd = new SqlCommand("ThemChuong", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ma_chuong", SqlDbType.NVarChar, 50, "ma_chuong");
                cmd.Parameters.Add("@ten_chuong", SqlDbType.NVarChar, 50, "ten_chuong");
                cmd.Parameters.Add("@ma_loai", SqlDbType.NVarChar, 50, "ma_loai");
                cmd.Parameters.Add("@sltoida", SqlDbType.Int, 50, "sltoida");
                daVN.InsertCommand = cmd;

                //Delete cho VatNuoi
                cmd = new SqlCommand("XoaChuong", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ma_chuong", SqlDbType.NVarChar, 50, "ma_chuong");
                daVN.DeleteCommand = cmd;

                //Update cho VatNuoi
                cmd = new SqlCommand("SuaChuong", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ma_chuong", SqlDbType.NVarChar, 50, "ma_chuong");
                cmd.Parameters.Add("@ten_chuong", SqlDbType.NVarChar, 50, "ten_chuong");
                cmd.Parameters.Add("@ma_loai", SqlDbType.NVarChar, 50, "ma_loai");
                cmd.Parameters.Add("@sltoida", SqlDbType.Int, 50, "sltoida");
                daVN.UpdateCommand = cmd;

                daVN.Update(dt);

                CountChuongchoLoai();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void CountChuongchoLoai()
        {
            Init();
            DataTable table = Database.Instance.LoadTable("select ma_loai from Loai");
            foreach (DataRow dr in table.Rows)
            {
                SqlCommand cmd = new SqlCommand("CountChuongchoLoai", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ma_loai", dr[0].ToString());
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
        }
    }
}
