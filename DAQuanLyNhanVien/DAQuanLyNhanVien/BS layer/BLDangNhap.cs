using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using DAQuanLyNhanVien.DB_layer;

namespace DAQuanLyNhanVien.BS_layer
{
    class BLDangNhap
    {
        DBMain db = null;
        public BLDangNhap()
        {
            db = new DBMain();
        }
        public DataSet login(string MaNV, string  Pass, ref string err)
        {          
            return db.ExecuteQueryDataSet("SELECT MaNV, Passwd FROM DangNhap WHERE MaNV = '" + MaNV + "' AND Passwd = '" + Pass + "' ", CommandType.Text);
        }
    }
}
