using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Wedding_management_project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
                return View();
        }

        public ActionResult MonAn()
        {
            return View("Index", "MonAnsController");
        }

        public ActionResult SoKhachHang()
        {
            return View();
        }

        public ActionResult PhieuKhachHang()
        {
            return View();
        }

        public ActionResult NhanSu()
        {
            return View();
        }

        public ActionResult HoaDon()
        {
            return View();
        }

        public ActionResult DichVu()
        {
            return View();
        }

        public ActionResult BaoCao()
        {
            return View();
        }

        public ActionResult DoanhThu()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}