﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAQuanLyNhanVien.BS_layer;
namespace DAQuanLyNhanVien
{
    public partial class Luong : Form
    {
        public Luong()
        {
            InitializeComponent();
        }
        bool Them;
        DataTable dtLuong = null;
        string err;
        BLLuong dbLuong = new BLLuong();

        void LoadData()
        {
            //try
            //{
            dtLuong = new DataTable();
            dtLuong.Clear();
            DataSet ds = dbLuong.LayLuong();
            dtLuong = ds.Tables[0];
            // Đưa dữ liệu lên DataGridView
            dgv.DataSource = dtLuong;
            // Thay đổi độ rộng cột
            dgv.AutoResizeColumns();
            // Xóa trống các đối tượng trong Panel
            this.txtLuongThuong.ResetText();
            this.txtLuongCB.ResetText();
            this.txtMaNV.ResetText();

            // Không cho thao tác trên các nút Lưu / Hủy
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.panel1.Enabled = false;
            // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;

            //
            dgv_CellClick(null, null);
            //}
            //catch
            //{
            //    MessageBox.Show("Không lấy được nội dung trong table KH. Lỗi rồi!!!");
            //}
        }
       
        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;

            this.txtLuongThuong.ResetText();
            this.txtLuongCB.ResetText();
            this.txtMaNV.ResetText();

            this.btnHuy.Enabled = true;
            this.btnLuu.Enabled = true;
            this.panel1.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            this.txtMaNV.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them == true)
            {
                //try
                //{
                // Thực hiện lệnh
                BLLuong blTp = new BLLuong();
                blTp.ThemLuong(txtMaNV.Text, txtLuongCB.Text, txtLuongThuong.Text, ref err);
                // Load lại dữ liệu trên DataGridView
                LoadData();
                // Thông báo
                MessageBox.Show("Đã thêm xong!");
                //}
                //catch (SqlException)
                //{
                //    MessageBox.Show("Không thêm được. Lỗi rồi!");
                //}
            }
            else
            {
                // Thực hiện lệnh
                BLLuong blTp = new BLLuong();
                blTp.CapNhatLuong(txtMaNV.Text,txtLuongCB.Text,txtLuongThuong.Text, ref err);

                // Load lại dữ liệu trên DataGridView
                LoadData();
                // Thông báo
                MessageBox.Show("Đã sửa xong!");
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgv.CurrentCell.RowIndex;
            this.txtMaNV.Text = dgv.Rows[r].Cells[0].Value.ToString();
            this.txtLuongCB.Text = dgv.Rows[r].Cells[1].Value.ToString();
            this.txtLuongThuong.Text = dgv.Rows[r].Cells[2].Value.ToString();
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //try
            //{
            // Thực hiện lệnh
            // Lấy thứ tự record hiện hành
            int r = dgv.CurrentCell.RowIndex;
            // Lấy MaKH của record hiện hành
            string strKH =
            dgv.Rows[r].Cells[0].Value.ToString();
            // Viết câu lệnh SQL
            // Hiện thông báo xác nhận việc xóa mẫu tin
            // Khai báo biến traloi
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.Yes)
            {
                dbLuong.XoaLuong(ref err, strKH);
                // Cập nhật lại DataGridView
                LoadData();
                // Thông báo
                MessageBox.Show("Đã xóa xong!");
            }
            else
            {
                // Thông báo
                MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
            }
            //}
            //catch (SqlException)
            //{
            //    MessageBox.Show("Không xóa được. Lỗi rồi!");
            //}
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            // Cho phép thao tác trên Panel
            this.panel1.Enabled = true;
            dgv_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.panel1.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            //this.btnTroVe.Enabled = false;
            // Đưa con trỏ đến TextField txtMaKH
            txtMaNV.Enabled = false;
            this.txtMaNV.Focus();
        }

        private void Luong_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
