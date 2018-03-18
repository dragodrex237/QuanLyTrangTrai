using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanLyTrangTrai
{
    public class VatNuoi
    {
        private static VatNuoi instance;

        public static VatNuoi Instance
        {
            get { if (instance == null) { instance = new VatNuoi(); } return VatNuoi.instance; }
            private set { VatNuoi.instance = value; }
        }
        private VatNuoi() { }

        SqlConnection cnn;
        string cnstr;

        public void Init()
        {
            cnstr = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            cnn = new SqlConnection(cnstr);
        }
        /*public DataTable LoadTableVatNuoi(string sql)
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
                SqlCommand cmd = new SqlCommand("ThemVatNuoi", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ma_vatnuoi", SqlDbType.NVarChar, 50, "ma_vatnuoi");
                cmd.Parameters.Add("@ten_vatnuoi", SqlDbType.NVarChar, 50, "ten_vatnuoi");
                cmd.Parameters.Add("@ma_loai", SqlDbType.NVarChar, 50, "ma_loai");
                cmd.Parameters.Add("@ma_chuong", SqlDbType.NVarChar, 50, "ma_chuong");
                daVN.InsertCommand = cmd;

                //Delete cho VatNuoi
                cmd = new SqlCommand("XoaVatNuoi", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ma_vatnuoi", SqlDbType.NVarChar, 50, "ma_vatnuoi");
                daVN.DeleteCommand = cmd;

                //Update cho VatNuoi
                cmd = new SqlCommand("SuaVatNuoi", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ma_vatnuoi", SqlDbType.NVarChar, 50, "ma_vatnuoi");
                cmd.Parameters.Add("@ten_vatnuoi", SqlDbType.NVarChar, 50, "ten_vatnuoi");
                cmd.Parameters.Add("@ma_loai", SqlDbType.NVarChar, 50, "ma_loai");
                cmd.Parameters.Add("@ma_chuong", SqlDbType.NVarChar, 50, "ma_chuong");
                daVN.UpdateCommand = cmd;

                daVN.Update(dt);

                CountVatNuoichoLoai();
                CountVatNuoichoChuong();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public void XuatChuong(string ma_vatnuoi)
        {
            SqlCommand cmd = new SqlCommand("XuatChuong", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ma_vatnuoi", ma_vatnuoi);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void CountVatNuoichoLoai()
        {
            Init();
            DataTable table = Database.Instance.LoadTable("select ma_loai from Loai");
            foreach (DataRow dr in table.Rows)
            {
                SqlCommand cmd = new SqlCommand("CountVatNuoichoLoai", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ma_loai", dr[0].ToString());
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
        }
        public void CountVatNuoichoChuong()
        {
            Init();
            DataTable table = Database.Instance.LoadTable("select ma_chuong from Chuong");
            foreach (DataRow dr in table.Rows)
            {
                SqlCommand cmd = new SqlCommand("CountVatNuoichoChuong", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ma_chuong", dr[0].ToString());
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
        }

    }
}
