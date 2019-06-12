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
        //Thêm nhân viên
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
        //Sửa nhân viên
        public ActionResult Edit(string manv = "")
        {
            ListNhanVien NV = new ListNhanVien();
            List<QLNhanVien> obj = NV.getNhanVien(manv);
            return View(obj.FirstOrDefault());
        }

        [HttpPost]

        public ActionResult Edit(QLNhanVien strNV)
        {
            ListNhanVien NV = new ListNhanVien();
            NV.EditNhanVien(strNV);
            return RedirectToAction("Index");
        }

        //Xóa nhân viên
        public ActionResult Delete(string manv = "")
        {
            ListNhanVien NV = new ListNhanVien();
            List<QLNhanVien> obj = NV.getNhanVien(manv);
            return View(obj.FirstOrDefault());
        }

        [HttpPost]

        public ActionResult Delete(QLNhanVien strNV)
        {
            ListNhanVien NV = new ListNhanVien();
            NV.DeleteNhanVien(strNV);
            return RedirectToAction("Index");
        }
    }
}