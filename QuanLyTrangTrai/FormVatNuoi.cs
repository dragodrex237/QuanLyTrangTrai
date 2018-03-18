using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyTrangTrai
{
    public partial class FormVatNuoi : Form
    {
        
        DataTable tableVN;
        int RowIndexVN;

        public FormVatNuoi()
        {
            InitializeComponent();
        }

        private void FormVatNuoi_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            LoadComboBox();
        }
        private void LoadDataGridView()
        {
            tableVN = Database.Instance.LoadTable("select * from VatNuoi");
            dataGridView1.DataSource = tableVN;

            DataGridViewComboBoxColumn comboLoai = new DataGridViewComboBoxColumn();
            DataTable dtLoai = Database.Instance.LoadTable("select ma_loai, ten_loai from Loai");
            comboLoai.DataSource = dtLoai;
            comboLoai.DisplayMember = "ten_loai";
            comboLoai.ValueMember = "ma_loai";
            comboLoai.DataPropertyName = "ma_loai";
            comboLoai.Name = "ten_loai";
            dataGridView1.Columns.RemoveAt(2);
            dataGridView1.Columns.Insert(2, comboLoai);

            DataGridViewComboBoxColumn comboChuong = new DataGridViewComboBoxColumn();
            DataTable dtChuong = Database.Instance.LoadTable("select ma_chuong, ten_chuong from Chuong");
            comboChuong.DataSource = dtChuong;
            comboChuong.DisplayMember = "ten_chuong";
            comboChuong.ValueMember = "ma_chuong";
            comboChuong.DataPropertyName = "ma_chuong";
            comboChuong.Name = "ten_chuong";
            dataGridView1.Columns.RemoveAt(3);
            dataGridView1.Columns.Insert(3, comboChuong);

            dataGridView1.Columns[0].HeaderText = "Mã Vật Nuôi";
            dataGridView1.Columns[1].HeaderText = "Tên Vật Nuôi";
            dataGridView1.Columns[2].HeaderText = "Loài";
            dataGridView1.Columns[3].HeaderText = "Chuồng";
            dataGridView1.Columns[4].HeaderText = "Ngày Nhập";
            dataGridView1.Columns[5].HeaderText = "Ngày Xuất";
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if(VatNuoi.Instance.SaveTableVatNuoi(tableVN))
                LoadDataGridView();
            else
                MessageBox.Show("Không thể cập nhật dữ liệu vào Cơ Sở Dữ Liệu được");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            RowIndexVN = e.RowIndex;

            txtMVN.Text = dataGridView1.Rows[RowIndexVN].Cells[0].Value.ToString();
            txtTVN.Text = dataGridView1.Rows[RowIndexVN].Cells[1].Value.ToString();

            if (dataGridView1.Rows[RowIndexVN].Cells[2].Value.ToString() == "")
                cbLoai.SelectedIndex = -1;
            else
                cbLoai.SelectedValue = dataGridView1.Rows[RowIndexVN].Cells[2].Value.ToString();

            if (dataGridView1.Rows[RowIndexVN].Cells[3].Value.ToString() == "")
                cbChuong.SelectedIndex = -1;
            else
                cbChuong.SelectedValue = dataGridView1.Rows[RowIndexVN].Cells[3].Value.ToString();
        }
        public void LoadComboBox()
        {
            cbLoai.DataSource = Database.Instance.LoadTable("select ma_loai, ten_loai from Loai");
            cbLoai.DisplayMember = "ten_loai";
            cbLoai.ValueMember = "ma_loai";
            cbLoai.SelectedIndex = -1;

            cbChuong.DataSource = Database.Instance.LoadTable("select ma_chuong, ten_chuong from Chuong");
            cbChuong.DisplayMember = "ten_chuong";
            cbChuong.ValueMember = "ma_chuong";
            cbChuong.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMVN.Text != "")
            {
                if (ktMaVNThem(txtMVN.Text))
                {
                    DataRow dr = tableVN.NewRow();
                    dr[0] = txtMVN.Text;
                    dr[1] = txtTVN.Text;
                    dr[2] = cbLoai.SelectedValue;
                    dr[3] = cbChuong.SelectedValue;
                    tableVN.Rows.Add(dr);
                }
                else
                {
                    MessageBox.Show("Trùng Mã Vật Nuôi");
                }
            }
            else
            {
                MessageBox.Show("Mã Vật Nuôi không thể bỏ trống được");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtMVN.Text != "")
            {
                if (ktMaVNSua(txtMVN.Text))
                {
                    //tableVN.Rows[RowIndexVN][0] = txtMVN.Text;
                    tableVN.Rows[RowIndexVN][1] = txtTVN.Text;
                    tableVN.Rows[RowIndexVN][2] = cbLoai.SelectedValue;
                    tableVN.Rows[RowIndexVN][3] = cbChuong.SelectedValue;
                }
                else
                {
                    MessageBox.Show("Trùng Mã Vật Nuôi");
                }
            }
            else
            {
                MessageBox.Show("Mã Vật Nuôi không thể bỏ trống được");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn xóa?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                tableVN.RejectChanges();
            else
            {
                try
                {
                    foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                    {
                        int RowIndex = cell.RowIndex;
                        dataGridView1.Rows.RemoveAt(RowIndex);
                    }
                }
                catch
                {
                    MessageBox.Show("Hãy xóa từng dòng chứ đừng xóa tất cả");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tableVN.RejectChanges();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtMVN.Text != "")
            {
                VatNuoi.Instance.XuatChuong(txtMVN.Text);
            }
            LoadDataGridView();
        }
        private bool ktMaVNThem(string MaVN)
        {
            bool kt = true;
            foreach (DataRow dr in tableVN.Rows)
            {
                if (dr[0].ToString() == MaVN)
                    kt = false;
            }
            return kt;
        }
        private bool ktMaVNSua(string MaVN)
        {
            bool kt = true;
            for (int i = 0; i < tableVN.Rows.Count; i++)
            {
                if (tableVN.Rows[i][0].ToString() == MaVN && i != RowIndexVN)
                    kt = false;
            }
            return kt;
        }
    }
}
