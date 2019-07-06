using Wedding_management_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedding_management_project.Common;

namespace Wedding_management_project.Areas.User.Controllers
{
    public class ThucUongsController : Controller
    {
        // GET: ThucUongs
        public ActionResult Index()
        {
            if (Session[CommonConstants.USER_SESSION] == null) return RedirectToAction("Index", "Login"); //Check session Đăng nhập
            ListThucUong strTU = new ListThucUong();
            List<QLThucUong> obj = strTU.getThucUong(string.Empty);
            return View(obj);
        }
    
    }
}