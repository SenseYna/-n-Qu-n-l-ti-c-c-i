using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace Wedding_management_project.Models
{
    
    public class QLBaoCao
    {
        [Display(Name = "Mã Báo cáo")]
        public string MABC { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập tháng muốn lập Báo cáo")]
        [Display(Name = "Tháng báo cáo")]
        public string ThangBC { set; get; }

        public QLPhieuTheoDoiTiec PTDT { set; get; }
        
    }
    class ListBaoCao
    {
        
        DataConnection db;
        public ListBaoCao()
        {
            db = new DataConnection();
        }

        public List<QLBaoCao> getBaoCao(string MABC)
        {
            string sql;
            if (string.IsNullOrEmpty(MABC))
            {

                sql = "SELECT * FROM BaoCao,PhieuTheoDoiTiec,ChiTietBaoCao,SoDatTiec,PhieuDatTiec,KhachHang WHERE ChiTietBaoCao.MaBC=BaoCao.MaBC AND ChiTietBaoCao.MaPTDT=PhieuTheoDoiTiec.MaPTDT AND PhieuTheoDoiTiec.MaSDT=SoDatTiec.MaSDT AND SoDatTiec.MaPDT=PhieuDatTiec.MaPDT AND PhieuDatTiec.MaKH=KhachHang.MaKH AND MONTH(PhieuTheoDoiTiec.NgayTao)=MONTH(CONVERT(date, GETDATE())) AND YEAR(PhieuTheoDoiTiec.NgayTao)=YEAR(CONVERT(date, GETDATE())) ";
            }
            else
            {
                sql = "SELECT * FROM BaoCao WHERE MaBC='" + MABC + "'";
            }

            List<QLBaoCao> strList = new List<QLBaoCao>();
            SqlConnection con = db.getConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();

            //Mở kết nối
            con.Open();
            cmd.Fill(dt);

            //Đóng kết nối
            cmd.Dispose();
            con.Close();
            QLBaoCao strBC;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strBC = new QLBaoCao();
                strBC.PTDT = new QLPhieuTheoDoiTiec();
                strBC.PTDT.SDT = new QLSoDatTiec();
                strBC.PTDT.SDT.PDT = new QLPhieuDatTiec();
                strBC.PTDT.SDT.PDT.KH = new QLKhachHang();

                strBC.MABC = dt.Rows[i]["MABC"].ToString();
                strBC.ThangBC = dt.Rows[i]["ThangBC"].ToString();
                strBC.PTDT.MAPTDT = dt.Rows[i]["MAPTDT"].ToString();
                strBC.PTDT.SDT.PDT.KH.TenKH = dt.Rows[i]["TenKH"].ToString();
                strBC.PTDT.SoTienThanhToan = dt.Rows[i]["SoTienThanhToan"].ToString();
                strBC.PTDT.NgayTao = Convert.ToDateTime(dt.Rows[i]["NgayTao"].ToString());
                

                strList.Add(strBC);
            }
            return strList;
        }
        // Thêm dữ liệu (thêm nhân viên)
        public void AddKhachHang(QLKhachHang strKH)
        {

            string sql = "INSERT INTO BaoCao()VALUES(N'" + strKH.TenKH + "',N'" + strKH.DiaChi + "',N'" + strKH.SĐT + "',N'" + strKH.CMND + "',N'" + strKH.Email + "')";
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            //Mở kết nối
            con.Open();
            cmd.ExecuteNonQuery();

            //Đóng kết nối
            cmd.Dispose();
            con.Close();
        }
        //Sửa dữ liệu nhân viên
        public void EditKhachHang(QLKhachHang strKH)
        {

            string sql = "UPDATE KhachHang SET  TenKH=N'" + strKH.TenKH + "', DiaChi=N'" + strKH.DiaChi + "', SĐT=N'" + strKH.SĐT + "', CMND=N'" + strKH.CMND + "', Email=N'" + strKH.Email + "' WHERE MaKH='" + strKH.MAKH + "'";
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            //Mở kết nối
            con.Open();
            cmd.ExecuteNonQuery();

            //Đóng kết nối
            cmd.Dispose();
            con.Close();
        }
        // Xóa dữ liệu nhân viên
        public void DeleteKhachHang(QLKhachHang strKH)
        {
            string sql = "DELETE FROM KhachHang WHERE MaKH='" + strKH.MAKH + "'";
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