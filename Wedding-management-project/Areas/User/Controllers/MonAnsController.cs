using Wedding_management_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedding_management_project.Common;

namespace Wedding_management_project.Areas.User.Controllers
{
    public class MonAnsController : Controller
    {
        private ListMonAn a = new ListMonAn();
        public ActionResult Index()
        {
            if (Session[CommonConstants.USER_SESSION] == null) return RedirectToAction("Index", "Login"); //Check session Đăng nhập
            ListMonAn strMA = new ListMonAn();
            List<QLMonAn> obj = strMA.getMonAn(string.Empty);
            return View(obj);
        }

  
    }
}