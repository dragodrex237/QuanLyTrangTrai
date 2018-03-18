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
    public partial class FormChuong : Form
    {
        DataTable tableChuong;
        int RowIndexCH;

        public FormChuong()
        {
            InitializeComponent();
        }

        private void FormChuong_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            LoadComboBox();
        }
        private void LoadDataGridView()
        {
            tableChuong = Database.Instance.LoadTable("select * from Chuong");
            dataGridView1.DataSource = tableChuong;

            DataGridViewComboBoxColumn comboLoai = new DataGridViewComboBoxColumn();
            DataTable dtLoai = Database.Instance.LoadTable("select ma_loai, ten_loai from Loai");
            comboLoai.DataSource = dtLoai;
            comboLoai.DisplayMember = "ten_loai";
            comboLoai.ValueMember = "ma_loai";
            comboLoai.DataPropertyName = "ma_loai";
            comboLoai.Name = "ten_loai";
            dataGridView1.Columns.RemoveAt(2);
            dataGridView1.Columns.Insert(2, comboLoai);

            dataGridView1.Columns[0].HeaderText = "Mã Chuồng";
            dataGridView1.Columns[1].HeaderText = "Tên Chuồng";
            dataGridView1.Columns[2].HeaderText = "Loài";
            dataGridView1.Columns[3].HeaderText = "Số Lượng";
            dataGridView1.Columns[4].HeaderText = "Số Lượng Tối Đa";
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if(Chuong.Instance.SaveTableChuong(tableChuong))
                LoadDataGridView();
            else
                MessageBox.Show("Không thể cập nhật dữ liệu vào Cơ Sở Dữ Liệu được");
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            RowIndexCH = e.RowIndex;

            txtMVN.Text = dataGridView1.Rows[RowIndexCH].Cells[0].Value.ToString();
            txtTVN.Text = dataGridView1.Rows[RowIndexCH].Cells[1].Value.ToString();

            if (dataGridView1.Rows[RowIndexCH].Cells[2].Value.ToString() == "")
                cbLoai.SelectedIndex = -1;
            else
                cbLoai.SelectedValue = dataGridView1.Rows[RowIndexCH].Cells[2].Value.ToString();

            txtSLTD.Text = dataGridView1.Rows[RowIndexCH].Cells[4].Value.ToString();

        }
        public void LoadComboBox()
        {
            cbLoai.DataSource = Database.Instance.LoadTable("select ma_loai, ten_loai from Loai");
            cbLoai.DisplayMember = "ten_loai";
            cbLoai.ValueMember = "ma_loai";
            cbLoai.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMVN.Text != "")
            {
                if (ktMaVNThem(txtMVN.Text))
                {
                    DataRow dr = tableChuong.NewRow();
                    dr[0] = txtMVN.Text;
                    dr[1] = txtTVN.Text;
                    dr[2] = cbLoai.SelectedValue;
                    if (txtSLTD.Text == "")
                        dr[4] = "10";
                    else
                        dr[4] = txtSLTD.Text;
                    tableChuong.Rows.Add(dr);
                }
                else
                {
                    MessageBox.Show("Trùng Mã Chuồng");
                }
            }
            else
            {
                MessageBox.Show("Mã Chuồng không thể bỏ trống được");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtMVN.Text != "")
            {
                if (ktMaVNSua(txtMVN.Text))
                {
                    //tableChuong.Rows[RowIndexCH][0] = txtMVN.Text;
                    tableChuong.Rows[RowIndexCH][1] = txtTVN.Text;
                    tableChuong.Rows[RowIndexCH][2] = cbLoai.SelectedValue;
                    tableChuong.Rows[RowIndexCH][3] = txtSLTD.Text;
                }
                else
                {
                    MessageBox.Show("Trùng Mã Chuồng");
                }
            }
            else
            {
                MessageBox.Show("Mã Chuồng không thể bỏ trống được");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn xóa?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                tableChuong.RejectChanges();
            else
            {
                try
                {
                    dataGridView1.Rows.RemoveAt(RowIndexCH);
                }
                catch
                {
                    MessageBox.Show("Hãy xóa từng dòng chứ đừng xóa tất cả");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tableChuong.RejectChanges();
        }
        private bool ktMaVNThem(string MaCH)
        {
            bool kt = true;
            foreach (DataRow dr in tableChuong.Rows)
            {
                if (dr[0].ToString() == MaCH)
                    kt = false;
            }
            return kt;
        }
        private bool ktMaVNSua(string MaVN)
        {
            bool kt = true;
            for (int i = 0; i < tableChuong.Rows.Count; i++)
            {
                if (tableChuong.Rows[i][0].ToString() == MaVN && i != RowIndexCH)
                    kt = false;
            }
            return kt;
        }
    }
}
