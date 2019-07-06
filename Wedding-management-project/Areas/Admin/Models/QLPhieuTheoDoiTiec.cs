using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Wedding_management_project.Models
{
    public class QLPhieuTheoDoiTiec
    {
        [Display(Name = "Mã Phiếu theo dõi tiệc")]
        public string MAPTDT { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Mã Sổ đặt tiệc")]
        [Display(Name = "Mã Sổ đặt tiệc")]
        public string MaSDT { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Mã Nhân viên")]
        [Display(Name = "Mã Nhân viên")]
        public string MaNV { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào thông tin phát sinh")]
        [Display(Name = "Thông tin phát sinh")]
        public string ThongTinPS { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào chi phí phát sinh")]
        [Display(Name = "Chi phí phát sinh")]
        public string ChiPhiPS { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào số tiền thanh toán")]
        [Display(Name = "Số tiền thanh toán")]
        public string SoTienThanhToan { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào ngày tạo")]
        [Display(Name = "Ngày tạo")]
        [DataType(DataType.Date)]
        public DateTime NgayTao { set; get; }
        public QLNhanVien NV { set; get; }
        public QLSoDatTiec SDT { set; get; }
    }
    class ListPhieuTheoDoiTiec
    {
        DataConnection db;
        public ListPhieuTheoDoiTiec()
        {
            db = new DataConnection();
        }

        //Viết phương thức lấy dữ liệu nhân viên từ CSDL
        public List<QLPhieuTheoDoiTiec> getPhieuTheoDoiTiec(string MAPTDT)
        {
            string sql;
            if (string.IsNullOrEmpty(MAPTDT))
            {
                sql = "SELECT * FROM PhieuTheoDoiTiec,NhanVien,SoDatTiec,PhieuDatTiec,KhachHang WHERE PhieuTheoDoiTiec.MaNV=NhanVien.MaNV AND PhieuTheoDoiTiec.MaSDT=SoDatTiec.MaSDT AND SoDatTiec.MaPDT=PhieuDatTiec.MaPDT AND PhieuDatTiec.MaKH=KhachHang.MaKH";
            }
            else
            {
                sql = "SELECT * FROM PhieuTheoDoiTiec WHERE MaPTDT='" + MAPTDT + "'";
            }

            List<QLPhieuTheoDoiTiec> strList = new List<QLPhieuTheoDoiTiec>();
            SqlConnection con = db.getConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();

            //Mở kết nối
            con.Open();
            cmd.Fill(dt);

            //Đóng kết nối
            cmd.Dispose();
            con.Close();

            QLPhieuTheoDoiTiec strPTDT;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strPTDT = new QLPhieuTheoDoiTiec();
                strPTDT.NV = new QLNhanVien();
                strPTDT.SDT = new QLSoDatTiec();
                strPTDT.SDT.PDT = new QLPhieuDatTiec();
                strPTDT.SDT.PDT.KH = new QLKhachHang();

                strPTDT.MAPTDT = dt.Rows[i]["MAPTDT"].ToString();
                strPTDT.MaSDT = dt.Rows[i]["MaSDT"].ToString();
                strPTDT.MaNV = dt.Rows[i]["MaNV"].ToString();
                strPTDT.ThongTinPS = dt.Rows[i]["ThongTinPS"].ToString();
                strPTDT.ChiPhiPS = dt.Rows[i]["ChiPhiPS"].ToString();
                strPTDT.SoTienThanhToan = dt.Rows[i]["SoTienThanhToan"].ToString();
                strPTDT.NgayTao = Convert.ToDateTime(dt.Rows[i]["NgayTao"].ToString());
                strPTDT.NV.TenNV =  dt.Rows[i]["TenNV"].ToString();
                strPTDT.SDT.PDT.KH.TenKH = dt.Rows[i]["TenKH"].ToString();

                strList.Add(strPTDT);
            }
            return strList;
        }

        public List<QLPhieuTheoDoiTiec> getPhieuTheoDoiTiec_ED(string MAPTDT)
        {
            string sql;
            if (string.IsNullOrEmpty(MAPTDT))
            {
                sql = "SELECT * FROM PhieuTheoDoiTiec";
            }
            else
            {
                sql = "SELECT * FROM PhieuTheoDoiTiec WHERE MaPTDT='" + MAPTDT + "'";
            }

            List<QLPhieuTheoDoiTiec> strList = new List<QLPhieuTheoDoiTiec>();
            SqlConnection con = db.getConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();

            //Mở kết nối
            con.Open();
            cmd.Fill(dt);

            //Đóng kết nối
            cmd.Dispose();
            con.Close();

            QLPhieuTheoDoiTiec strPTDT;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strPTDT = new QLPhieuTheoDoiTiec();

                strPTDT.MAPTDT = dt.Rows[i]["MAPTDT"].ToString();
                strPTDT.MaSDT = dt.Rows[i]["MaSDT"].ToString();
                strPTDT.MaNV = dt.Rows[i]["MaNV"].ToString();
                strPTDT.ThongTinPS = dt.Rows[i]["ThongTinPS"].ToString();
                strPTDT.ChiPhiPS = dt.Rows[i]["ChiPhiPS"].ToString();
                strPTDT.SoTienThanhToan = dt.Rows[i]["SoTienThanhToan"].ToString();
                strPTDT.NgayTao = Convert.ToDateTime(dt.Rows[i]["NgayTao"].ToString());

                strList.Add(strPTDT);
            }
            return strList;
        }

        // Thêm dữ liệu (thêm phiếu đặt tiệc)
        public void AddPhieuTheoDoiTiec(QLPhieuTheoDoiTiec strPTDT)
        {
            string sql = "INSERT INTO PhieuTheoDoiTiec(MaSDT, MaNV, ThongTinPS, ChiPhiPS, SoTienThanhToan, NgayTao)VALUES(N'" + strPTDT.MaSDT + "',N'" + strPTDT.MaNV + "',N'" + strPTDT.ThongTinPS + "',N'" + strPTDT.ChiPhiPS + "',N'" + strPTDT.SoTienThanhToan + "',N'" + Convert.ToDateTime(strPTDT.NgayTao).ToString("yyyy-MM-dd") + "')";
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            //Mở kết nối
            con.Open();
            cmd.ExecuteNonQuery();

            //Đóng kết nối
            cmd.Dispose();
            con.Close();
        }
        // Sửa dữ liệu (sửa phiếu đặt tiệc)
        public void EditPhieuTheoDoiTiec(QLPhieuTheoDoiTiec strPTDT)
        {
            string sql = "UPDATE PhieuTheoDoiTiec SET  MaSDT=N'" + strPTDT.MaSDT + "',MaNV=N'" + strPTDT.MaNV + "', ThongTinPS=N'" + strPTDT.ThongTinPS + "', ChiPhiPS=N'" + strPTDT.ChiPhiPS + "', SoTienThanhToan=N'" + strPTDT.SoTienThanhToan + "', NgayTao=N'" + Convert.ToDateTime(strPTDT.NgayTao).ToString("yyyy-MM-dd") + "' WHERE MaPTDT='" + strPTDT.MAPTDT + "'";
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            //Mở kết nối
            con.Open();
            cmd.ExecuteNonQuery();

            //Đóng kết nối
            cmd.Dispose();
            con.Close();
        }
        // Xóa dữ liệu (xóa phiếu đặt tiệc)
        public void DeletePhieuTheoDoiTiec(QLPhieuTheoDoiTiec strPTDT)
        {
            string sql = "DELETE FROM PhieuTheoDoiTiec WHERE MaPTDT='" + strPTDT.MAPTDT + "'";
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            //Mở kết nối
            con.Open();
            cmd.ExecuteNonQuery();

            //Đóng kết nối
            cmd.Dispose();
            con.Close();
        }
    }
}