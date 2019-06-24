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
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
         
           if (Session[CommonConstants.USER_SESSION] != null) return RedirectToAction("Index", "Home");
            else 
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            var dao = new Login();
            if (model.Password == null) model.Password = "";
            var result = dao.checkLogin(model.UserName, Encryptor.MD5Hash(model.Password));

            if (result == 2)
            {
                var userSession = model.UserName;
                Session.Add(CommonConstants.USER_SESSION, userSession);
                Session.Add(CommonConstants.ADMIN_SESSION, userSession);
                return RedirectToAction("Index", "Home");
            }
            else if (result == 1)
            {
                var userSession = model.UserName;
                Session.Add(CommonConstants.USER_SESSION, userSession);   
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Đăng nhập không đúng.");
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