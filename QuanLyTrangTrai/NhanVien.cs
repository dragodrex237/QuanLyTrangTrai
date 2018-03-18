using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanLyTrangTrai
{
    class NhanVien
    {
        private static NhanVien instance;

        internal static NhanVien Instance
        {
            get { if (instance == null) { instance = new NhanVien(); } return NhanVien.instance; }
            private set { NhanVien.instance = value; }
        }
        private NhanVien() { }

        SqlConnection cnn;
        string cnstr;

        public void Init()
        {
            cnstr = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            cnn = new SqlConnection(cnstr);
        }
        /*public DataTable LoadTableNhanVien(string sql)
        {
            Init();
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }*/
        public bool SaveTableNhanVien(DataTable dt)
        {
            try
            {
                Init();
                SqlDataAdapter daVN = new SqlDataAdapter();
                //Insert cho VatNuoi
                SqlCommand cmd = new SqlCommand("insert into NhanVien(ma_NV, ten_NV, ma_loaiNV, dienthoai) values(@ma_NV, @ten_NV, @ma_loaiNV, @dienthoai)", cnn);
                cmd.Parameters.Add("@ma_NV", SqlDbType.NVarChar, 50, "ma_NV");
                cmd.Parameters.Add("@ten_NV", SqlDbType.NVarChar, 50, "ten_NV");
                cmd.Parameters.Add("@ma_loaiNV", SqlDbType.NVarChar, 50, "ma_loaiNV");
                cmd.Parameters.Add("@dienthoai", SqlDbType.NVarChar, 50, "dienthoai");
                daVN.InsertCommand = cmd;

                //Delete cho VatNuoi
                cmd = new SqlCommand("delete from NhanVien where ma_NV = @ma_NV", cnn);
                cmd.Parameters.Add("@ma_NV", SqlDbType.NVarChar, 50, "ma_NV");
                daVN.DeleteCommand = cmd;

                //Update cho VatNuoi
                cmd = new SqlCommand("update NhanVien set ten_NV = @ten_NV, ma_loaiNV = @ma_loaiNV, dienthoai = @dienthoai where ma_NV = @ma_NV", cnn);
                cmd.Parameters.Add("@ma_NV", SqlDbType.NVarChar, 50, "ma_NV");
                cmd.Parameters.Add("@ten_NV", SqlDbType.NVarChar, 50, "ten_NV");
                cmd.Parameters.Add("@ma_loaiNV", SqlDbType.NVarChar, 50, "ma_loaiNV");
                cmd.Parameters.Add("@dienthoai", SqlDbType.NVarChar, 50, "dienthoai");
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
