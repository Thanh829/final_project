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
    class BLLuong
    {
        DBMain db = null;

        public BLLuong()
        {
            db = new DBMain();
        }
        public DataSet LayLuong()
        {
            return db.ExecuteQueryDataSet("select Luong.MaNV,LuongCoBan,LuongThuong from Luong inner join NhanVien on Luong.MaNV=NhanVien.MaNV Where NhanVien.status=1", CommandType.Text);
        }
        public bool ThemLuong(string MaNV, string LuongCoBan, string LuongThuong, ref string err)
        {
            string sqlString = "Insert Into Luong Values(" + "'" +
            MaNV + "',N'" 
             +LuongCoBan +"',N'" +
           LuongThuong  + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaLuong(ref string err, string MaNV)
        {
            string sqlString = "Delete From Luong where MaNV='" + MaNV + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool CapNhatLuong(string MaNV, string LuongCoBan, string LuongThuong, ref string err)
        {
            string sqlString = "Update Luong Set LuongCoBan=N'" + LuongCoBan + "',LuongThuong='" + LuongThuong + "'where MaNV='" + MaNV + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
