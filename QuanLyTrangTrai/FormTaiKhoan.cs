using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanLyTrangTrai
{
    public partial class FormTaiKhoan : Form
    {
        DataTable tableTK;
        int RowIndexTK;

        public FormTaiKhoan()
        {
            InitializeComponent();
        }

        private void FormTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            LoadComboBox();
        }
        private void LoadDataGridView()
        {
            tableTK = Database.Instance.LoadTable("select * from TaiKhoan");
            dataGridView1.DataSource = tableTK;

            DataGridViewComboBoxColumn comboLoai = new DataGridViewComboBoxColumn();
            DataTable dtLoai = Database.Instance.LoadTable("select * from LoaiTK");
            comboLoai.DataSource = dtLoai;
            comboLoai.DisplayMember = "ten_loaiTK";
            comboLoai.ValueMember = "ma_loaiTK";
            comboLoai.DataPropertyName = "ma_loaiTK";
            comboLoai.Name = "ten_loaiTK";
            dataGridView1.Columns.RemoveAt(2);
            dataGridView1.Columns.Insert(2, comboLoai);

            dataGridView1.Columns[0].HeaderText = "Username";
            dataGridView1.Columns[1].HeaderText = "Password";
            dataGridView1.Columns[2].HeaderText = "Loại Tài Khoản";
        }
        private void LoadComboBox()
        {
            cbLoai.DataSource = Database.Instance.LoadTable("select * from LoaiTK");

            cbLoai.ValueMember = "ma_loaiTK";
            cbLoai.DisplayMember= "ten_loaiTK";

            cbLoai.SelectedIndex = -1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            RowIndexTK = e.RowIndex;

            txtMVN.Text = dataGridView1.Rows[RowIndexTK].Cells[0].Value.ToString();
            txtTVN.Text = dataGridView1.Rows[RowIndexTK].Cells[1].Value.ToString();

            if (dataGridView1.Rows[RowIndexTK].Cells[2].Value.ToString() == "")
                cbLoai.SelectedIndex = -1;
            else
                cbLoai.SelectedValue = dataGridView1.Rows[RowIndexTK].Cells[2].Value.ToString();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if(DangNhap.Instance.SaveTableTaiKhoan(tableTK))
                LoadDataGridView();
            else
                MessageBox.Show("Không thể cập nhật dữ liệu vào Cơ Sở Dữ Liệu được");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMVN.Text != "")
            {
                if (ktMaVNThem(txtMVN.Text))
                {
                    DataRow dr = tableTK.NewRow();
                    dr[0] = txtMVN.Text;
                    dr[1] = txtTVN.Text;
                    dr[2] = cbLoai.SelectedValue;
                    tableTK.Rows.Add(dr);
                }
                else
                {
                    MessageBox.Show("Trùng Username");
                }
            }
            else
            {
                MessageBox.Show("Username không thể bỏ trống được");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtMVN.Text != "")
            {
                if (ktMaVNSua(txtMVN.Text))
                {
                    //tableTK.Rows[RowIndexTK][0] = txtMVN.Text;
                    tableTK.Rows[RowIndexTK][1] = txtTVN.Text;
                    tableTK.Rows[RowIndexTK][2] = cbLoai.SelectedValue;
                }
                else
                {
                    MessageBox.Show("Trùng Username");
                }
            }
            else
            {
                MessageBox.Show("Username không thể bỏ trống được");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn xóa?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                tableTK.RejectChanges();
            else
            {
                try
                {
                    dataGridView1.Rows.RemoveAt(RowIndexTK);
                }
                catch
                {
                    MessageBox.Show("Hãy xóa từng dòng chứ đừng xóa tất cả");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tableTK.RejectChanges();
        }

        private bool ktMaVNThem(string MaVN)
        {
            bool kt = true;
            foreach (DataRow dr in tableTK.Rows)
            {
                if (dr[0].ToString() == MaVN)
                    kt = false;
            }
            return kt;
        }
        private bool ktMaVNSua(string MaVN)
        {
            bool kt = true;
            for (int i = 0; i < tableTK.Rows.Count; i++)
            {
                if (tableTK.Rows[i][0].ToString() == MaVN && i != RowIndexTK)
                    kt = false;
            }
            return kt;
        }
    }
}
