using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanLyTrangTrai
{
    public class DangNhap
    {
        private static DangNhap instance;

        public static DangNhap Instance
        {
            get { if (instance == null) { instance = new DangNhap(); } return DangNhap.instance; }
            private set { DangNhap.instance = value; }
        }
        private DangNhap() { }

        SqlConnection cnn;
        string cnstr;

        public void Init()
        {
            cnstr = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            cnn = new SqlConnection(cnstr);
        }
        /*public DataTable LoadTableTaiKhoan(string sql)
        {
            Init();
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }*/
        public bool Login(string usename, string password)
        {
            Init();
            string sql = "select * from TaiKhoan where usename = '" + usename + "' and password = '" + password + "'";
            DataTable table = Database.Instance.LoadTable(sql);
            if (table.Rows.Count > 0)
            {
                Form1.LTK = Int32.Parse(table.Rows[0][2].ToString());
                Form1.tenTK = table.Rows[0][0].ToString();
            }
            return table.Rows.Count > 0;
        }
        public bool SaveTableTaiKhoan(DataTable dt)
        {
            try
            {
                Init();
                SqlDataAdapter daVN = new SqlDataAdapter();
                //Insert cho VatNuoi
                SqlCommand cmd = new SqlCommand("insert into TaiKhoan(usename, password, ma_loaiTK) values(@usename, @password, @ma_loaiTK)", cnn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@usename", SqlDbType.NVarChar, 50, "usename");
                cmd.Parameters.Add("@password", SqlDbType.NVarChar, 50, "password");
                cmd.Parameters.Add("@ma_loaiTK", SqlDbType.Int, 50, "ma_loaiTK");
                daVN.InsertCommand = cmd;

                //Delete cho VatNuoi
                cmd = new SqlCommand("delete from TaiKhoan where usename = @usename", cnn);
                cmd.Parameters.Add("@usename", SqlDbType.NVarChar, 50, "usename");
                daVN.DeleteCommand = cmd;

                //Update cho VatNuoi
                cmd = new SqlCommand("update TaiKhoan set password = @password, ma_loaiTK = @ma_loaiTK where usename = @usename", cnn);
                cmd.Parameters.Add("@usename", SqlDbType.NVarChar, 50, "usename");
                cmd.Parameters.Add("@password", SqlDbType.NVarChar, 50, "password");
                cmd.Parameters.Add("@ma_loaiTK", SqlDbType.Int, 50, "ma_loaiTK");
                daVN.UpdateCommand = cmd;

                daVN.Update(dt);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DoiMatKhau(string tk, string mk1, string mk2, string mk3)
        {
            Init();
            string sql = "select * from TaiKhoan where usename = '" + tk + "' and password = '" + mk1 + "'";
            DataTable table = Database.Instance.LoadTable(sql);
            if (table.Rows.Count > 0 && mk2.Equals(mk3))
            {
                Init();
                cnn.Open();
                SqlCommand cmd = new SqlCommand("update TaiKhoan set password = '" + mk2 + "' where usename = '" + tk + "'", cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
