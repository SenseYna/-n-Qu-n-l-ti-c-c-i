using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Wedding_management_project.Models
{
    public class QLMonAn
    {
        [Display(Name = "Mã món ăn")]
        public string MAMA { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Tên Món Ăn")]
        [Display(Name = "Tên món ăn")]
        public string TenMA { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Mô tả Món Ăn")]
        [Display(Name = "Mô tả")]
        public string MoTaMA { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Đơn vị tính Món Ăn")]
        [Display(Name = "Đơn vị tính")]
        public string DonViTinh { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Giá mua Món Ăn")]
        [Display(Name = "Giá Mua")]
        public string GiaMua { set; get; }
        [Display(Name = "Đơn giá")]
        public string DonGiaMA { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Loại Món Ăn")]
        [Display(Name = "Loại")]
        public string LoaiMA { set; get; }

    }
    class ListMonAn
    {
        DataConnection db;
        public ListMonAn()
        {
            db = new DataConnection();
        }

        //Viết phương thức lấy dữ liệu nhân viên từ CSDL
        public List<QLMonAn> getMonAn(string MAMA)
        {
            string sql;
            if (string.IsNullOrEmpty(MAMA))
            {
                sql = "SELECT * FROM MonAn";
            }
            else
            {
                sql = "SELECT * FROM MonAn WHERE MaMA='" + MAMA + "'";
            }

            List<QLMonAn> strList = new List<QLMonAn>();
            SqlConnection con = db.getConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();

            //Mở kết nối
            con.Open();
            cmd.Fill(dt);

            //Đóng kết nối
            cmd.Dispose();
            con.Close();

            QLMonAn strMA;
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                strMA = new QLMonAn();

                strMA.MAMA = dt.Rows[i]["MAMA"].ToString();
                strMA.TenMA = dt.Rows[i]["TenMA"].ToString();
                strMA.MoTaMA= dt.Rows[i]["MoTaMA"].ToString();
                strMA.DonViTinh = dt.Rows[i]["DonViTinh"].ToString();
                strMA.GiaMua = dt.Rows[i]["GiaMua"].ToString();
                strMA.DonGiaMA= dt.Rows[i]["DonGiaMA"].ToString();
                strMA.LoaiMA = dt.Rows[i]["LoaiMA"].ToString();

                strList.Add(strMA);
            }
            return strList;
        }
        // Thêm dữ liệu (thêm món ăn)
        public void AddMonAn(QLMonAn strMA)
        {
            string sql = "INSERT INTO MonAn(TenMA, MoTaMA, DonViTinh, GiaMua, DonGiaMA, LoaiMA)VALUES(N'" + strMA.TenMA + "',N'" + strMA.MoTaMA + "',N'" + strMA.DonViTinh + "',N'" + strMA.GiaMua + "',N'" + (Convert.ToInt32(strMA.GiaMua)+Convert.ToInt32(strMA.GiaMua)*0.25) + "',N'" + strMA.LoaiMA + "')";
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
        public void EditMonAn(QLMonAn strMA)
        {
            string sql = "UPDATE MonAn SET  TenMA=N'" + strMA.TenMA + "', MoTaMA=N'" + strMA.MoTaMA + "', DonViTinh=N'" + strMA.DonViTinh + "', GiaMua=N'" + strMA.GiaMua + "', DonGiaMA=N'" + (Convert.ToInt32(strMA.GiaMua) + Convert.ToInt32(strMA.GiaMua) * 0.25) + "', LoaiMA=N'" + strMA.LoaiMA + "' WHERE MaMA='" + strMA.MAMA + "'";
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
        public void DeleteMonAn(QLMonAn strMA)
        {
            string sql = "DELETE FROM MonAn WHERE MaMA='" + strMA.MAMA + "'";
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