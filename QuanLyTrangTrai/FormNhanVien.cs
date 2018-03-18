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
    public partial class FormNhanVien : Form
    {
        DataTable tableNV;
        int RowIndexNV;

        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            LoadComboBox();
        }
        private void LoadDataGridView()
        {
            tableNV = Database.Instance.LoadTable("select NhanVien.*, LoaiNhanVien.luong from NhanVien, LoaiNhanVien where NhanVien.ma_loaiNV = LoaiNhanVien.ma_loaiNV");
            //tableNV = NhanVien.Instance.LoadTableChuong("select * from NhanVien");
            dataGridView1.DataSource = tableNV;

            DataGridViewComboBoxColumn comboLoai = new DataGridViewComboBoxColumn();
            DataTable dtLoai = Database.Instance.LoadTable("select ma_loaiNV, ten_loaiNV from LoaiNhanVien");
            comboLoai.DataSource = dtLoai;
            comboLoai.DisplayMember = "ten_loaiNV";
            comboLoai.ValueMember = "ma_loaiNV";
            comboLoai.DataPropertyName = "ma_loaiNV";
            comboLoai.Name = "ten_loaiNV";
            dataGridView1.Columns.RemoveAt(2);
            dataGridView1.Columns.Insert(2, comboLoai);

            dataGridView1.Columns[0].HeaderText = "Mã Nhân Viên";
            dataGridView1.Columns[1].HeaderText = "Tên Nhân Viên";
            dataGridView1.Columns[2].HeaderText = "Loại Nhân Viên";
            dataGridView1.Columns[3].HeaderText = "Số Điện Thoại";
            dataGridView1.Columns[4].HeaderText = "Lương";
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if(NhanVien.Instance.SaveTableNhanVien(tableNV))
                LoadDataGridView();
            else
                MessageBox.Show("Không thể cập nhật dữ liệu vào Cơ Sở Dữ Liệu được");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            RowIndexNV = e.RowIndex;

            txtMVN.Text = dataGridView1.Rows[RowIndexNV].Cells[0].Value.ToString();
            txtTVN.Text = dataGridView1.Rows[RowIndexNV].Cells[1].Value.ToString();

            if (dataGridView1.Rows[RowIndexNV].Cells[2].Value.ToString() == "")
                cbLoai.SelectedIndex = -1;
            else
                cbLoai.SelectedValue = dataGridView1.Rows[RowIndexNV].Cells[2].Value.ToString();

            txtSLTD.Text = dataGridView1.Rows[RowIndexNV].Cells[3].Value.ToString();
        }
        public void LoadComboBox()
        {
            cbLoai.DataSource = Database.Instance.LoadTable("select ma_loaiNV, ten_loaiNV from LoaiNhanVien");
            cbLoai.DisplayMember = "ten_loaiNV";
            cbLoai.ValueMember = "ma_loaiNV";
            cbLoai.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMVN.Text != "")
            {
                if (ktMaVNThem(txtMVN.Text))
                {
                    DataRow dr = tableNV.NewRow();
                    dr[0] = txtMVN.Text;
                    dr[1] = txtTVN.Text;
                    dr[2] = cbLoai.SelectedValue;
                    dr[3] = txtSLTD.Text;
                    tableNV.Rows.Add(dr);
                }
                else
                {
                    MessageBox.Show("Trùng Mã Nhân Viên");
                }
            }
            else
            {
                MessageBox.Show("Mã Nhân Viên không thể bỏ trống được");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtMVN.Text != "")
            {
                if (ktMaVNSua(txtMVN.Text))
                {
                    //tableNV.Rows[RowIndexNV][0] = txtMVN.Text;
                    tableNV.Rows[RowIndexNV][1] = txtTVN.Text;
                    tableNV.Rows[RowIndexNV][2] = cbLoai.SelectedValue;
                    tableNV.Rows[RowIndexNV][3] = txtSLTD.Text;
                }
                else
                {
                    MessageBox.Show("Trùng Mã Nhân Viên");
                }
            }
            else
            {
                MessageBox.Show("Mã Nhân Viên không thể bỏ trống được");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn xóa?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                tableNV.RejectChanges();
            else
            {
                try
                {
                    dataGridView1.Rows.RemoveAt(RowIndexNV);
                }
                catch
                {
                    MessageBox.Show("Hãy xóa từng dòng chứ đừng xóa tất cả");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tableNV.RejectChanges();
        }

        private bool ktMaVNThem(string MaVN)
        {
            bool kt = true;
            foreach (DataRow dr in tableNV.Rows)
            {
                if (dr[0].ToString() == MaVN)
                    kt = false;
            }
            return kt;
        }
        private bool ktMaVNSua(string MaVN)
        {
            bool kt = true;
            for (int i = 0; i < tableNV.Rows.Count; i++)
            {
                if (tableNV.Rows[i][0].ToString() == MaVN && i != RowIndexNV)
                    kt = false;
            }
            return kt;
        }
    }
}
