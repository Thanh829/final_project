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
    class BLPhongBan
    {

        DBMain db = null;
        CultureInfo cultures = new CultureInfo("en-US");
        public BLPhongBan()
        {
            db = new DBMain();
        }
        public DataSet LayPB()
        {
            return db.ExecuteQueryDataSet("select * from PhongBan ", CommandType.Text);
        }
        public bool ThemPB(string MaPB, string TenPB, string Truong, string Pho, string KT, ref string err)
        {
            string sqlstring = "Insert Into PhongBan Values(" + "'" + MaPB + "',N'" + TenPB + "',N'" + Truong + "',N'" + Pho + "',N'" + KT + "' )";
            return db.MyExecuteNonQuery(sqlstring, CommandType.Text, ref err);
        }
        public bool XoaPB(ref string err, string MaPB)
        {
            string sqlString = "Delete From PhongBan where MaPhong='" + MaPB + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool CapNhatPB(string MaPB, string TenPB, string Truong, string Pho, string KT, ref string err)
        {
            string sqlString = " Update PhongBan Set TenPhong=N'" + TenPB + "',TruongPhong=N'" + Truong + "',PhoPhong=N'"
                + Pho + "',KeToan=N'" + KT + "'where MaPhong='" + MaPB + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);

        }
    }
}
