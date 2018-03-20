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
    public partial class FormBenh : Form
    {
        DataTable tableBN;
        int RowIndexBN;
        public FormBenh()
        {
            InitializeComponent();
        }

        private void FormBenh_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            LoadComboBox();
        }
        private void LoadDataGridView()
        {
            tableBN = Database.Instance.LoadTable("select * from Benh");
            dataGridView1.DataSource = tableBN;

            DataGridViewComboBoxColumn comboLoai = new DataGridViewComboBoxColumn();
            DataTable dtLoai = Database.Instance.LoadTable("select ma_loai, ten_loai from Loai");
            comboLoai.DataSource = dtLoai;
            comboLoai.DisplayMember = "ten_loai";
            comboLoai.ValueMember = "ma_loai";
            comboLoai.DataPropertyName = "ma_loai";
            comboLoai.Name = "ten_loai";
            dataGridView1.Columns.RemoveAt(2);
            dataGridView1.Columns.Insert(2, comboLoai);

            dataGridView1.Columns[0].HeaderText = "Mã Bệnh";
            dataGridView1.Columns[1].HeaderText = "Tên Bệnh";
            dataGridView1.Columns[2].HeaderText = "Loài";
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if(Benh.Instance.SaveTableBenh(tableBN))
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
                    DataRow dr = tableBN.NewRow();
                    dr[0] = txtMVN.Text;
                    dr[1] = txtTVN.Text;
                    dr[2] = cbLoai.SelectedValue;
                    tableBN.Rows.Add(dr);
                }
                else
                {
                    MessageBox.Show("Trùng Mã Bệnh");
                }
            }
            else
            {
                MessageBox.Show("Mã Bệnh không thể bỏ trống được");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtMVN.Text != "")
            {
                if (ktMaVNSua(txtMVN.Text))
                {
                    //tableBN.Rows[RowIndexBN][0] = txtMVN.Text;
                    tableBN.Rows[RowIndexBN][1] = txtTVN.Text;
                    tableBN.Rows[RowIndexBN][2] = cbLoai.SelectedValue;
                }
                else
                {
                    MessageBox.Show("Trùng Mã Bệnh");
                }
            }
            else
            {
                MessageBox.Show("Mã Bệnh không thể bỏ trống được");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn xóa?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                tableBN.RejectChanges();
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
            tableBN.RejectChanges();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            RowIndexBN = e.RowIndex;

            txtMVN.Text = dataGridView1.Rows[RowIndexBN].Cells[0].Value.ToString();
            txtTVN.Text = dataGridView1.Rows[RowIndexBN].Cells[1].Value.ToString();

            if (dataGridView1.Rows[RowIndexBN].Cells[2].Value.ToString() == "")
                cbLoai.SelectedIndex = -1;
            else
                cbLoai.SelectedValue = dataGridView1.Rows[RowIndexBN].Cells[2].Value.ToString();
        }
        public void LoadComboBox()
        {
            cbLoai.DataSource = Database.Instance.LoadTable("select ma_loai, ten_loai from Loai");
            cbLoai.DisplayMember = "ten_loai";
            cbLoai.ValueMember = "ma_loai";
            cbLoai.SelectedIndex = -1;
        }

        private bool ktMaVNThem(string MaVN)
        {
            bool kt = true;
            foreach (DataRow dr in tableBN.Rows)
            {
                if (dr[0].ToString() == MaVN)
                    kt = false;
            }
            return kt;
        }
        private bool ktMaVNSua(string MaVN)
        {
            bool kt = true;
            for (int i = 0; i < tableBN.Rows.Count; i++)
            {
                if (tableBN.Rows[i][0].ToString() == MaVN && i != RowIndexBN)
                    kt = false;
            }
            return kt;
        }
    }
}
