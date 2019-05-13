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
    class BLNhanVien
    {
        DBMain db = null;
        CultureInfo cultures = new CultureInfo("en-US");
        public BLNhanVien()
        {
            db = new DBMain();
        }
        public DataSet LayNV()
        {
            return db.ExecuteQueryDataSet("select * from NhanVien where status=1", CommandType.Text);
        }
        public bool ThemNV(string MaNV, string TenNV, string NgaySinh, string Diachi, string GioiTinh, string Phong,ref string err)
        {
            DateTime time = DateTime.Now;              // Use current time
            string format = "yyyy-MM-dd HH:mm:ss";
            string sqlstring = "Insert Into NhanVien Values(" + "'" + MaNV + "',N'" + TenNV + "',N'" +
             Convert.ToDateTime(NgaySinh,cultures)+ "',N'" + Diachi + "',N'" + GioiTinh + "',N'" + Phong+ "',N'"+"0" + "',N'"+time
              + "',N'"+"1"+"' )";
            int t = 12;
           
            return db.MyExecuteNonQuery(sqlstring, CommandType.Text, ref err);
        }
        public bool XoaNV(ref string err,string MaNV)
        {
            string sqlString = " Update NhanVien Set Status = 0 where MaNV='" + MaNV + "'";

            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool CapNhatNhanVien(string MaNV, string TenNV, string NgaySinh, string Diachi, string GioiTinh, string Phong, ref string err)
        {
            string sqlString = " Update NhanVien Set HoVaTen=N'" + TenNV + "',NgaySinh=N'" + NgaySinh + "',DiaChi=N'"
                + Diachi + "',GioiTinh=N'" + GioiTinh + "',Phong=N'" + Phong +"'where MaNV='"+MaNV+ "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);

        }

    }
}
