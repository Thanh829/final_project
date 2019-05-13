using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DAQuanLyNhanVien.BS_layer;
namespace DAQuanLyNhanVien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool Them;
        DataTable dtNhanVien = null;
        string err;
        BLNhanVien dbNhanVien = new BLNhanVien();

        void LoadData()
        {
            //try
            //{
            dtNhanVien = new DataTable();
            dtNhanVien.Clear();
            DataSet ds = dbNhanVien.LayNV();
            dtNhanVien = ds.Tables[0];
            // Đưa dữ liệu lên DataGridView
            dgv.DataSource = dtNhanVien;
                // Thay đổi độ rộng cột
                dgv.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel
                this.txtDiaChi.ResetText();
                this.txtGioiTinh.ResetText();
                this.txtMaNV.ResetText();
                this.txtNgaySinh.ResetText();
                this.txtPhong.ResetText();
                this.txtTenNV.ResetText();
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
            this.txtDiaChi.ResetText();
            this.txtGioiTinh.ResetText();
            this.txtMaNV.ResetText();
            this.txtNgaySinh.ResetText();
            this.txtPhong.ResetText();
            this.txtTenNV.ResetText();

            this.btnHuy.Enabled = true;
            this.btnLuu.Enabled = true;
            this.panel1.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            this.txtMaNV.Focus();
         

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
            this.txtMaNV.Enabled = false;
            this.txtTenNV.Focus();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgv.CurrentCell.RowIndex;
            this.txtMaNV.Text = dgv.Rows[r].Cells[0].Value.ToString();
            this.txtTenNV.Text = dgv.Rows[r].Cells[1].Value.ToString();
            this.txtNgaySinh.Text = dgv.Rows[r].Cells[2].Value.ToString();
            this.txtDiaChi.Text = dgv.Rows[r].Cells[3].Value.ToString();
            this.txtGioiTinh.Text = dgv.Rows[r].Cells[4].Value.ToString();
            this.txtPhong.Text = dgv.Rows[r].Cells[5].Value.ToString();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            // Khai báo biến traloi
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.OK) this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            this.txtDiaChi.ResetText();
            this.txtGioiTinh.ResetText();
            this.txtMaNV.ResetText();
            this.txtNgaySinh.ResetText();
            this.txtPhong.ResetText();
            this.txtTenNV.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnTroVe.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.panel1.Enabled = false;
            dgv_CellClick(null, null);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them==true)
            {
                //try
                //{
                    // Thực hiện lệnh
                    BLNhanVien blTp = new BLNhanVien();
                    blTp.ThemNV(txtMaNV.Text, txtTenNV.Text, txtNgaySinh.Text, txtDiaChi.Text, txtGioiTinh.Text, txtPhong.Text, ref err);
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
                BLNhanVien blTp = new BLNhanVien();
                blTp.CapNhatNhanVien(txtMaNV.Text, txtTenNV.Text, txtNgaySinh.Text, txtDiaChi.Text, txtGioiTinh.Text, txtPhong.Text, ref err);

                // Load lại dữ liệu trên DataGridView
                LoadData();
                // Thông báo
                MessageBox.Show("Đã sửa xong!");
            }
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
                    dbNhanVien.XoaNV(ref err, strKH);
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

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            this.panel1.Enabled = false;
        }
    }
}
