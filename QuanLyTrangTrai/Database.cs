using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanLyTrangTrai
{
    public class Database
    {
        private static Database instance;

        public static Database Instance
        {
            get { if (instance == null) { instance = new Database(); } return Database.instance; }
            private set { Database.instance = value; }
        }
        public Database() { }

        SqlConnection cnn;
        string cnstr;

        public void Init()
        {
            cnstr = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            cnn = new SqlConnection(cnstr);
        }
        public DataTable LoadTable(string sql)
        {
            Init();
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
