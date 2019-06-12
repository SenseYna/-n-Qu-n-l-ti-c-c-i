using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Wedding_management_project.Models
{
    public class QLNhanVien
    {
        public int ID { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Mã NV")]
        [Display(Name = "Mã NV")]
        public string MaNV { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Tên NV")]
        [Display(Name = "Tên NV")]
        public string TenNV { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Giới tính NV")]
        [Display(Name = "Giới tính NV")]
        public string GioiTinh { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Địa chỉ NV")]
        [Display(Name = "Địa chỉ NV")]
        public string DiaChi { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Số điện thoại NV")]
        [Display(Name = "Số điện thoại NV")]
        public string SĐT { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Chứng minh nhân dân NV")]
        [Display(Name = "Chứng minh nhân dân NV")]
        public string CMND { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Email NV")]
        [Display(Name = "Email NV")]
        public string Email { set; get; }
    }

    public class Login
    {
        public Login (){}
        public bool checkLogin(string userName, string passWord)
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
            var Str = "MaNV = '" + userName + "' and GioiTinh = '" + passWord + "'";
            DataRow[] rows = dt.Select(Str);  //(x => x.MaNV == userName && x => x.GioiTinh == passWord);
            if (rows.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
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
        public List<QLNhanVien> getNhanVien(string ID)
        {
            string sql;
            if (string.IsNullOrEmpty(ID))
            {
                sql = "SELECT * FROM NhanVien";
            }
            else
            {
                sql = "SELECT * FROM NhanVien WHERE Id=" + ID;
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

                strNV.ID = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                strNV.MaNV = dt.Rows[i]["MaNV"].ToString();
                strNV.TenNV = dt.Rows[i]["TenNV"].ToString();
                strNV.GioiTinh = dt.Rows[i]["GioiTinh"].ToString();
                strNV.DiaChi = dt.Rows[i]["DiaChi"].ToString();
                strNV.SĐT = dt.Rows[i]["SĐT"].ToString();
                strNV.CMND = dt.Rows[i]["CMND"].ToString();
                strNV.Email = dt.Rows[i]["Email"].ToString();

                strList.Add(strNV);
            }
            return strList;
        }
        // Thêm dữ liệu (thêm nhân viên)
        public void AddNhanVien(QLNhanVien strNV)
        {
            string sql = "INSERT INTO NhanVien(MaNV, TenNV, GioiTinh, DiaChi, SĐT, CMND, Email)VALUES(N'" + strNV.MaNV + "',N'" + strNV.TenNV + "',N'" + strNV.GioiTinh + "',N'" + strNV.DiaChi + "',N'" + strNV.SĐT + "',N'" + strNV.CMND + "',N'" + strNV.Email + "')";
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