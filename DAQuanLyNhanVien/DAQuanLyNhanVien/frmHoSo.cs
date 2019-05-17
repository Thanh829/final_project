using System;
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
    public partial class frmHoSo : Form
    {
        public frmHoSo()
        {
            InitializeComponent();
        }
        public string MaNV;
        DataTable dtHoSo = null;
        string err;
        BLHoSo dbHS = new BLHoSo();
        private void frmHoSo_Load(object sender, EventArgs e)
        {       
            dtHoSo = new DataTable();
            dtHoSo.Clear();
            DataSet ds = dbHS.layHS(MaNV, ref err);
            dtHoSo = ds.Tables[0];
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //if (MaNV == Convert.ToString(dr.ItemArray[0]))
                //{
                    txtMaNV.Text = Convert.ToString(dr.ItemArray[0]);
                    txtTenNV.Text = Convert.ToString(dr.ItemArray[1]);
                    txtNgaySinh.Text = Convert.ToString(dr.ItemArray[2]);
                    txtDiaChi.Text = Convert.ToString(dr.ItemArray[3]);
                    txtGioiTinh.Text = Convert.ToString(dr.ItemArray[4]);
                    txtTenPhong.Text = Convert.ToString(dr.ItemArray[5]);
                    txtLuongCoBan.Text = Convert.ToString(dr.ItemArray[6]);
                    txtLuongThuong.Text = Convert.ToString(dr.ItemArray[7]);
                //}
            }           
        }
    }
}
