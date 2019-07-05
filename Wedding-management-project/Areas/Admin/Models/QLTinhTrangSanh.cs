using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace Wedding_management_project.Models
{
    public class QLTinhTrangSanh
    { 
        public string MaTTS { set; get; }

        public DateTime Ngay { set; get; }

        public string MaPDT { set; get; }

        public string MaS { set; get; }

        public string Day { set; get; }
        public string Month { set; get; }
        public string Year { set; get; }

    }
    class ListTinhTrangSanh
    {
        DataConnection db;
        public ListTinhTrangSanh()
        {
            db = new DataConnection();
        }

        //Viết phương thức lấy dữ liệu nhân viên từ CSDL
        public List<QLTinhTrangSanh> getTinhTrangSanh(string MaTTS)
        {
            string sql;
            if (string.IsNullOrEmpty(MaTTS))
            {
                sql = "SELECT * FROM TinhTrangSanh";
            }
            else
            {
                sql = "SELECT * FROM TinhTrangSanh WHERE MaTTS='" + MaTTS + "'";
            }

            List<QLTinhTrangSanh> strList = new List<QLTinhTrangSanh>();
            SqlConnection con = db.getConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();

            //Mở kết nối
            con.Open();
            cmd.Fill(dt);

            //Đóng kết nối
            cmd.Dispose();
            con.Close();

            QLTinhTrangSanh strS;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strS = new QLTinhTrangSanh();
                strS.MaTTS = dt.Rows[i]["MaTTS"].ToString();
                strS.Ngay = Convert.ToDateTime(dt.Rows[i]["Ngay"].ToString());
                strS.MaPDT = dt.Rows[i]["MaPDT"].ToString();
                strS.MaS = dt.Rows[i]["MaS"].ToString();
                strS.Day = strS.Ngay.ToString("dd");
                strS.Month = strS.Ngay.ToString("MM");
                strS.Year = strS.Ngay.ToString("yyyy");
                strList.Add(strS);
            }
            return strList;
        }

        public bool AddTinhTrangSanh(DateTime NgayTC, string MaS, string MaPDT)
        {
            var ngayTC_tostring = Convert.ToDateTime(NgayTC).ToString("ddMMyyyy");
            //ngayTC_tostring.Remove(2, 2);
            //ngayTC_tostring.Remove(4, 4);
            ngayTC_tostring = MaS + ngayTC_tostring;
            string sql = "INSERT INTO TinhTrangSanh(MaTTS, Ngay, MaPDT, MaS)VALUES(N'" + ngayTC_tostring + "',N'" + Convert.ToDateTime(NgayTC).ToString("yyyy-MM-dd") + "',N'" + MaPDT + "',N'" + MaS + "')";

            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                //Mở kết nối
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                //Đóng kết nối
                cmd.Dispose();
                con.Close();
            }

        }


      
        // Xóa dữ liệu ()
        public void DeleteTinhTrangSanh(QLTinhTrangSanh strS)
        {
            string sql = "DELETE FROM TinhTrangSanh WHERE MaTTS='" + strS.MaTTS + "'";
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