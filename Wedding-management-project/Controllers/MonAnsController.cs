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
        //Thêm món ăn
        public ActionResult Create()
        {
            ViewBag.Error = TempData["e"] == null ? "" : TempData["e"].ToString();
            ViewBag.Files = TempData["file"] == null ? new List<string>() : (List<string>)TempData["file"];
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


        //Sửa món ăn
        public ActionResult Edit(string mama ="")
        {
            ListMonAn MA = new ListMonAn();
            List<QLMonAn> obj = MA.getMonAn(mama);
            return View(obj.FirstOrDefault());
        }

        [HttpPost]

        public ActionResult Edit(QLMonAn strMA)
        {
                ListMonAn MA = new ListMonAn();
                MA.EditMonAn(strMA);
                return RedirectToAction("Index");
        }

        //Xóa món ăn
        public ActionResult Delete(string mama = "")
        {
            ListMonAn MA = new ListMonAn();
            List<QLMonAn> obj = MA.getMonAn(mama);
            return View(obj.FirstOrDefault());
        }

        [HttpPost]

        public ActionResult Delete(QLMonAn strMA)
        {
            ListMonAn MA = new ListMonAn();
            MA.DeleteMonAn(strMA);
            return RedirectToAction("Index");
        }
    }
}