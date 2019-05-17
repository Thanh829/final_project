using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DAQuanLyNV_EF.BS_Layer
{
    class BLDuAn
    {
        public DataTable LayDuAn()
        {

            QuanLyNVEntities qlnvEntity = new QuanLyNVEntities();
            var tps =
            from p in qlnvEntity.Duans
            select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Dự Án");
            dt.Columns.Add("Tên Dự Án");
            dt.Columns.Add("Phòng");


            foreach (var p in tps)
            {
                dt.Rows.Add(p.MaDA,p.TenDA,p.Phong);
            }
            return dt;
        }
        public bool ThemDA(string MaDA, string TenDA, string Phong, ref string err)
        {
            QuanLyNVEntities qlnvEntity = new QuanLyNVEntities();
            Duan da = new Duan();
            da.MaDA = MaDA;
            da.TenDA = TenDA;
            da.Phong = Phong;
            qlnvEntity.Duans.Add(da);
            qlnvEntity.SaveChanges();
            return true;

        }
        public bool XoaDA(ref string err, string MaDA)
        {
            QuanLyNVEntities qlnvEntity = new QuanLyNVEntities();

            Duan da = new Duan();
            da.MaDA = MaDA;
            qlnvEntity.Duans.Attach(da);
            qlnvEntity.Duans.Remove(da);
            qlnvEntity.SaveChanges();
            return true;
        }
        public bool CapNhatDA(string MaDA,string TenDA,string Phong, ref string err)
        {
            QuanLyNVEntities qlnvEntity = new QuanLyNVEntities();
            var DuanQuery = (from l in qlnvEntity.Duans
                              where l.MaDA==MaDA
                              select l).SingleOrDefault();
            if (DuanQuery != null)
            {
                DuanQuery.MaDA = MaDA;
                DuanQuery.TenDA = TenDA;
                DuanQuery.Phong = Phong;

                qlnvEntity.SaveChanges();
            }
            return true;
        }
    }
}
