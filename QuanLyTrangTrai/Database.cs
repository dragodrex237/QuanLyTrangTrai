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
            try
            {
                Init();
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch
            {
                throw;
            }
        }
        public int Test()
        {
            cnstr = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cnstr))
            {
                try
                {
                    cnn.Open();
                    if (cnn.State == ConnectionState.Open)
                    {
                        /*SqlCommand cmd = new SqlCommand("select * from VatNuoi");
                        cmd.ExecuteNonQuery();*/
                        return 1;
                    }
                    else
                        return 0;
                }
                catch
                {
                    return 0;
                }
            }
        }
    }
}
