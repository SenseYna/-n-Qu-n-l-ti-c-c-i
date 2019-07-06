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
        [Display(Name = "Mã thức uống")]
        public string MATU { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Tên thức uống")]
        [Display(Name = "Tên thức uống")]
        public string TenTU { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Mô tả thức uống")]
        [Display(Name = "Mô tả")]
        public string MoTaTU { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Đơn vị tính thức uống")]
        [Display(Name = "Đơn vị tính")]
        public string DonViTinh { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Giá mua thức uống")]
        [Display(Name = "Giá mua")]
        public string GiaMua { set; get; }
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
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                strTU = new QLThucUong();
                strTU.MATU = dt.Rows[i]["MaTU"].ToString();
                strTU.TenTU = dt.Rows[i]["TenTU"].ToString();
                strTU.MoTaTU = dt.Rows[i]["MoTaTU"].ToString();
                strTU.DonViTinh = dt.Rows[i]["DonViTinh"].ToString();
                strTU.GiaMua = dt.Rows[i]["GiaMua"].ToString();
                strTU.DonGiaTU = dt.Rows[i]["DonGiaTU"].ToString();

                strList.Add(strTU);
            }
            return strList;
        }
        // Thêm dữ liệu (thêm món ăn)
        public void AddThucUong(QLThucUong strTU)
        {
            string sql = "INSERT INTO ThucUong(TenTU, MoTaTU, DonViTinh, DonGiaTU)VALUES(N'" + strTU.TenTU + "',N'" + strTU.MoTaTU + "',N'" + strTU.DonViTinh + "',N'" + strTU.GiaMua + "',N'" + (Convert.ToInt32(strTU.GiaMua) + Convert.ToInt32(strTU.GiaMua) * 0.25) + "')";
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
            string sql = "UPDATE ThucUong SET TenTU=N'" + strTU.TenTU + "', MoTaTU=N'" + strTU.MoTaTU + "', DonViTinh=N'" + strTU.DonViTinh + "', GiaMua=N'" + strTU.GiaMua + "', DonGiaTU=N'" + (Convert.ToInt32(strTU.GiaMua) + Convert.ToInt32(strTU.GiaMua) * 0.25) + "' WHERE MaTU=" + strTU.MATU;
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
            string sql = "DELETE FROM ThucUong WHERE MaTU=" + strTU.MATU;
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