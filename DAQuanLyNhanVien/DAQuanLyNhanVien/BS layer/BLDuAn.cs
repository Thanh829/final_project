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
    class BLDuAn
    {
        DBMain db = null;

        public BLDuAn()
        {
            db = new DBMain();
        }
        public DataSet LayDA()
        {
            return db.ExecuteQueryDataSet("select * from DuAn ", CommandType.Text);
        }
        public bool ThemDA(string MaDA, string TenDA, string Phong, ref string err)
        {
            string sqlString = "Insert Into DuAn Values(" + "'" +
            MaDA + "',N'"
             + TenDA + "',N'" +
           Phong + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaDA(ref string err, string MaDA)
        {
            string sqlString = "Delete From DuAn where MaDA='" + MaDA + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool CapNhatDA(string MaDA, string TenDA, string Phong, ref string err)
        {
            string sqlString = "Update Duan Set TenDA=N'" + TenDA + "',Phong='" + Phong + "'where MaDA='" + MaDA + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
