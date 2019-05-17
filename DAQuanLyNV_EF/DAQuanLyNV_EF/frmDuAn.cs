using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAQuanLyNV_EF.BS_Layer;
namespace DAQuanLyNV_EF
{
    public partial class frmDuAn : Form
    {
        public frmDuAn()
        {
            InitializeComponent();
        }
        bool Them;
        string err;
        BLDuAn dbDA = new BLDuAn();
        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;

            this.txtPhong.ResetText();
            this.txtTenDA.ResetText();
            this.txtMaDA.ResetText();

            this.btnHuy.Enabled = true;
            this.btnLuu.Enabled = true;
            this.panel1.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            this.txtMaDA.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them == true)
            {
                //try
                //{
                // Thực hiện lệnh
                BLDuAn blTp = new BLDuAn();
                blTp.ThemDA(txtMaDA.Text, txtTenDA.Text, txtPhong.Text, ref err);
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
                BLDuAn blTp = new BLDuAn();
                blTp.CapNhatDA(txtMaDA.Text, txtTenDA.Text, txtPhong.Text, ref err);

                // Load lại dữ liệu trên DataGridView
                LoadData();
                // Thông báo
                MessageBox.Show("Đã sửa xong!");
            }
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
            txtMaDA.Enabled = false;
            this.txtMaDA.Focus();
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
                dbDA.XoaDA(ref err, strKH);
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
        void LoadData()
        {
            //try
            //{
           
            dgv.DataSource = dbDA.LayDuAn();
            // Thay đổi độ rộng cột
            dgv.AutoResizeColumns();
            // Xóa trống các đối tượng trong Panel
            this.txtPhong.ResetText();
            this.txtTenDA.ResetText();
            this.txtMaDA.ResetText();

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

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgv.CurrentCell.RowIndex;
            this.txtMaDA.Text = dgv.Rows[r].Cells[0].Value.ToString();
            this.txtTenDA.Text = dgv.Rows[r].Cells[1].Value.ToString();
            this.txtPhong.Text = dgv.Rows[r].Cells[2].Value.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            this.txtMaDA.ResetText();
            this.txtTenDA.ResetText();
            this.txtPhong.ResetText();
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

        private void frmDuAn_Load(object sender, EventArgs e)
        {
            LoadData();
            this.panel1.Enabled = true;
        }
    }
}
