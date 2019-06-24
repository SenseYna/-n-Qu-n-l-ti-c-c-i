using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedding_management_project.Models;

namespace Wedding_management_project.Controllers
{
    public class SanhsController : Controller
    {
        // GET: Sanhs
        public ActionResult Index()
        {
            ListSanh strS = new ListSanh();
            List<QLSanh> obj = strS.getSanh(string.Empty);
            return View(obj);
        }
        //Thêm sảnh
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(QLSanh strS)
        {
            if (ModelState.IsValid)
            {
                ListSanh S = new ListSanh();
                S.AddSanh(strS);
                return RedirectToAction("Index");
            }
            return View();
        }
        //Sửa sảnh
        public ActionResult Edit(string mas = "")
        {
            ListSanh S = new ListSanh();
            List<QLSanh> obj = S.getSanh(mas);
            return View(obj.FirstOrDefault());
        }

        [HttpPost]

        public ActionResult Edit(QLSanh strS)
        {
            ListSanh S = new ListSanh();
            S.EditSanh(strS);
            return RedirectToAction("Index");
        }

        //Xóa sảnh
        public ActionResult Delete(string mas = "")
        {
            ListSanh S = new ListSanh();
            List<QLSanh> obj = S.getSanh(mas);
            return View(obj.FirstOrDefault());
        }

        [HttpPost]

        public ActionResult Delete(QLSanh strS)
        {
            ListSanh S = new ListSanh();
            S.DeleteSanh(strS);
            return RedirectToAction("Index");
        }
    }
}