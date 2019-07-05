using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Wedding_management_project.Areas.Admin.Models;

namespace Wedding_management_project.Models
{
    public class QLPhieuDatTiec
    {
        [Display(Name = "Mã phiếu đặt tiệc")]
        public string MAPDT { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Mã Khách hàng")]
        [Display(Name = "Mã Khách hàng")]
        public string MaKH { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Mã Nhân viên")]
        [Display(Name = "Mã Nhân viên")]
        public string MaNV { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Mã Sảnh")]
        [Display(Name = "Mã Sảnh")]
        public string MaS { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Tên Chú rể")]
        [Display(Name = "Tên Chú rể")]
        public string TenCR { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Tên Cô dâu")]
        [Display(Name = "Tên Cô dâu")]
        public string TenCD { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Ngày tổ chức")]
        [Display(Name = "Ngày tổ chức")]
        [DataType(DataType.Date)]
        public DateTime NgayTC { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Giờ tổ chức")]
        [Display(Name = "Giờ tổ chức")]
        [DataType(DataType.Time)]
        public DateTime GioTC { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập Số mâm dự kiến")]
        [Display(Name = "Số mâm dự kiến")]
        public int SoMamDK { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập Số tiền cọc  trước tiệc")]
        [Display(Name = "Số tiền cọc trước tiệc")]
        public string SoTienCocTT { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Ghi chú")]
        [Display(Name = "Ghi chú")]
        public string GhiChu { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Ngày tạo")]
        [Display(Name = "Ngày tạo")]
        [DataType(DataType.Date)]
        public DateTime NgayTao { set; get; }
        public QLKhachHang KH { set; get; }
        public QLNhanVien NV { set; get; }
        public QLSanh S { set; get; }
    }
    class ListPhieuDatTiec
    {
        DataConnection db;
        public ListPhieuDatTiec()
        {
            db = new DataConnection();
        }

        //Viết phương thức lấy dữ liệu nhân viên từ CSDL
        public List<QLPhieuDatTiec> getPhieuDatTiec(string MAPDT)
        {
            string sql;
            if (string.IsNullOrEmpty(MAPDT))
            {
                sql = "SELECT * FROM PhieuDatTiec, KhachHang, NhanVien, Sanh WHERE PhieuDatTiec.MaKH=KhachHang.MaKH AND PhieuDatTiec.MaNV=NhanVien.MaNV AND PhieuDatTiec.MaS=Sanh.MaS";
            }
            else
            {
                sql = "SELECT * FROM PhieuDatTiec WHERE MaPDT='" + MAPDT + "'";
            }

            List<QLPhieuDatTiec> strList = new List<QLPhieuDatTiec>();
            SqlConnection con = db.getConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();

            //Mở kết nối
            con.Open();
            cmd.Fill(dt);

            //Đóng kết nối
            cmd.Dispose();
            con.Close();

            QLPhieuDatTiec strPDT;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strPDT = new QLPhieuDatTiec();
                strPDT.KH = new QLKhachHang();
                strPDT.NV = new QLNhanVien();
                strPDT.S = new QLSanh();

                strPDT.MAPDT =dt.Rows[i]["MAPDT"].ToString();
                strPDT.MaKH = dt.Rows[i]["MaKH"].ToString();
                strPDT.MaNV = dt.Rows[i]["MaNV"].ToString();
                strPDT.MaS = dt.Rows[i]["MaS"].ToString();
                strPDT.TenCR = dt.Rows[i]["TenCR"].ToString();
                strPDT.TenCD = dt.Rows[i]["TenCD"].ToString();
                strPDT.NgayTC = Convert.ToDateTime(dt.Rows[i]["NgayTC"].ToString());
                strPDT.GioTC = Convert.ToDateTime(dt.Rows[i]["GioTC"].ToString());
                strPDT.SoMamDK = Convert.ToInt32(dt.Rows[i]["SoMamDK"].ToString());
                strPDT.SoTienCocTT = dt.Rows[i]["SoTienCocTT"].ToString();
                strPDT.GhiChu = dt.Rows[i]["GhiChu"].ToString();
                strPDT.NgayTao = Convert.ToDateTime(dt.Rows[i]["NgayTao"].ToString());
                strPDT.KH.TenKH = dt.Rows[i]["TenKH"].ToString();
                strPDT.NV.TenNV = dt.Rows[i]["TenNV"].ToString();
                strPDT.S.TenS = dt.Rows[i]["TenS"].ToString();

                strList.Add(strPDT);
            }
            return strList;
        }

        public List<QLPhieuDatTiec> getPhieuDatTiec_ED(string MAPDT)
        {
            string sql;
            if (string.IsNullOrEmpty(MAPDT))
            {
                sql = "SELECT * FROM PhieuDatTiec";
            }
            else
            {
                sql = "SELECT * FROM PhieuDatTiec WHERE MaPDT='" + MAPDT + "'";
            }

            List<QLPhieuDatTiec> strList = new List<QLPhieuDatTiec>();
            SqlConnection con = db.getConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();

            //Mở kết nối
            con.Open();
            cmd.Fill(dt);

            //Đóng kết nối
            cmd.Dispose();
            con.Close();

            QLPhieuDatTiec strPDT;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strPDT = new QLPhieuDatTiec();
             
                strPDT.MAPDT = dt.Rows[i]["MAPDT"].ToString();
                strPDT.MaKH = dt.Rows[i]["MaKH"].ToString();
                strPDT.MaNV = dt.Rows[i]["MaNV"].ToString();
                strPDT.MaS = dt.Rows[i]["MaS"].ToString();
                strPDT.TenCR = dt.Rows[i]["TenCR"].ToString();
                strPDT.TenCD = dt.Rows[i]["TenCD"].ToString();
                strPDT.NgayTC = Convert.ToDateTime(dt.Rows[i]["NgayTC"].ToString());
                strPDT.GioTC = Convert.ToDateTime(dt.Rows[i]["GioTC"].ToString());
                strPDT.SoMamDK = Convert.ToInt32(dt.Rows[i]["SoMamDK"].ToString());
                strPDT.SoTienCocTT = dt.Rows[i]["SoTienCocTT"].ToString();
                strPDT.GhiChu = dt.Rows[i]["GhiChu"].ToString();
                strPDT.NgayTao = Convert.ToDateTime(dt.Rows[i]["NgayTao"].ToString());
              
                strList.Add(strPDT);
            }
            return strList;
        }

        // Thêm dữ liệu (thêm phiếu đặt tiệc)
        public bool AddPhieuDatTiec(QLPhieuDatTiec strPDT)
        {
            try
            {
                string sql = "INSERT INTO PhieuDatTiec(MaKH, MaNV, MaS, TenCR, TenCD, NgayTC, GioTC, SoMamDK, SoTienCocTT, GhiChu, NgayTao)VALUES(N'" + strPDT.MaKH + "',N'" + strPDT.MaNV + "',N'" + strPDT.MaS + "',N'" + strPDT.TenCR + "',N'" + strPDT.TenCD + "',N'" + Convert.ToDateTime(strPDT.NgayTC).ToString("yyyy-MM-dd") + "',N'" + Convert.ToDateTime(strPDT.GioTC).ToString("HH:mm") + "',N'" + strPDT.SoMamDK + "',N'" + strPDT.SoTienCocTT + "',N'" + strPDT.GhiChu + "',N'" + Convert.ToDateTime(strPDT.NgayTao).ToString("yyyy-MM-dd") + "')";
                ListTinhTrangSanh danhdauSanh = new ListTinhTrangSanh();

                var ngayTC_tostring = Convert.ToDateTime(strPDT.NgayTC).ToString("ddMMyyyy");
                ngayTC_tostring = strPDT.MaS + ngayTC_tostring;
                string sql2 = "select * from TinhTrangSanh where MaTTS = '"+ngayTC_tostring+"'";

                db = new DataConnection();
                SqlConnection con2 = db.getConnection();
                SqlDataAdapter cmd2= new SqlDataAdapter(sql2, con2);
                DataTable dt2 = new DataTable();
                //Mở kết nối
                con2.Open();
                cmd2.Fill(dt2);

                //Đóng kết nối
                cmd2.Dispose();
                con2.Close();
                if (dt2.Rows.Count > 0) return false;

                SqlConnection con = db.getConnection();
                SqlCommand cmd = new SqlCommand(sql, con);

                //Mở kết nối
                con.Open();
                cmd.ExecuteNonQuery();

                //Đóng kết nối
                cmd.Dispose();
                con.Close();

                /////////////////////// update Tinh Trang Sanh

                string sql1 = "SELECT TOP 1 MaPDT as LastMaPDT FROM PhieuDatTiec ORDER BY MaPDT DESC ";
                SqlConnection con1 = db.getConnection();
                SqlDataAdapter cmd1 = new SqlDataAdapter(sql1, con1);
                DataTable dt1 = new DataTable();

               
                

                //Mở kết nối
                con1.Open();
                cmd1.Fill(dt1);

                //Đóng kết nối
                cmd1.Dispose();
                con1.Close();

                var maPDT = dt1.Rows[0]["LastMaPDT"].ToString();

                if (!danhdauSanh.AddTinhTrangSanh(strPDT.NgayTC, strPDT.MaS, maPDT)) return false;
                return true;
            }
            catch
            {
                return false;
            }

        }
        // Sửa dữ liệu (sửa phiếu đặt tiệc)
        public void EditPhieuDatTiec(QLPhieuDatTiec strPDT)
        {
            string sql = "UPDATE PhieuDatTiec SET  MaKH=N'" + strPDT.MaKH + "',MaNV=N'" + strPDT.MaNV + "', MaS=N'" + strPDT.MaS + "', TenCR=N'" + strPDT.TenCR + "', TenCD=N'" + strPDT.TenCD + "',NgayTC=N'" + Convert.ToDateTime(strPDT.NgayTC).ToString("yyyy-MM-dd") + "',GioTC=N'" + Convert.ToDateTime(strPDT.GioTC).ToString("HH:mm") + "',SoMamDK=N'" + strPDT.SoMamDK + "',SoTienCocTT=N'" + strPDT.SoTienCocTT + "',GhiChu=N'" + strPDT.GhiChu + "', NgayTao=N'" + Convert.ToDateTime(strPDT.NgayTao).ToString("yyyy-MM-dd") + "' WHERE MaPDT='" + strPDT.MAPDT + "'";
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
        public void DeletePhieuDatTiec(QLPhieuDatTiec strPDT)
        {
            string sql = "DELETE FROM PhieuDatTiec WHERE MaPDT='" + strPDT.MAPDT + "'";
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