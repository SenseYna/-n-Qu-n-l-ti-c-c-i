using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedding_management_project.Models;

namespace Wedding_management_project.Areas.User.Controllers
{
    public class PhieuDatTiecsController : Controller
    {
        // GET: Admin/PhieuDatTiecs
        public ActionResult Index()
        {
            ListPhieuDatTiec strPDT = new ListPhieuDatTiec();
            List<QLPhieuDatTiec> obj = strPDT.getPhieuDatTiec(string.Empty);
            return View(obj);
        }
        //Thêm phiếu đặt tiệc
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(QLPhieuDatTiec strPDT)
        {
            if (ModelState.IsValid)
            {
                ListPhieuDatTiec PDT = new ListPhieuDatTiec();
                PDT.AddPhieuDatTiec(strPDT);
                return RedirectToAction("Index");
            }
            return View();
        }
      
    }
}