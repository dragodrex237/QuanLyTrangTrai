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
    public partial class FormLichSuBenh : Form
    {
        DataTable tableLSB;
        int RowIndexLSB;

        public FormLichSuBenh()
        {
            InitializeComponent();
        }

        private void FormLichSuBenh_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            LoadComboBox();
        }

        private void LoadDataGridView()
        {
            tableLSB = Database.Instance.LoadTable("select * from LichSuBenh");
            dataGridView1.DataSource = tableLSB;

            DataGridViewComboBoxColumn comboVN = new DataGridViewComboBoxColumn();
            DataTable dtVN = Database.Instance.LoadTable("select ma_vatnuoi, ten_vatnuoi from VatNuoi");
            comboVN.DataSource = dtVN;
            comboVN.DisplayMember = "ten_vatnuoi";
            comboVN.ValueMember = "ma_vatnuoi";
            comboVN.DataPropertyName = "ma_vatnuoi";
            comboVN.Name = "ten_vatnuoi";
            dataGridView1.Columns.RemoveAt(1);
            dataGridView1.Columns.Insert(1, comboVN);

            DataGridViewComboBoxColumn comboBenh = new DataGridViewComboBoxColumn();
            DataTable dtBenh = Database.Instance.LoadTable("select ma_benh, ten_benh from Benh");
            comboBenh.DataSource = dtBenh;
            comboBenh.DisplayMember = "ten_benh";
            comboBenh.ValueMember = "ma_benh";
            comboBenh.DataPropertyName = "ma_benh";
            comboBenh.Name = "ten_benh";
            dataGridView1.Columns.RemoveAt(2);
            dataGridView1.Columns.Insert(2, comboBenh);

            DataGridViewComboBoxColumn comboThuoc = new DataGridViewComboBoxColumn();
            DataTable dtThuoc = Database.Instance.LoadTable("select ma_thuoc, ten_thuoc from Thuoc");
            comboThuoc.DataSource = dtThuoc;
            comboThuoc.DisplayMember = "ten_thuoc";
            comboThuoc.ValueMember = "ma_thuoc";
            comboThuoc.DataPropertyName = "ma_thuoc";
            comboThuoc.Name = "ten_thuoc";
            dataGridView1.Columns.RemoveAt(3);
            dataGridView1.Columns.Insert(3, comboThuoc);

            dataGridView1.Columns[0].HeaderText = "Mã Lịch Sử Bệnh";
            dataGridView1.Columns[1].HeaderText = "Mã Vật Nuôi";
            dataGridView1.Columns[2].HeaderText = "Mã Bệnh";
            dataGridView1.Columns[3].HeaderText = "Mã Thuốc";
            dataGridView1.Columns[4].HeaderText = "Ngày Mắc Bệnh";
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if(LichSuBenh.Instance.SaveTableLSB(tableLSB))
                LoadDataGridView();
            else
                MessageBox.Show("Không thể cập nhật dữ liệu vào Cơ Sở Dữ Liệu được");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            RowIndexLSB = e.RowIndex;

            txtMVN.Text = dataGridView1.Rows[RowIndexLSB].Cells[0].Value.ToString();

            if (dataGridView1.Rows[RowIndexLSB].Cells[1].Value.ToString() == "")
                comboBox1.SelectedIndex = -1;
            else
                comboBox1.SelectedValue = dataGridView1.Rows[RowIndexLSB].Cells[1].Value.ToString();

            if (dataGridView1.Rows[RowIndexLSB].Cells[2].Value.ToString() == "")
                cbLoai.SelectedIndex = -1;
            else
                cbLoai.SelectedValue = dataGridView1.Rows[RowIndexLSB].Cells[2].Value.ToString();

            if (dataGridView1.Rows[RowIndexLSB].Cells[3].Value.ToString() == "")
                cbChuong.SelectedIndex = -1;
            else
                cbChuong.SelectedValue = dataGridView1.Rows[RowIndexLSB].Cells[3].Value.ToString();
        }
        public void LoadComboBox()
        {
            comboBox1.DataSource = Database.Instance.LoadTable("select ma_vatnuoi, ten_vatnuoi from VatNuoi");
            comboBox1.DisplayMember = "ten_vatnuoi";
            comboBox1.ValueMember = "ma_vatnuoi";
            comboBox1.SelectedIndex = -1;

            cbLoai.DataSource = Database.Instance.LoadTable("select ma_benh, ten_benh from Benh");
            cbLoai.DisplayMember = "ten_benh";
            cbLoai.ValueMember = "ma_benh";
            cbLoai.SelectedIndex = -1;

            cbChuong.DataSource = Database.Instance.LoadTable("select ma_thuoc, ten_thuoc from Thuoc");
            cbChuong.DisplayMember = "ten_thuoc";
            cbChuong.ValueMember = "ma_thuoc";
            cbChuong.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow dr = tableLSB.NewRow();
            dr[1] = comboBox1.SelectedValue;
            dr[2] = cbLoai.SelectedValue;
            dr[3] = cbChuong.SelectedValue;
            tableLSB.Rows.Add(dr);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableLSB.Rows[RowIndexLSB][1] = comboBox1.SelectedValue;
            tableLSB.Rows[RowIndexLSB][2] = cbLoai.SelectedValue;
            tableLSB.Rows[RowIndexLSB][3] = cbChuong.SelectedValue;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn xóa?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                tableLSB.RejectChanges();
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
            tableLSB.RejectChanges();
        }
        private bool ktMaVNThem(string MaVN)
        {
            bool kt = true;
            foreach (DataRow dr in tableLSB.Rows)
            {
                if (dr[0].ToString() == MaVN)
                    kt = false;
            }
            return kt;
        }
        private bool ktMaVNSua(string MaVN)
        {
            bool kt = true;
            for (int i = 0; i < tableLSB.Rows.Count; i++)
            {
                if (tableLSB.Rows[i][0].ToString() == MaVN && i != RowIndexLSB)
                    kt = false;
            }
            return kt;
        }
    }
}
