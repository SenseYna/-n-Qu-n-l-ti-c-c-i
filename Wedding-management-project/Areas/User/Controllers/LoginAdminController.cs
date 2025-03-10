﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedding_management_project.Areas.Admin.Models;
using Wedding_management_project.Common;
using Wedding_management_project.Models;

namespace Wedding_management_project.Areas.User.Controllers
{
    public class LoginAdminController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {          
            if (Session[CommonConstants.ADMIN_SESSION] != null) return RedirectToAction("Index", "Home", new { Area = "Admin" });
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            var dao = new Login();
            if (model.Password == null) model.Password = "";
            var result = dao.checkLogin(model.UserName, Encryptor.MD5Hash(model.Password));
            if (result == 2)
            {
                var adminSession = model.UserName;
                Session.Add(CommonConstants.ADMIN_SESSION, adminSession);
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            else
            {
                return Content("<html><head><script>alert('Hello, World!');</script></head></html>");


            }
            return View("Index");
        }

        public ActionResult ClearSession()
        {
            Session.Clear();
            return View("Index");
        }
    }
}
