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
    public partial class Form1 : Form
    {
        public static int LTK;
        public static string tenTK;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void btVN_Click(object sender, EventArgs e)
        {
            FormVatNuoi fVN = new FormVatNuoi();
            fVN.ShowDialog();
        }

        private void btLoai_Click(object sender, EventArgs e)
        {
            if (LTK == 1)
            {
                FormLoai fLoai = new FormLoai();
                fLoai.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không đủ thẩm quyền để truy cập chức năng này");
            }
        }

        private void btCH_Click(object sender, EventArgs e)
        {
            FormChuong fChuong = new FormChuong();
            fChuong.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            if (LTK == 1)
            {
                labelTK.Text = "Xin chào Quản Trị Viên";
            }
            else
            {
                labelTK.Text = "Xin chào Nhân Viên";
            }
            labelTK.Text += " " + tenTK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (LTK == 1)
            {
                FormTaiKhoan formTK = new FormTaiKhoan();
                formTK.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không đủ thẩm quyền để truy cập chức năng này");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormDMK formDMK = new FormDMK();
            formDMK.ShowDialog();
            if(FormDMK.change)
                this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (LTK == 1)
            {
                FormNhanVien formNV = new FormNhanVien();
                formNV.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không đủ thẩm quyền để truy cập chức năng này");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormLichSuBenh fLSB = new FormLichSuBenh();
            fLSB.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormBenh fBN = new FormBenh();
            fBN.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormThuoc fTH = new FormThuoc();
            fTH.ShowDialog();
        }
    }
}
