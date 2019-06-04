using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedding_management_project.Models;

namespace Wedding_management_project.Controllers
{
    public class NhanViensController : Controller
    {
        // GET: NhanViens
        public ActionResult Index()
        {
            ListNhanVien strNV = new ListNhanVien();
            List<QLNhanVien> obj = strNV.getNhanVien(string.Empty);
            return View(obj);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(QLNhanVien strNV)
        {
            if (ModelState.IsValid)
            {
                ListNhanVien NV = new ListNhanVien();
                NV.AddNhanVien(strNV);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}