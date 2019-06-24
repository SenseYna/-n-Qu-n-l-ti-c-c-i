using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedding_management_project.Models;

namespace Wedding_management_project.Controllers
{
    public class DichVusController : Controller
    {
        // GET: DichVus
        public ActionResult Index()
        {
            ListDichVu strDV = new ListDichVu();
            List<QLDichVu> obj = strDV.getDichVu(string.Empty);
            return View(obj);
        }
        //Thêm dịch vụ
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(QLDichVu strDV)
        {
            if (ModelState.IsValid)
            {
                ListDichVu DV = new ListDichVu();
                DV.AddDichVu(strDV);
                return RedirectToAction("Index");
            }
            return View();
        }
        //Sửa dịch vụ
        public ActionResult Edit(string madv = "")
        {
            ListDichVu DV = new ListDichVu();
            List<QLDichVu> obj = DV.getDichVu(madv);
            return View(obj.FirstOrDefault());
        }

        [HttpPost]

        public ActionResult Edit(QLDichVu strDV)
        {
            ListDichVu DV = new ListDichVu();
            DV.EditDichVu(strDV);
            return RedirectToAction("Index");
        }

        //Xóa dịch vụ
        public ActionResult Delete(string madv = "")
        {
            ListDichVu DV = new ListDichVu();
            List<QLDichVu> obj = DV.getDichVu(madv);
            return View(obj.FirstOrDefault());
        }

        [HttpPost]

        public ActionResult Delete(QLDichVu strDV)
        {
            ListDichVu DV = new ListDichVu();
            DV.DeleteDichVu(strDV);
            return RedirectToAction("Index");
        }
    }
}