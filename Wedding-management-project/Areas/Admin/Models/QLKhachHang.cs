using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace Wedding_management_project.Models
{
    public class QLKhachHang
    {
        [Display(Name = "Mã khách hàng")]
        public string MAKH { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Tên KH")]
        [Display(Name = "Họ và Tên")]
        public string TenKH { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Địa chỉ KH")]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Số điện thoại KH")]
        [Display(Name = "Số điện thoại")]
        public string SĐT { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Chứng minh nhân dân KH")]
        [Display(Name = "Chứng minh nhân dân")]
        public string CMND { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Email KH")]
        [Display(Name = "Email")]
        public string Email { set; get; }
    }
    class ListKhachHang
    {
        DataConnection db;
        public ListKhachHang()
        {
            db = new DataConnection();
        }

        //Viết phương thức lấy dữ liệu nhân viên từ CSDL
        public List<QLKhachHang> getKhachHang(string MAKH)
        {
            string sql;
            if (string.IsNullOrEmpty(MAKH))
            {
                sql = "SELECT * FROM KhachHang";
            }
            else
            {
                sql = "SELECT * FROM KhachHang WHERE MaKH='" + MAKH + "'";
            }

            List<QLKhachHang> strList = new List<QLKhachHang>();
            SqlConnection con = db.getConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();

            //Mở kết nối
            con.Open();
            cmd.Fill(dt);

            //Đóng kết nối
            cmd.Dispose();
            con.Close();

            QLKhachHang strKH;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strKH = new QLKhachHang();

                strKH.MAKH = dt.Rows[i]["MAKH"].ToString();
                strKH.TenKH = dt.Rows[i]["TenKH"].ToString();
                strKH.DiaChi = dt.Rows[i]["DiaChi"].ToString();
                strKH.SĐT = dt.Rows[i]["SĐT"].ToString();
                strKH.CMND = dt.Rows[i]["CMND"].ToString();
                strKH.Email = dt.Rows[i]["Email"].ToString();

                strList.Add(strKH);
            }
            return strList;
        }
        // Thêm dữ liệu (thêm nhân viên)
        public void AddKhachHang(QLKhachHang strKH)
        {

            string sql = "INSERT INTO KhachHang(TenKH, DiaChi, SĐT, CMND, Email)VALUES(N'" + strKH.TenKH + "',N'" + strKH.DiaChi + "',N'" + strKH.SĐT + "',N'" + strKH.CMND + "',N'" + strKH.Email + "')";
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