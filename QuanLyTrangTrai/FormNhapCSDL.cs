using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace QuanLyTrangTrai
{
    public partial class FormNhapCSDL : Form
    {
        public FormNhapCSDL()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadServer();
        }

        private void LoadServer()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["cnstr"].ConnectionString = "Server = " + textBox1.Text + "; Database = TrangTrai; Integrated Security = true;";
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");
            int test = Database.Instance.Test();
            if (test == 0)
            {
                MessageBox.Show("Không thể kết nối CSDL. Bạn đã nhập sai Tên Sql Server hoặc bạn chưa có CSDL QLChanNuoi (Vui lòng xem lại hướng dẫn để chạy chương trình đúng cách) ");
            }
            else
            {
                FormDangNhap.KTCSDL = true;
                this.Close();
            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadServer();
            }
        }
    }
}
