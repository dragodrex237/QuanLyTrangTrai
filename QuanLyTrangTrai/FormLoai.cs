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
    public partial class FormLoai : Form
    {
        DataTable tableLoai;
        int RowIndexL;

        public FormLoai()
        {
            InitializeComponent();
        }
        

        private void FormLoai_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            tableLoai = Database.Instance.LoadTable("select * from Loai");
            dataGridView1.DataSource = tableLoai;

            dataGridView1.Columns[0].HeaderText = "Mã Loài";
            dataGridView1.Columns[1].HeaderText = "Tên Loài";
            dataGridView1.Columns[2].HeaderText = "Số Lượng Vật Nuôi";
            dataGridView1.Columns[3].HeaderText = "Số Lượng Chuồng";
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if(Loai.Instance.SaveTableVatNuoi(tableLoai))
                LoadDataGridView();
            else
                MessageBox.Show("Không thể cập nhật dữ liệu vào Cơ Sở Dữ Liệu");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            RowIndexL = e.RowIndex;

            txtML.Text = dataGridView1.Rows[RowIndexL].Cells[0].Value.ToString();
            txtTL.Text = dataGridView1.Rows[RowIndexL].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtML.Text != "")
            {
                if (ktMaVNThem(txtML.Text))
                {
                    DataRow dr = tableLoai.NewRow();
                    dr[0] = txtML.Text;
                    dr[1] = txtTL.Text;
                    tableLoai.Rows.Add(dr);
                }
                else
                {
                    MessageBox.Show("Trùng Mã Loài");
                }
            }
            else
            {
                MessageBox.Show("Mã Loài không thể bỏ trống được");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtML.Text != "")
            {
                if (ktMaVNSua(txtML.Text))
                {
                    //tableLoai.Rows[RowIndexL][0] = txtML.Text;
                    tableLoai.Rows[RowIndexL][1] = txtTL.Text;
                }
                else
                {
                    MessageBox.Show("Trùng Mã Loài");
                }
            }
            else
            {
                MessageBox.Show("Mã Loài không thể bỏ trống được");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn xóa?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                tableLoai.RejectChanges();
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
            tableLoai.RejectChanges();
        }

        private bool ktMaVNThem(string MaVN)
        {
            bool kt = true;
            foreach (DataRow dr in tableLoai.Rows)
            {
                if (dr[0].ToString() == MaVN)
                    kt = false;
            }
            return kt;
        }
        private bool ktMaVNSua(string MaVN)
        {
            bool kt = true;
            for (int i = 0; i < tableLoai.Rows.Count; i++)
            {
                if (tableLoai.Rows[i][0].ToString() == MaVN && i != RowIndexL)
                    kt = false;
            }
            return kt;
        }
    }
}
