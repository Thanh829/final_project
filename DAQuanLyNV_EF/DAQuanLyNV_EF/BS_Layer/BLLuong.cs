using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Data;
namespace DAQuanLyNV_EF.BS_Layer
{
    class BLLuong
    {
        public DataTable LayLuong()
        {

            QuanLyNVEntities qlnvEntity = new QuanLyNVEntities();
            var tps =
            from p in qlnvEntity.Luongs
            select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Nhân Viên");
            dt.Columns.Add("Lương Cơ Bản");
            dt.Columns.Add("Lương Thưởng");
            

            foreach (var p in tps)
            {
                dt.Rows.Add(p.MaNV, p.LuongCoBan,p.LuongThuong);
            }
            return dt;
        }
        public bool ThemLuong(string MaNV,string LuongCoBan,string LuongThuong, ref string err)
        {
            QuanLyNVEntities qlnvEntity = new QuanLyNVEntities();

            Luong l = new Luong();

            l.MaNV = MaNV;
            l.LuongCoBan = Convert.ToInt32( LuongCoBan);
            l.LuongThuong =Convert.ToInt32( LuongThuong);
            qlnvEntity.Luongs.Add(l);
            qlnvEntity.SaveChanges();
            return true;

        }
        public bool XoaLuong(ref string err, string MaNV)
        {
            QuanLyNVEntities qlnvEntity = new QuanLyNVEntities();

            Luong l = new Luong();
            l.MaNV = MaNV;
            qlnvEntity.Luongs.Attach(l);
            qlnvEntity.Luongs.Remove(l);
            qlnvEntity.SaveChanges();
            return true;
        }
        public bool CapNhatLuong(string MaNV, string LuongCoban,string LuongThuong, ref string err)
        {
            QuanLyNVEntities qlnvEntity = new QuanLyNVEntities();
            var LuongQuery = (from l in qlnvEntity.Luongs
                           where l.MaNV == MaNV
                           select l).SingleOrDefault();
            if (LuongQuery != null)
            {
                LuongQuery.MaNV = MaNV;
                LuongQuery.LuongCoBan = Convert.ToInt32( LuongCoban);
                LuongQuery.LuongThuong= Convert.ToInt32( LuongThuong);

                qlnvEntity.SaveChanges();
            }
            return true;
        }
    }
}
