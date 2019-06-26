using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Wedding_management_project.Models
{
    public class QLThucUong
    {
        public int ID { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Mã thức uống")]
        [Display(Name = "Mã thức uống")]
        public string MaTU { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Tên thức uống")]
        [Display(Name = "Tên thức uống")]
        public string TenTU { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Mô tả thức uống")]
        [Display(Name = "Mô tả")]
        public string MoTaTU { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Đơn vị tính thức uống")]
        [Display(Name = "Đơn vị tính")]
        public string DonViTinh { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Đơn giá thức uống")]
        [Display(Name = "Đơn giá")]
        public string DonGiaTU { set; get; }
    }
    class ListThucUong
    {
        DataConnection db;
        public ListThucUong()
        {
            db = new DataConnection();
        }

        //Viết phương thức lấy dữ liệu nhân viên từ CSDL
        public List<QLThucUong> getThucUong(string ID)
        {
            string sql;
            if (string.IsNullOrEmpty(ID))
            {
                sql = "SELECT * FROM ThucUong";
            }
            else
            {
                sql = "SELECT * FROM ThucUong WHERE Id=" + ID;
            }

            List<QLThucUong> strList = new List<QLThucUong>();
            SqlConnection con = db.getConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();

            //Mở kết nối
            con.Open();
            cmd.Fill(dt);

            //Đóng kết nối
            cmd.Dispose();
            con.Close();

            QLThucUong strTU;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strTU = new QLThucUong();
                strTU.MaTU = dt.Rows[i]["MaTU"].ToString();
                strTU.TenTU = dt.Rows[i]["TenTU"].ToString();
                strTU.MoTaTU = dt.Rows[i]["MoTaTU"].ToString();
                strTU.DonViTinh = dt.Rows[i]["DonViTinh"].ToString();
                strTU.DonGiaTU = dt.Rows[i]["DonGiaTU"].ToString();

                strList.Add(strTU);
            }
            return strList;
        }
        // Thêm dữ liệu (thêm món ăn)
        public void AddThucUong(QLThucUong strTU)
        {
            string sql = "INSERT INTO ThucUong(MaTU, TenTU, MoTaTU, DonViTinh, DonGiaTU)VALUES(N'" + strTU.MaTU + "',N'" + strTU.TenTU + "',N'" + strTU.MoTaTU + "',N'" + strTU.DonViTinh + "',N'" + strTU.DonGiaTU + "')";
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            //Mở kết nối
            con.Open();
            cmd.ExecuteNonQuery();

            //Đóng kết nối
            cmd.Dispose();
            con.Close();
        }
        // Sửa dữ liệu (sửa món ăn)
        public void EditThucUong(QLThucUong strTU)
        {
            string sql = "UPDATE ThucUong SET MaTU = N'" + strTU.MaTU + "', TenTU=N'" + strTU.TenTU + "', MoTaTU=N'" + strTU.MoTaTU + "', DonViTinh=N'" + strTU.DonViTinh + "', DonGiaTU=N'" + strTU.DonGiaTU + "' WHERE Id=" + strTU.ID;
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            //Mở kết nối
            con.Open();
            cmd.ExecuteNonQuery();

            //Đóng kết nối
            cmd.Dispose();
            con.Close();
        }
        // Xóa dữ liệu (xóa món ăn)
        public void DeleteMonAn(QLThucUong strTU)
        {
            string sql = "DELETE FROM ThucUong WHERE Id=" + strTU.ID;
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