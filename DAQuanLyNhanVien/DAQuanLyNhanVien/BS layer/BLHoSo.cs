﻿using System;
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
    class BLHoSo
    {
        DBMain db = null;
        public BLHoSo()
        {
            db = new DBMain();
        }
        public DataSet layHS(string MaNV, ref string err)
        {
            return db.ExecuteQueryDataSet("SELECT NhanVien.MaNV, NhanVien.HoVaTen,  NhanVien.NgaySinh, NhanVien.DiaChi, NhanVien.GioiTinh, PhongBan.TenPhong, Luong.LuongCoBan, Luong.LuongTHuong " +
                                          "FROM NhanVien inner join PhongBan on NhanVien.Phong = PhongBan.MaPhong inner join Luong on NhanVien.MaNV = Luong.MaNV" +
                                          " WHERE NhanVien.MaNV = '" + MaNV + 
                                          "' ", CommandType.Text);
        }
    }
}
