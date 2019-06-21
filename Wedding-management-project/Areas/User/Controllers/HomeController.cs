using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedding_management_project.Common;

namespace Wedding_management_project.Areas.User.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            if (Session[CommonConstants.USER_SESSION] == null) return RedirectToAction("Index", "Login"); //Check session Đăng nhập
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