using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Wedding_management_project.Common;

namespace Wedding_management_project.Models
{
    public class QLNhanVien
    {
        [Display(Name = "Mã nhân viên")]
        public string MANV { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Tên NV")]
        [Display(Name = "Tên")]
        public string TenNV { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Giới tính NV")]
        [Display(Name = "Giới tính")]
        public string GioiTinh { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Địa chỉ NV")]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Số điện thoại NV")]
        [Display(Name = "Số điện thoại")]
        public string SĐT { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Chứng minh nhân dân NV")]
        [Display(Name = "Chứng minh nhân dân")]
        public string CMND { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Email NV")]
        [Display(Name = "Email")]
        public string Email { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Loai NV")]
        [Display(Name = "Loại NV")]
        public string LoaiNV { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Password")]
        [Display(Name = "Password")]
        public string Password { set; get; }
    }

    public class Login
    {
        public Login (){}
        public int checkLogin(string userName, string passWord)
        {
            DataConnection db = new DataConnection();
            SqlConnection con = db.getConnection();
            string sql;
            sql = "SELECT * FROM NhanVien";
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable("NhanVien");

            //Mở kết nối
            con.Open();
            cmd.Fill(dt);

            //Đóng kết nối
            cmd.Dispose();
            con.Close();
            var Str_User = "MaNV = '" + userName + "' and Password = '" + passWord + "'";
            var Str_Admin = "MaNV = '" + userName + "' and Password = '" + passWord + "' and LoaiNV = 'Admin'";
            DataRow[] rows = dt.Select(Str_Admin);
            DataRow[] rowss = dt.Select(Str_User);  //(x => x.MaNV == userName && x => x.GioiTinh == passWord);

            if (rows.Length > 0)
            {
                return 2;
            }
            else if (rowss.Length > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
    class ListNhanVien
    {
        DataConnection db;
        public ListNhanVien()
        {
            db = new DataConnection();
        }

        //Viết phương thức lấy dữ liệu nhân viên từ CSDL
        public List<QLNhanVien> getNhanVien(string MANV)
        {
            string sql;
            if (string.IsNullOrEmpty(MANV))
            {
                sql = "SELECT * FROM NhanVien";
            }
            else
            {
                sql = "SELECT * FROM NhanVien WHERE MaNV='" + MANV + "'";
            }

            List<QLNhanVien> strList = new List<QLNhanVien>();
            SqlConnection con = db.getConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();

            //Mở kết nối
            con.Open();
            cmd.Fill(dt);

            //Đóng kết nối
            cmd.Dispose();
            con.Close();

            QLNhanVien strNV;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strNV = new QLNhanVien();

                strNV.MANV = dt.Rows[i]["MANV"].ToString();
                strNV.TenNV = dt.Rows[i]["TenNV"].ToString();
                strNV.GioiTinh = dt.Rows[i]["GioiTinh"].ToString();
                strNV.DiaChi = dt.Rows[i]["DiaChi"].ToString();
                strNV.SĐT = dt.Rows[i]["SĐT"].ToString();
                strNV.CMND = dt.Rows[i]["CMND"].ToString();
                strNV.Email = dt.Rows[i]["Email"].ToString();
                strNV.LoaiNV = dt.Rows[i]["LoaiNV"].ToString();
                strNV.Password = dt.Rows[i]["Password"].ToString();

                strList.Add(strNV);
            }
            return strList;
        }
        // Thêm dữ liệu (thêm nhân viên)
        public void AddNhanVien(QLNhanVien strNV)
        {
            
            string sql = "INSERT INTO NhanVien(TenNV, GioiTinh, DiaChi, SĐT, CMND, Email,LoaiNV, Password)VALUES(N'" + strNV.TenNV + "',N'" + strNV.GioiTinh + "',N'" + strNV.DiaChi + "',N'" + strNV.SĐT + "',N'" + strNV.CMND + "',N'" + strNV.Email + "',N'" + strNV.LoaiNV + "',N'" + Encryptor.MD5Hash(strNV.Password) + "')";
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
        public void EditNhanVien(QLNhanVien strNV)
        {
           
            string sql = "UPDATE NhanVien SET  TenNV=N'" + strNV.TenNV + "', GioiTinh=N'" + strNV.GioiTinh + "', DiaChi=N'" + strNV.DiaChi + "', SĐT=N'" + strNV.SĐT + "', CMND=N'" + strNV.CMND + "', Email=N'" + strNV.Email + "', Password=N'" + Encryptor.MD5Hash(strNV.Password) + "' WHERE MaNV='" + strNV.MANV +"'" ;
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
        public void DeleteNhanVien(QLNhanVien strNV)
        {
            string sql = "DELETE FROM NhanVien WHERE MaNV='" + strNV.MANV + "'";
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