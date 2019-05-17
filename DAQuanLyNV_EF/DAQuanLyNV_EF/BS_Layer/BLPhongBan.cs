using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DAQuanLyNV_EF.BS_Layer
{
    class BLPhongBan
    {
        public DataTable LayPB()
        {

            QuanLyNVEntities qlnvEntity = new QuanLyNVEntities();
            var tps =
            from p in qlnvEntity.PhongBans
            select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Phòng");
            dt.Columns.Add("Tên Phòng");
            dt.Columns.Add("Trưởng Phòng");
            dt.Columns.Add("Phó Phòng");
            dt.Columns.Add("Kế Toán");


            foreach (var p in tps)
            {
                dt.Rows.Add(p.MaPhong,p.TenPhong,p.TruongPhong,p.PhoPhong,p.KeToan);
            }
            return dt;
        }
        public bool ThemPB(string MaPB, string TenPB, string Truong, string Pho, string KT, ref string err)
        {
            QuanLyNVEntities qlnvEntity = new QuanLyNVEntities();
           
            PhongBan pb = new PhongBan();
            pb.MaPhong = MaPB;
            pb.TenPhong = TenPB;
            pb.TruongPhong = Truong;
            pb.PhoPhong = Pho;
            pb.KeToan = KT;
            qlnvEntity.PhongBans.Add(pb);
            qlnvEntity.SaveChanges();
            return true;

        }
        public bool XoaPB(ref string err, string MaPB)
        {
            QuanLyNVEntities qlnvEntity = new QuanLyNVEntities();

            PhongBan pb = new PhongBan();
            pb.MaPhong = MaPB;
            qlnvEntity.PhongBans.Attach(pb);
            qlnvEntity.PhongBans.Remove(pb);
            qlnvEntity.SaveChanges();
            return true;
        }
        public bool CapNhatPB(string MaPB, string TenPB, string Truong, string Pho, string KT, ref string err)
        {
            QuanLyNVEntities qlnvEntity = new QuanLyNVEntities();
            var PBQuery = (from l in qlnvEntity.PhongBans
                           where l.MaPhong == MaPB
                             select l).SingleOrDefault();
            if (PBQuery != null)
            {
                PBQuery.MaPhong = MaPB;
                PBQuery.TenPhong = TenPB;
                PBQuery.TruongPhong = Truong;
                PBQuery.PhoPhong = Pho;
                PBQuery.KeToan = KT;
                qlnvEntity.SaveChanges();
            }
            return true;
        }
    }
}
