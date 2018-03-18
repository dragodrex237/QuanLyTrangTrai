using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyTrangTrai
{
    public partial class FormDMK : Form
    {
        public static bool change = false;
        public FormDMK()
        {
            InitializeComponent();
        }

        private void FormDMK_Load(object sender, EventArgs e)
        {
            txtUsename.Text = Form1.tenTK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangePassword();
        }
        private void ChangePassword()
        {
            if (txtUsename.Text == "")
            {
                MessageBox.Show("Không được bỏ trống tài khoản");
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Không được bỏ trống mật khẩu cũ");
                return;
            }
            if (textBox1.Text != "")
            {
                if (textBox2.Text != "")
                {
                    if (textBox1.Text == textBox2.Text)
                    {
                        if (DangNhap.Instance.DoiMatKhau(txtUsename.Text, txtPassword.Text, textBox1.Text, textBox2.Text))
                        {
                            MessageBox.Show("Bạn đã đổi mật khẩu thành công!");
                            change = true;
                            this.Close();
                        }
                        else
                            MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                    }
                    else
                        MessageBox.Show("Mật khẩu xác nhận không khớp với mật khẩu mới");
                }
                else
                    MessageBox.Show("Không được bỏ trống mật khẩu xác nhận");
            }
            else
                MessageBox.Show("Không được bỏ trống mật khẩu mới");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsename_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChangePassword();
            }
        }
    }
}
