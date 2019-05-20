using Wedding_management_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wedding_management_project.Controllers
{
    public class MonAnsController : Controller
    {
        public ActionResult Index()
        {
            ListMonAn strMA = new ListMonAn();
            List<QLMonAn> obj = strMA.getMonAn(string.Empty);
            return View(obj);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(QLMonAn strMA)
        {
            if (ModelState.IsValid)
            {
                ListMonAn MA = new ListMonAn();
                MA.AddMonAn(strMA);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}