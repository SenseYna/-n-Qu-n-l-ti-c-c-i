using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Wedding_management_project.Models
{
    public class QLDichVu
    {
        [Display(Name = "Mã dịch vụ")]
        public string MADV { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Tên dịch vụ")]
        [Display(Name = "Tên dịch vụ")]
        public string TenDV { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Mô tả")]
        [Display(Name = "Mô tả")]
        public string MoTa { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Đơn giá dịch vụ")]
        [Display(Name = "Đơn giá")]
        public string DonGia { set; get; }
    }
    class ListDichVu
    {
        DataConnection db;
        public ListDichVu()
        {
            db = new DataConnection();
        }

        //Viết phương thức lấy dữ liệu nhân viên từ CSDL
        public List<QLDichVu> getDichVu(string MADV)
        {
            string sql;
            if (string.IsNullOrEmpty(MADV))
            {
                sql = "SELECT * FROM DichVu";
            }
            else
            {
                sql = "SELECT * FROM DichVu WHERE MaDV='" + MADV + "'";
            }

            List<QLDichVu> strList = new List<QLDichVu>();
            SqlConnection con = db.getConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();

            //Mở kết nối
            con.Open();
            cmd.Fill(dt);

            //Đóng kết nối
            cmd.Dispose();
            con.Close();

            QLDichVu strDV;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strDV = new QLDichVu();

                strDV.MADV = dt.Rows[i]["MADV"].ToString();
                strDV.TenDV = dt.Rows[i]["TenDV"].ToString();
                strDV.MoTa = dt.Rows[i]["MoTa"].ToString();
                strDV.DonGia = dt.Rows[i]["DonGia"].ToString();

                strList.Add(strDV);
            }
            return strList;
        }
        // Thêm dữ liệu (thêm nhân viên)
        public void AddDichVu(QLDichVu strDV)
        {

            string sql = "INSERT INTO DichVu(TenDV, MoTa, DonGia)VALUES(N'" + strDV.TenDV + "',N'" + strDV.MoTa + "',N'" + strDV.DonGia + "')";
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
        public void EditDichVu(QLDichVu strDV)
        {

            string sql = "UPDATE DichVu SET  TenDV=N'" + strDV.TenDV + "', MoTa=N'" + strDV.MoTa + "', DonGia=N'" + strDV.DonGia + "' WHERE MaDV='" + strDV.MADV + "'";
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
        public void DeleteDichVu(QLDichVu strDV)
        {
            string sql = "DELETE FROM DichVu WHERE MaDV='" + strDV.MADV + "'";
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