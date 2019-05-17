using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;

namespace DAQuanLyNV_EF.BS_Layer
{
    class BLPhanCong
    {
        CultureInfo cultures = new CultureInfo("en-US");
        public DataTable LayPC()
        {

            QuanLyNVEntities qlnvEntity = new QuanLyNVEntities();
            var tps =
            from p in qlnvEntity.PhanCongs
            select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Nhân Viên");
            dt.Columns.Add("Mã Dự Án");
            dt.Columns.Add("Ngày Bắt đầu");
            dt.Columns.Add("Ngày Kết Thúc");
           
            foreach (var p in tps)
            {
                dt.Rows.Add(p.MaNV, p.MaDA,p.ThoiGianBatDau,p.ThoiGianKetThuc);
            }
            return dt;
        }
        public bool ThemPC(string MaNV, string MaDA, string NgayBD, string NgayKT, ref string err)
        {
            QuanLyNVEntities qlnvEntity = new QuanLyNVEntities();

            PhanCong pc = new PhanCong();
          
            pc.MaNV = MaNV;
            pc.MaDA = MaDA;
            pc.ThoiGianBatDau = Convert.ToDateTime(NgayBD, cultures);
            pc.ThoiGianKetThuc = Convert.ToDateTime(NgayKT, cultures);
            qlnvEntity.PhanCongs.Add(pc);
            qlnvEntity.SaveChanges();
            return true;

        }
        public bool XoaPhanCong(ref string err, string MaNV)
        {
            QuanLyNVEntities qlnvEntity = new QuanLyNVEntities();

            PhanCong pc = new PhanCong();
            pc.MaNV = MaNV;
            qlnvEntity.PhanCongs.Attach(pc);
            qlnvEntity.PhanCongs.Remove(pc);
            qlnvEntity.SaveChanges();
            return true;
        }
        public bool CapNhatPC(string MaNV, string MaDA, string NgayBD, string NgayKT, ref string err)
        {
            QuanLyNVEntities qlnvEntity = new QuanLyNVEntities();
            var pcQuery = (from pc in qlnvEntity.PhanCongs
                           where pc.MaNV == MaNV
                           select pc).SingleOrDefault();
            if (pcQuery != null)
            {
                pcQuery.MaNV = MaNV;
                pcQuery.MaDA = MaDA;
                pcQuery.ThoiGianBatDau = Convert.ToDateTime(NgayBD, cultures);
                pcQuery.ThoiGianKetThuc = Convert.ToDateTime(NgayKT, cultures);
               
                qlnvEntity.SaveChanges();
            }
            return true;
        }
    }
}
