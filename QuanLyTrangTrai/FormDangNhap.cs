﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyTrangTrai
{
    public partial class FormDangNhap : Form
    {
        public static bool KTCSDL = true;

        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetLogin();
        }
        private void GetLogin()
        {
            if (txtUsename.Text != "")
            {
                if (txtPassword.Text != "")
                {
                    try
                    {
                        if (DangNhap.Instance.Login(txtUsename.Text, txtPassword.Text))
                        {
                            Form1 form1 = new Form1();
                            this.Hide();
                            form1.ShowDialog();
                            this.Show();
                        }
                        else
                        {
                            MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Không thể tìm thấy bảng. Vui lòng chạy lại Cơ Sở Dữ Liệu trong Sql Server");
                    }
                }
                else
                    MessageBox.Show("Không được bỏ trống password");
            }
            else
                MessageBox.Show("Không được bỏ trống username");
        }
        private void FormDangNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void FormDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetLogin();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetLogin();
            }
        }

        private void txtUsename_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            int test = Database.Instance.Test();
            if (test == 0)
            {
                KTCSDL = false;
                FormNhapCSDL fm = new FormNhapCSDL();
                fm.ShowDialog();
                if (KTCSDL == false)
                {
                    this.Close();
                    Environment.Exit(1);
                }
            }
            button1.Focus();
        }
    }
}
