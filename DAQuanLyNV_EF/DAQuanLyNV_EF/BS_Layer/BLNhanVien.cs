using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;
namespace DAQuanLyNV_EF.BS_Layer
{
    class BLNhanVien
    {
        CultureInfo cultures = new CultureInfo("en-US");
        public DataTable LayNV()
        {
           
            QuanLyNVEntities qlnvEntity = new QuanLyNVEntities();
            var tps =
            from p in qlnvEntity.NhanViens
            select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Nhân Viên");
            dt.Columns.Add("Họ Và Tên");
            dt.Columns.Add("Ngày sinh");
            dt.Columns.Add("Địa chỉ");
            dt.Columns.Add("Giới tính");
            dt.Columns.Add("Phòng");
            dt.Columns.Add("Ngày làm trong tháng");
            dt.Columns.Add("Ngày làm gần nhất");
            dt.Columns.Add("Status");
            foreach (var p in tps)
            {
                dt.Rows.Add(p.MaNV, p.HoVaTen,p.NgaySinh,p.DiaChi,p.GioiTinh,p.Phong,p.NgayLamTrongThang,p.NgayLamGanNhat);
            }
            return dt;
        }
        public bool ThemNV(string MaNV, string TenNV, string NgaySinh, string Diachi, string GioiTinh, string Phong, ref string err)
        {
            QuanLyNVEntities qlnvEntity = new QuanLyNVEntities();

            NhanVien nv = new NhanVien();
            nv.MaNV = MaNV;
            nv.HoVaTen = TenNV;
            nv.NgaySinh = Convert.ToDateTime(NgaySinh, cultures);
            nv.DiaChi = Diachi;
            nv.GioiTinh = GioiTinh;
            nv.Phong = Phong;
            nv.Status = "1";
            qlnvEntity.NhanViens.Add(nv);
            qlnvEntity.SaveChanges();

            return true;

        }
        public bool XoaNV(ref string err, string MaNV)
        {
            QuanLyNVEntities qlnvEntity = new QuanLyNVEntities();
           
            NhanVien nv = new NhanVien();
            nv.MaNV = MaNV;
            qlnvEntity.NhanViens.Attach(nv);
            qlnvEntity.NhanViens.Remove(nv);
            qlnvEntity.SaveChanges();
            return true;
        }
        public bool CapNhatNhanVien(string MaNV, string TenNV, string NgaySinh, string Diachi, string GioiTinh, string Phong, ref string err)
        {
            QuanLyNVEntities qlnvEntity = new QuanLyNVEntities();
            var nvQuery = (from nv in qlnvEntity.NhanViens
                           where nv.MaNV == MaNV
                           select nv).SingleOrDefault();
            if (nvQuery != null)
            {
              
                nvQuery.HoVaTen = TenNV;
                nvQuery.NgaySinh = Convert.ToDateTime( NgaySinh,cultures);
                nvQuery.DiaChi = Diachi;
                nvQuery.GioiTinh = GioiTinh;
                nvQuery.Phong = Phong;
                qlnvEntity.SaveChanges();
            }
            return true;
        }
    }
}
