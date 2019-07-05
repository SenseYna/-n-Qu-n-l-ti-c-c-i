using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedding_management_project.Areas.Admin.Models;
using Wedding_management_project.Models;

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
    }
}