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
        [Display(Name = "Mã phiếu theo dõi tiệc")]
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
        public decimal ChiPhiPS { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào ngay tao")]
        [Display(Name = "Ngày tạo")]
        [DataType(DataType.Date)]
        public DateTime NgayTao { set; get; }
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
                strPTDT.ChiPhiPS = Convert.ToDecimal(dt.Rows[i]["ChiPhiPS"].ToString());
                strPTDT.NgayTao = Convert.ToDateTime(dt.Rows[i]["NgayTao"].ToString());

                strList.Add(strPTDT);
            }
            return strList;
        }
        // Thêm dữ liệu (thêm phiếu đặt tiệc)
        public void AddPhieuTheoDoiTiec(QLPhieuTheoDoiTiec strPTDT)
        {
            string sql = "INSERT INTO PhieuTheoDoiTiec(MaSDT, MaNV, ThongTinPS, ChiPhiPS, NgayTao)VALUES(N'" + strPTDT.MaSDT + "',N'" + strPTDT.MaNV + "',N'" + strPTDT.ThongTinPS + "',N'" + strPTDT.ChiPhiPS + "',N'" + Convert.ToDateTime(strPTDT.NgayTao).ToString("yyyy-MM-dd") + "')";
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
            string sql = "UPDATE PhieuTheoDoiTiec SET  MaSDT=N'" + strPTDT.MaSDT + "',MaNV=N'" + strPTDT.MaNV + "', ThongTinPS=N'" + strPTDT.ThongTinPS + "', ChiPhiPS=N'" + strPTDT.ChiPhiPS + "', NgayTao=N'" + Convert.ToDateTime(strPTDT.NgayTao).ToString("yyyy-MM-dd") + "' WHERE MaPTDT='" + strPTDT.MAPTDT + "'";
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