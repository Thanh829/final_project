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
    class BLPhancong
    {
        CultureInfo cultures = new CultureInfo("en-US");
        DBMain db = null;
       
        public BLPhancong()
        {
            db = new DBMain();
        }
        public DataSet LayPhancong()
        {
            return db.ExecuteQueryDataSet("select PhanCong.MaNV, MaDA, ThoiGianBatDau,ThoiGianKetThuc from PhanCong inner join NhanVien on PhanCong.MaNV=NhanVien.MaNV Where NhanVien.status=1", CommandType.Text);
        }
        public bool ThemPC(string MaNV, string MaDA,string NgayBD,string NgayKT, ref string err)
        {
            string sqlString = "Insert Into PhanCong Values(" + "'" +
            MaNV + "',N'" +
            MaDA + "',N'" +
            Convert.ToDateTime( NgayBD,cultures) + "',N'" +
           Convert.ToDateTime( NgayKT,cultures) + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaPhanCong(ref string err, string MaNV)
        {
            string sqlString = "Delete From PhanCong where MaNV='" + MaNV + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool CapNhatPC(string MaNV, string MaDA, string NgayBD, string NgayKT, ref string err)
        {
            string sqlString = "Update PhanCong Set MaDA=N'"+MaDA+"',ThoiGianBatDau='"+Convert.ToDateTime( NgayBD,cultures) +"',ThoiGianKetThuc='"+Convert.ToDateTime( NgayKT,cultures)+ "'where MaNV='" + MaNV + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
