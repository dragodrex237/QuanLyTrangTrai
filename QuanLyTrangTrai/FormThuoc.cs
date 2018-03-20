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
    public partial class FormThuoc : Form
    {
        DataTable tableTH;
        int RowIndexTH;

        public FormThuoc()
        {
            InitializeComponent();
        }

        private void FormThuoc_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            tableTH = Database.Instance.LoadTable("select * from Thuoc");
            dataGridView1.DataSource = tableTH;

            dataGridView1.Columns[0].HeaderText = "Mã Thuốc";
            dataGridView1.Columns[1].HeaderText = "Tên Thuốc";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            RowIndexTH = e.RowIndex;

            txtMVN.Text = dataGridView1.Rows[RowIndexTH].Cells[0].Value.ToString();
            txtTVN.Text = dataGridView1.Rows[RowIndexTH].Cells[1].Value.ToString();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if(Thuoc.Instance.SaveTableThuoc(tableTH))
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
                    DataRow dr = tableTH.NewRow();
                    dr[0] = txtMVN.Text;
                    dr[1] = txtTVN.Text;
                    tableTH.Rows.Add(dr);
                }
                else
                {
                    MessageBox.Show("Trùng Mã Thuốc");
                }
            }
            else
            {
                MessageBox.Show("Mã Thuốc không thể bỏ trống được");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtMVN.Text != "")
            {
                if (ktMaVNSua(txtMVN.Text))
                {
                    //tableTH.Rows[RowIndexTH][0] = txtMVN.Text;
                    tableTH.Rows[RowIndexTH][1] = txtTVN.Text;
                }
                else
                {
                    MessageBox.Show("Trùng Mã Thuốc");
                }
            }
            else
            {
                MessageBox.Show("Mã Thuốc không thể bỏ trống được");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn xóa?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                tableTH.RejectChanges();
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
            tableTH.RejectChanges();
        }

        private bool ktMaVNThem(string MaVN)
        {
            bool kt = true;
            foreach (DataRow dr in tableTH.Rows)
            {
                if (dr[0].ToString() == MaVN)
                    kt = false;
            }
            return kt;
        }
        private bool ktMaVNSua(string MaVN)
        {
            bool kt = true;
            for (int i = 0; i < tableTH.Rows.Count; i++)
            {
                if (tableTH.Rows[i][0].ToString() == MaVN && i != RowIndexTH)
                    kt = false;
            }
            return kt;
        }
    }
}
