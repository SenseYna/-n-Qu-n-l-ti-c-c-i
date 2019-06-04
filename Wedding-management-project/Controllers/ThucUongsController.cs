using Wedding_management_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wedding_management_project.Controllers
{
    public class ThucUongsController : Controller
    {
        // GET: ThucUongs
        public ActionResult Index()
        {
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