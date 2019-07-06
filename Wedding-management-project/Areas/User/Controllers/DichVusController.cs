using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedding_management_project.Areas.Admin.Models;
using Wedding_management_project.Common;
using Wedding_management_project.Models;

namespace Wedding_management_project.Areas.User.Controllers
{
    public class DichVusController : Controller
    {
        // GET: Admin/DichVus
        public ActionResult Index()
        {
            if (Session[CommonConstants.USER_SESSION] == null) return RedirectToAction("Index", "Login"); //Check session Đăng nhập
            ListDichVu strDV = new ListDichVu();
            List<QLDichVu> obj = strDV.getDichVu(string.Empty);
            return View(obj);
        }

       
    }
}