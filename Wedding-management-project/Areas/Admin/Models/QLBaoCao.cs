using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace Wedding_management_project.Models
{
    public class QLBaoCao
    {
        [Required(ErrorMessage = "Bạn cần nhập vào Báo cáo")]
        [Display(Name = "Mã Báo cáo")]
        public string MaBC { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Từ ngày")]
        [Display(Name = "Từ ngày")]
        [DataType(DataType.Date)]
        public DateTime TuNgay { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào Đến ngày")]
        [Display(Name = "Đến ngày")]
        [DataType(DataType.Date)]
        public DateTime DenNgay { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào ngày tạo")]
        [Display(Name = "Ngày tạo")]
        [DataType(DataType.Date)]
        public DateTime NgayTao { set; get; }
        public QLPhieuTheoDoiTiec PTDT { set; get; }

    }
}