using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAQuanLyNhanVien
{
    public partial class frmMain : Form
    {
        public bool status = false;
        public string MaNV;
        public frmMain()
        {
            InitializeComponent();
        }           
        private void Maincs_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnHoSo, "Chỉnh sửa hồ sơ");
            toolTip2.SetToolTip(btnChamCong, "Chấm công");
            toolTip3.SetToolTip(btnNhanVien, "Nhân viên");
            toolTip4.SetToolTip(btnLuong, "Lương");
            toolTip5.SetToolTip(btnPhongBan, "Phòng ban");
            toolTip6.SetToolTip(btnDuAn, "Dự án");
            toolTip7.SetToolTip(btnPhanCong, "Phân công");
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            if (status != false)
            {
                frmNhanVien fnv = new frmNhanVien();
                fnv.ShowDialog();
            }
            else MessageBox.Show("Bạn phải đăng nhập để dùng tính năng này.");
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            if (status != false)
            {
                frmLuong fl = new frmLuong();
             fl.ShowDialog();
            }
            else MessageBox.Show("Bạn phải đăng nhập để dùng tính năng này.");
        }

        private void btnPhongBan_Click(object sender, EventArgs e)
        {
            if (status != false)
            {
                frmPhongBan fPhB = new frmPhongBan();
                fPhB.ShowDialog();
            }
            else MessageBox.Show("Bạn phải đăng nhập để dùng tính năng này.");
        }

        private void btnDuAn_Click(object sender, EventArgs e)
        {
            if (status != false)
            {
                frmDuAn fDA = new frmDuAn();
                fDA.ShowDialog();
            }
            else MessageBox.Show("Bạn phải đăng nhập để dùng tính năng này.");
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            if (status != false)
            {
                frmPhanCong fpb = new frmPhanCong();
                fpb.ShowDialog();
            }
            else MessageBox.Show("Bạn phải đăng nhập để dùng tính năng này.");
        }

        private void lDN_Click(object sender, EventArgs e)
        {
            if (status == false)
            {
                frmDangNhap fdn = new frmDangNhap();
                fdn.ShowDialog();
                if (fdn.hople == true)
                {
                    status = true;
                    MaNV = fdn.ma;
                    MessageBox.Show("Đăng nhập thành công. \nChào mừng NV: " + MaNV + "\nBây giờ bạn đã có thể xử dụng các tính năng.");
                    lDN.ForeColor = Color.Red;
                    lDN.Text = "Đăng Xuất";
                };
            }
            else
            {
                // Khai báo biến traloi
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp
                traloi = MessageBox.Show("Bạn muốn đăng xuất?", "Trả lời",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không?
                if (traloi == DialogResult.OK)
                {
                    status = false;
                    lDN.ForeColor = Color.Blue;
                    lDN.Text = "Đăng Nhập";
                }
            }

        }

        private void btnHoSo_Click(object sender, EventArgs e)
        {
            frmHoSo fhs = new frmHoSo();
            fhs.MaNV = MaNV;
            fhs.ShowDialog();
        }
    }
}
