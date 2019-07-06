using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Wedding_management_project.Common;
using Wedding_management_project.Models;
using System.Data;
using System.IO;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;




namespace Wedding_management_project.Areas.Admin.Controllers
{
    public class NhanViensController : Controller
    {
        // GET: NhanViens
        public ActionResult Index()
        {
            if (Session[CommonConstants.ADMIN_SESSION] == null) return RedirectToAction("Index", "LoginAdmin", new { area = "user" }); //Check session Đăng nhập

            ListNhanVien strNV = new ListNhanVien();
            List<QLNhanVien> obj = strNV.getNhanVien(string.Empty);
            return View(obj);
        }
        //Thêm nhân viên
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(QLNhanVien strNV)
        {
            if (ModelState.IsValid)
            {
                ListNhanVien NV = new ListNhanVien();
                NV.AddNhanVien(strNV);
                System.Threading.Thread.Sleep(500);
                return RedirectToAction("Index");
            }
            return View();
        }
        //Sửa nhân viên
        public ActionResult Edit(string manv = "")
        {
            ListNhanVien NV = new ListNhanVien();
            List<QLNhanVien> obj = NV.getNhanVien(manv);
            return View(obj.FirstOrDefault());
        }

        [HttpPost]

        public ActionResult Edit(QLNhanVien strNV)
        {
            ListNhanVien NV = new ListNhanVien();
            NV.EditNhanVien(strNV);
            return RedirectToAction("Index");
        }

        //Xóa nhân viên
        public ActionResult Delete(string manv = "")
        {
            ListNhanVien NV = new ListNhanVien();
            List<QLNhanVien> obj = NV.getNhanVien(manv);
            return View(obj.FirstOrDefault());
        }

        [HttpPost]

        public ActionResult Delete(QLNhanVien strNV)
        {
            System.Threading.Thread.Sleep(500);
            ListNhanVien NV = new ListNhanVien();
            NV.DeleteNhanVien(strNV);
            return RedirectToAction("Index");
        }

        private Stream CreateExcelFile(Stream stream = null)
        {

            ListNhanVien strNV = new ListNhanVien();
            var list = strNV.getNhanVien(string.Empty);
           
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

        private void BindingFormatForExcel(ExcelWorksheet worksheet, List<QLNhanVien> listItems)
        {
            // Set default width cho tất cả column
            worksheet.DefaultColWidth = 10;
            // Tự động xuống hàng khi text quá dài
            worksheet.Cells.Style.WrapText = true;
            // Tạo header

            worksheet.Cells[1, 1].Value = "Mã";
            worksheet.Cells[1, 2].Value = "Họ tên";
            worksheet.Cells[1, 3].Value = "Giới Tính";
            worksheet.Cells[1, 4].Value = "Địa chỉ";
            worksheet.Cells[1, 5].Value = "Sđt";
            worksheet.Cells[1, 6].Value = "CMND";
            worksheet.Cells[1, 7].Value = "Email";
            worksheet.Cells[1, 8].Value = "Password";
            worksheet.Cells[1, 9].Value = "Loại";


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
                worksheet.Cells[i + 2, 1].Value = item.MANV;
                worksheet.Cells[i + 2, 2].Value = item.TenNV;
                worksheet.Cells[i + 2, 3].Value = item.GioiTinh;
                worksheet.Cells[i + 2, 4].Value = item.DiaChi;
                worksheet.Cells[i + 2, 5].Value = item.SĐT;
                worksheet.Cells[i + 2, 6].Value = item.CMND;
                worksheet.Cells[i + 2, 7].Value = item.Email;
                worksheet.Cells[i + 2, 8].Value = item.Password;
                worksheet.Cells[i + 2, 9].Value = item.LoaiNV;

                //// Format lại color nếu như thỏa điều kiện
                //if (item.Money > 20050)
                //{
                //    // Ở đây chúng ta sẽ format lại theo dạng fromRow,fromCol,toRow,toCol
                //    using (var range = worksheet.Cells[i + 2, 1, i + 2, 4])
                //    {
                //        // Format text đỏ và đậm
                //        range.Style.Font.Color.SetColor(Color.Red);
                //        range.Style.Font.Bold = true;
                //    }
                //}

            }
            // Format lại định dạng xuất ra ở cột Money
            //      worksheet.Cells[2, 4, listItems.Count + 4, 4].Style.Numberformat.Format = "$#,##.00";
            // fix lại width của column với minimum width là 15
            worksheet.Cells[1, 1, listItems.Count + 5, 4].AutoFitColumns(15);

            // Thực hiện tính theo formula trong excel
            // Hàm Sum 
            //      worksheet.Cells[listItems.Count + 3, 3].Value = "Total is :";
            //      worksheet.Cells[listItems.Count + 3, 4].Formula = "SUM(D2:D" + (listItems.Count + 1) + ")";
            // Hàm SumIf
            //     worksheet.Cells[listItems.Count + 4, 3].Value = "Greater than 20050 :";
            //      worksheet.Cells[listItems.Count + 4, 4].Formula = "SUMIF(D2:D" + (listItems.Count + 1) + ",\">20050\")";
            // Tinh theo %
            //    worksheet.Cells[listItems.Count + 5, 3].Value = "Percentatge: ";
            //    worksheet.Cells[listItems.Count + 5, 4].Style.Numberformat.Format = "0.00%";
            // Dòng này có nghĩa là ở column hiện tại lấy với địa chỉ (Row hiện tại - 1)/ (Row hiện tại - 2) Cùng một colum
            //     worksheet.Cells[listItems.Count + 5, 4].FormulaR1C1 = "(R[-1]C/R[-2]C)";
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