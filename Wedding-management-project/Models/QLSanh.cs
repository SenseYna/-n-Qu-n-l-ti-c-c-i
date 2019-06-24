using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Wedding_management_project.Models
{
    public class QLSanh
    {
        [Display(Name = "Mã sảnh")]
        public string MAS { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Loại sảnh")]
        [Display(Name = "Loại")]
        public string LoaiS { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Tên sảnh")]
        [Display(Name = "Tên sảnh")]
        public string TenS { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Trạng thái sảnh")]
        [Display(Name = "Trạng thái")]
        public string TrangThai { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Sức chứa sảnh")]
        [Display(Name = "Sức chứa")]
        public string SucChua { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Đơn giá sảnh")]
        [Display(Name = "Đơn giá")]
        public string Gia { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Ghi chú")]
        [Display(Name = "Ghi chú")]
        public string GhiChu { set; get; }
    }
    class ListSanh
    {
        DataConnection db;
        public ListSanh()
        {
            db = new DataConnection();
        }

        //Viết phương thức lấy dữ liệu nhân viên từ CSDL
        public List<QLSanh> getSanh(string MAS)
        {
            string sql;
            if (string.IsNullOrEmpty(MAS))
            {
                sql = "SELECT * FROM Sanh";
            }
            else
            {
                sql = "SELECT * FROM Sanh WHERE MaS='" + MAS + "'";
            }

            List<QLSanh> strList = new List<QLSanh>();
            SqlConnection con = db.getConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();

            //Mở kết nối
            con.Open();
            cmd.Fill(dt);

            //Đóng kết nối
            cmd.Dispose();
            con.Close();

            QLSanh strS;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strS = new QLSanh();

                strS.MAS = dt.Rows[i]["MAS"].ToString();
                strS.LoaiS = dt.Rows[i]["LoaiS"].ToString();
                strS.TenS = dt.Rows[i]["TenS"].ToString();
                strS.TrangThai = dt.Rows[i]["TrangThai"].ToString();
                strS.SucChua = dt.Rows[i]["SucChua"].ToString();
                strS.Gia = dt.Rows[i]["Gia"].ToString();
                strS.GhiChu = dt.Rows[i]["GhiChu"].ToString();

                strList.Add(strS);
            }
            return strList;
        }
        // Thêm dữ liệu (thêm sảnh)
        public void AddSanh(QLSanh strS)
        {
            string sql = "INSERT INTO Sanh(LoaiS, TenS, TrangThai, SucChua, Gia, GhiChu)VALUES(N'" + strS.LoaiS + "',N'" + strS.TenS + "',N'" + strS.TrangThai + "',N'" + strS.SucChua + "',N'" + strS.Gia + "',N'" + strS.GhiChu + "')";
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            //Mở kết nối
            con.Open();
            cmd.ExecuteNonQuery();

            //Đóng kết nối
            cmd.Dispose();
            con.Close();
        }
        // Sửa dữ liệu (sửa sảnh)
        public void EditSanh(QLSanh strS)
        {
            string sql = "UPDATE Sanh SET  LoaiS=N'" + strS.LoaiS + "',TenS=N'" + strS.TenS + "', TrangThai=N'" + strS.TrangThai + "', SucChua=N'" + strS.SucChua + "', Gia=N'" + strS.Gia + "', GhiChu=N'" + strS.GhiChu + "' WHERE MaS='" + strS.MAS + "'";
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            //Mở kết nối
            con.Open();
            cmd.ExecuteNonQuery();

            //Đóng kết nối
            cmd.Dispose();
            con.Close();
        }
        // Xóa dữ liệu (xóa sảnh)
        public void DeleteSanh(QLSanh strS)
        {
            string sql = "DELETE FROM Sanh WHERE MaS='" + strS.MAS + "'";
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