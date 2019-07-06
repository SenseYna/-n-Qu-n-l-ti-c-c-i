using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedding_management_project.Areas.Admin.Models;
using Wedding_management_project.Models;
using System.IO;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;


namespace Wedding_management_project.Areas.Admin.Controllers
{
    public class KhachHangsController : Controller
    {
        // GET: Admin/KhachHangs
        public ActionResult Index()
        {
            ListKhachHang strKH = new ListKhachHang();
            List<QLKhachHang> obj = strKH.getKhachHang(string.Empty);
            return View(obj);
        }
        //Thêm khách hàng
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(QLKhachHang strKH)
        {
            if (ModelState.IsValid)
            {
                ListKhachHang KH = new ListKhachHang();
                KH.AddKhachHang(strKH);
                System.Threading.Thread.Sleep(500);
                return RedirectToAction("Index");
            }
            return View();
        }
        //Sửa khách hàng
        public ActionResult Edit(string makh = "")
        {
            ListKhachHang KH = new ListKhachHang();
            List<QLKhachHang> obj = KH.getKhachHang(makh);
            return View(obj.FirstOrDefault());
        }

        [HttpPost]

        public ActionResult Edit(QLKhachHang strKH)
        {
            ListKhachHang KH = new ListKhachHang();
            KH.EditKhachHang(strKH);
            System.Threading.Thread.Sleep(500);
            return RedirectToAction("Index");
        }

        //Xóa khách hàng
        public ActionResult Delete(string makh = "")
        {
            ListKhachHang KH = new ListKhachHang();
            List<QLKhachHang> obj = KH.getKhachHang(makh);
            return View(obj.FirstOrDefault());
        }

        [HttpPost]

        public ActionResult Delete(QLKhachHang strKH)
        {
            ListKhachHang KH = new ListKhachHang();
            KH.DeleteKhachHang(strKH);
            return RedirectToAction("Index");
        }
        private Stream CreateExcelFile(Stream stream = null)
        {

            ListKhachHang strNV = new ListKhachHang();
            var list = strNV.getKhachHang(string.Empty);

            using (var excelPackage = new ExcelPackage(stream ?? new MemoryStream()))
            {
                // Tạo author cho file Excel
                excelPackage.Workbook.Properties.Author = "Hanker";
                // Tạo title cho file Excel
                excelPackage.Workbook.Properties.Title = "EPP test background";
                // thêm tí comments vào làm màu 
                excelPackage.Workbook.Properties.Comments = "This is my fucking generated Comments";
                // Add Sheet vào file Excel
                excelPackage.Workbook.Worksheets.Add("First Sheet");
                // Lấy Sheet bạn vừa mới tạo ra để thao tác 
                var workSheet = excelPackage.Workbook.Worksheets[1];
                // Đổ data vào Excel file
                workSheet.Cells[1, 1].LoadFromCollection(list, true, TableStyles.Dark9);
                // BindingFormatForExcel(workSheet, list);
                excelPackage.Save();
                return excelPackage.Stream;
            }
        }

        private void BindingFormatForExcel(ExcelWorksheet worksheet, List<QLKhachHang> listItems)
        {
            // Set default width cho tất cả column
            worksheet.DefaultColWidth = 10;
            // Tự động xuống hàng khi text quá dài
            worksheet.Cells.Style.WrapText = true;
            // Tạo header

            worksheet.Cells[1, 1].Value = "Mã";
            worksheet.Cells[1, 2].Value = "Họ tên";
            worksheet.Cells[1, 4].Value = "Địa chỉ";
            worksheet.Cells[1, 5].Value = "Sđt";
            worksheet.Cells[1, 6].Value = "CMND";
            worksheet.Cells[1, 7].Value = "Email";


            // Lấy range vào tạo format cho range đó ở đây là từ A1 tới D1
            using (var range = worksheet.Cells["A1:I1"])
            {
                // Set PatternType
                range.Style.Fill.PatternType = ExcelFillStyle.DarkGray;
                // Set Màu cho Background
                range.Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                // Canh giữa cho các text
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                // Set Font cho text  trong Range hiện tại
                range.Style.Font.SetFromFont(new Font("Arial", 10));
                // Set Border
                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                // Set màu ch Border
                range.Style.Border.Bottom.Color.SetColor(Color.Blue);
            }

            // Đỗ dữ liệu từ list vào 
            for (int i = 0; i < listItems.Count; i++)
            {
                var item = listItems[i];
                worksheet.Cells[i + 2, 1].Value = item.MAKH;
                worksheet.Cells[i + 2, 2].Value = item.TenKH;
                worksheet.Cells[i + 2, 3].Value = item.DiaChi;
                worksheet.Cells[i + 2, 4].Value = item.SĐT;
                worksheet.Cells[i + 2, 5].Value = item.CMND;
                worksheet.Cells[i + 2, 6].Value = item.Email;
               

             
            }
            worksheet.Cells[1, 1, listItems.Count + 5, 4].AutoFitColumns(15);

        }

        [HttpGet]
        public ActionResult Export()
        {
            // Gọi lại hàm để tạo file excel
            var stream = CreateExcelFile();
            // Tạo buffer memory strean để hứng file excel
            var buffer = stream as MemoryStream;
            // Đây là content Type dành cho file excel, còn rất nhiều content-type khác nhưng cái này mình thấy okay nhất
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            // Dòng này rất quan trọng, vì chạy trên firefox hay IE thì dòng này sẽ hiện Save As dialog cho người dùng chọn thư mục để lưu
            // File name của Excel này là ExcelDemo
            Response.AddHeader("Content-Disposition", "attachment; filename=ExcelDemo.xlsx");
            // Lưu file excel của chúng ta như 1 mảng byte để trả về response
            Response.BinaryWrite(buffer.ToArray());
            // Send tất cả ouput bytes về phía clients
            Response.Flush();
            Response.End();
            // Redirect về luôn trang index :D
            return RedirectToAction("Index");
        }


    }
}