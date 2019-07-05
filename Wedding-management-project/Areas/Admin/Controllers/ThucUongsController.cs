using Wedding_management_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedding_management_project.Common;

namespace Wedding_management_project.Areas.Admin.Controllers
{
    public class ThucUongsController : Controller
    {
        // GET: ThucUongs
        public ActionResult Index()
        {
            if (Session[CommonConstants.ADMIN_SESSION] == null) return RedirectToAction("Index", "LoginAdmin", new { area = "user" }); //Check session Đăng nhập

            ListThucUong strTU = new ListThucUong();
            List<QLThucUong> obj = strTU.getThucUong(string.Empty);
            return View(obj);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(QLThucUong strTU)
        {
            if (ModelState.IsValid)
            {
                ListThucUong MA = new ListThucUong();
                MA.AddThucUong(strTU);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}