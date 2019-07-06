using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wedding_management_project.Areas.User.Controllers
{
    public class LogoutController : Controller
    {
        // GET: User/Logout
        public ActionResult Index()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login", new { area = "User" });
        }
    }
}