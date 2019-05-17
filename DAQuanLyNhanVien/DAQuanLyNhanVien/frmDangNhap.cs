using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAQuanLyNhanVien.BS_layer;
namespace DAQuanLyNhanVien
{
    public partial class frmDangNhap : Form
    {
        public bool hople = false;
        public string ma;
        public frmDangNhap()
        {
            InitializeComponent();
        }
        string err;
        DataTable dtDN = null;
        BLDangNhap dbDN = new BLDangNhap();
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            dtDN = new DataTable();
            dtDN.Clear();
            DataSet ds = dbDN.login(txtMaNV.Text, txtPass.Text, ref err);
            dtDN = ds.Tables[0];            
            if (dtDN.Rows.Count > 0)
            {
                hople = true;
            }
            if (hople == true)
            {
                ma = txtMaNV.Text;
                this.Close();
            }
            else MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!");
        }
    }
}
