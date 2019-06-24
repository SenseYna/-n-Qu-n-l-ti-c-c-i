using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Wedding_management_project.Models
{
    public class QLSoDatTiec
    {
        [Display(Name = "Mã sổ đặt tiệc")]
        public string MASDT { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Mã Phiếu đặt tiệc")]
        [Display(Name = "Mã Phiếu đặt tiệc")]
        public string MaPDT { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Mã Nhân viên")]
        [Display(Name = "Mã Nhân viên")]
        public string MaNV { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Mã Món ăn 1")]
        [Display(Name = "Mã Món ăn 1")]
        public string MaMA1 { set; get; }
        [Display(Name = "Mã Món ăn 2")]
        public string MaMA2 { set; get; }
        [Display(Name = "Mã Món ăn 3")]
        public string MaMA3 { set; get; }
        [Display(Name = "Mã Món ăn 4")]
        public string MaMA4 { set; get; }
        [Display(Name = "Mã Món ăn 5")]
        public string MaMA5 { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Mã Thức uống 1")]
        [Display(Name = "Mã Thức uống 1")]
        public string MaTU1 { set; get; }
        [Display(Name = "Mã Thức uống 2")]
        public string MaTU2 { set; get; }
        [Display(Name = "Mã Thức uống 3")]
        public string MaTU3 { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Mã Dịch vụ 1")]
        [Display(Name = "Mã dịch vụ 1")]
        public string MaDV1 { set; get; }
        [Display(Name = "Mã dịch vụ 2")]
        public string MaDV2  { set; get; }
        [Display(Name = "Mã dịch vụ 3")]
        public string MaDV3 { set; get; }
        [Display(Name = "Mã dịch vụ 4")]
        public string MaDV4 { set; get; }
        [Display(Name = "Mã dịch vụ 5")]
        public string MaDV5 { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào yêu cầu khác")]
        [Display(Name = "Yêu cầu khác")]
        public string YeuCauKhac { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập Số tiền cọc Giữa tiệc")]
        [Display(Name = "Số tiền cọc giữa tiệc")]
        public decimal SoTienCocGT { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Ngày tạo")]
        [Display(Name = "Ngày tạo")]
        [DataType(DataType.Date)]
        public DateTime NgayTao { set; get; }
    }
    class ListSoDatTiec
    {
        DataConnection db;
        public ListSoDatTiec()
        {
            db = new DataConnection();
        }

        //Viết phương thức lấy dữ liệu nhân viên từ CSDL
        public List<QLSoDatTiec> getSoDatTiec(string MASDT)
        {
            string sql;
            if (string.IsNullOrEmpty(MASDT))
            {
                sql = "SELECT * FROM SoDatTiec";
            }
            else
            {
                sql = "SELECT * FROM SoDatTiec WHERE MaSDT='" + MASDT + "'";
            }

            List<QLSoDatTiec> strList = new List<QLSoDatTiec>();
            SqlConnection con = db.getConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();

            //Mở kết nối
            con.Open();
            cmd.Fill(dt);

            //Đóng kết nối
            cmd.Dispose();
            con.Close();

            QLSoDatTiec strSDT;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strSDT = new QLSoDatTiec();

                strSDT.MASDT = dt.Rows[i]["MASDT"].ToString();
                strSDT.MaPDT = dt.Rows[i]["MaPDT"].ToString();
                strSDT.MaNV = dt.Rows[i]["MaNV"].ToString();
                strSDT.MaMA1 = dt.Rows[i]["MaMA1"].ToString();
                strSDT.MaMA2 = dt.Rows[i]["MaMA2"].ToString();
                strSDT.MaMA3 = dt.Rows[i]["MaMA3"].ToString();
                strSDT.MaMA4 = dt.Rows[i]["MaMA4"].ToString();
                strSDT.MaMA5 = dt.Rows[i]["MaMA5"].ToString();
                strSDT.MaTU1 = dt.Rows[i]["MaTU1"].ToString();
                strSDT.MaTU2 = dt.Rows[i]["MaTU2"].ToString();
                strSDT.MaTU3 = dt.Rows[i]["MaTU3"].ToString();
                strSDT.MaDV1 = dt.Rows[i]["MaDV1"].ToString();
                strSDT.MaDV2 = dt.Rows[i]["MaDV2"].ToString();
                strSDT.MaDV3 = dt.Rows[i]["MaDV3"].ToString();
                strSDT.MaDV4 = dt.Rows[i]["MaDV4"].ToString();
                strSDT.MaDV5 = dt.Rows[i]["MaDV5"].ToString();
                strSDT.YeuCauKhac = dt.Rows[i]["YeuCauKhac"].ToString();
                strSDT.SoTienCocGT = Convert.ToDecimal(dt.Rows[i]["SoTienCocGT"].ToString());
                strSDT.NgayTao = Convert.ToDateTime(dt.Rows[i]["NgayTao"].ToString());

                strList.Add(strSDT);
            }
            return strList;
        }
        // Thêm dữ liệu (thêm phiếu đặt tiệc)
        public void AddSoDatTiec(QLSoDatTiec strSDT)
        {
            if (strSDT.MaDV2 == "") strSDT.MaDV2 = null;
            string sql = "INSERT INTO SoDatTiec(MaPDT, MaNV, MaMA1, MaMA2, MaMA3, MaMA4, MaMA5, MaTU1, MaTU2, MaTU3, MaDV1, MaDV2, MaDV3, MaDV4, MaDV5, YeuCauKhac, SoTienCocGT, NgayTao)VALUES(N'" + strSDT.MaPDT + "',N'" + strSDT.MaNV + "',N'" + strSDT.MaMA1 + "',N'" + strSDT.MaMA2 + "',N'" + strSDT.MaMA3 + "',N'" + strSDT.MaMA4 + "',N'" + strSDT.MaMA5 + "',N'" + strSDT.MaTU1 + "',N'" + strSDT.MaTU2 + "',N'" + strSDT.MaTU3 + "',N'" + strSDT.MaDV1 + "',N'" + strSDT.MaDV2  + "',N'" + strSDT.MaDV3 + "',N'" + strSDT.MaDV4 + "',N'" + strSDT.MaDV5 + "',N'" + strSDT.YeuCauKhac + "',N'" + strSDT.SoTienCocGT + "',N'" + Convert.ToDateTime(strSDT.NgayTao).ToString("yyyy-MM-dd") + "')";
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            //Mở kết nối
            con.Open();
            cmd.ExecuteNonQuery();

            //Đóng kết nối
            cmd.Dispose();
            con.Close();
        }
        // Sửa dữ liệu (sửa phiếu đặt tiệc)
        public void EditSoDatTiec(QLSoDatTiec strSDT)
        {
            string sql = "UPDATE SoDatTiec SET  MaPDT=N'" + strSDT.MaPDT + "',MaNV=N'" + strSDT.MaNV + "', MaMA1=N'" + strSDT.MaMA1 + "',  MaMA2=N'" + strSDT.MaMA2 + "', MaMA3=N'" + strSDT.MaMA3 + "', MaMA4=N'" + strSDT.MaMA4 + "', MaMA5=N'" + strSDT.MaMA5 + "', MaTU1=N'" + strSDT.MaTU1 + "', MaTU2=N'" + strSDT.MaTU2 + "', MaTU3=N'" + strSDT.MaTU3 + "', MaDV1=N'" + strSDT.MaDV1 + "', MaDV2=N'" + strSDT.MaDV2 + "', MaDV3=N'" + strSDT.MaDV3 + "', MaDV4=N'" + strSDT.MaDV4 + "', MaDV5=N'" + strSDT.MaDV5 + "',YeuCauKhac=N'" + strSDT.YeuCauKhac + "',SoTienCocGT=N'" + strSDT.SoTienCocGT + "', NgayTao=N'" + Convert.ToDateTime(strSDT.NgayTao).ToString("yyyy-MM-dd") + "' WHERE MaSDT='" + strSDT.MASDT + "'";
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            //Mở kết nối
            con.Open();
            cmd.ExecuteNonQuery();

            //Đóng kết nối
            cmd.Dispose();
            con.Close();
        }
        // Xóa dữ liệu (xóa Sổ đặt tiệc)
        public void DeleteSoDatTiec(QLSoDatTiec strSDT)
        {
            string sql = "DELETE FROM SoDatTiec WHERE MaSDT='" + strSDT.MASDT + "'";
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