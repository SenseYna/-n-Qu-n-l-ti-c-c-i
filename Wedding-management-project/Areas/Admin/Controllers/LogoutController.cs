using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedding_management_project.Common;

namespace Wedding_management_project.Areas.Admin.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Admin/Logout
        public ActionResult Index()
        {
            Session.Add(CommonConstants.ADMIN_SESSION, null);
            return RedirectToAction("Index", "Home", new { area = "User" });
        }
    }
}