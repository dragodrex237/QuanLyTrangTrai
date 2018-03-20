using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanLyTrangTrai
{
    class Thuoc
    {
        private static Thuoc instance;

        internal static Thuoc Instance
        {
            get { if (instance == null) { instance = new Thuoc(); } return Thuoc.instance; }
            private set { Thuoc.instance = value; }
        }
        private Thuoc() { }

        SqlConnection cnn;
        string cnstr;

        public void Init()
        {
            cnstr = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            cnn = new SqlConnection(cnstr);
        }
        /*public DataTable LoadTableThuoc(string sql)
        {
            Init();
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }*/
        public bool SaveTableThuoc(DataTable dt)
        {
            try
            {
                Init();
                SqlDataAdapter daVN = new SqlDataAdapter();
                //Insert cho VatNuoi
                SqlCommand cmd = new SqlCommand("insert into Thuoc(ma_thuoc, ten_thuoc) values(@ma_thuoc, @ten_thuoc)", cnn);
                cmd.Parameters.Add("@ma_thuoc", SqlDbType.NVarChar, 50, "ma_thuoc");
                cmd.Parameters.Add("@ten_thuoc", SqlDbType.NVarChar, 50, "ten_thuoc");
                daVN.InsertCommand = cmd;

                //Delete cho VatNuoi
                cmd = new SqlCommand("delete from Thuoc where ma_thuoc = @ma_thuoc", cnn);
                cmd.Parameters.Add("@ma_thuoc", SqlDbType.NVarChar, 50, "ma_thuoc");
                daVN.DeleteCommand = cmd;

                //Update cho VatNuoi
                cmd = new SqlCommand("update Thuoc set ten_thuoc = @ten_thuoc where ma_thuoc = @ma_thuoc", cnn);
                cmd.Parameters.Add("@ma_thuoc", SqlDbType.NVarChar, 50, "ma_thuoc");
                cmd.Parameters.Add("@ten_thuoc", SqlDbType.NVarChar, 50, "ten_thuoc");
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
