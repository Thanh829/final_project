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
        }
    }
}
