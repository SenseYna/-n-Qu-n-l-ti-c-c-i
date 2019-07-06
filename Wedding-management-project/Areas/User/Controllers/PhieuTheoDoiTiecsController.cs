using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedding_management_project.Common;
using Wedding_management_project.Models;

namespace Wedding_management_project.Areas.User.Controllers
{
    public class PhieuTheoDoiTiecsController : Controller
    {
        // GET: Admin/PhieuTheoDoiTiecs
        public ActionResult Index()
        {
            if (Session[CommonConstants.USER_SESSION] == null) return RedirectToAction("Index", "Login"); //Check session Đăng nhập
            ListPhieuTheoDoiTiec strPTDT = new ListPhieuTheoDoiTiec();
            List<QLPhieuTheoDoiTiec> obj = strPTDT.getPhieuTheoDoiTiec(string.Empty);
            return View(obj);
        }
        //Thêm phiếu đặt tiệc
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(QLPhieuTheoDoiTiec strPTDT)
        {
            if (ModelState.IsValid)
            {
                ListPhieuTheoDoiTiec PTDT = new ListPhieuTheoDoiTiec();
                PTDT.AddPhieuTheoDoiTiec(strPTDT);
                System.Threading.Thread.Sleep(500);
                return RedirectToAction("Index");
            }
            return View();
        }
        //Sửa phiếu đặt tiệc
        public ActionResult Edit(string maptdt = "")
        {
            ListPhieuTheoDoiTiec PTDT = new ListPhieuTheoDoiTiec();
            List<QLPhieuTheoDoiTiec> obj = PTDT.getPhieuTheoDoiTiec_ED(maptdt);
            return View(obj.FirstOrDefault());
        }

        [HttpPost]

        public ActionResult Edit(QLPhieuTheoDoiTiec strPTDT)
        {
            ListPhieuTheoDoiTiec PTDT = new ListPhieuTheoDoiTiec();
            PTDT.EditPhieuTheoDoiTiec(strPTDT);
            System.Threading.Thread.Sleep(500);
            return RedirectToAction("Index");
        }

        //Xóa phiếu đặt tiệc
        public ActionResult Delete(string maptdt = "")
        {
            ListPhieuTheoDoiTiec PTDT = new ListPhieuTheoDoiTiec();
            List<QLPhieuTheoDoiTiec> obj = PTDT.getPhieuTheoDoiTiec_ED(maptdt);
            return View(obj.FirstOrDefault());
        }

        [HttpPost]

        public ActionResult Delete(QLPhieuTheoDoiTiec strPTDT)
        {
            ListPhieuTheoDoiTiec PTDT = new ListPhieuTheoDoiTiec();
            PTDT.DeletePhieuTheoDoiTiec(strPTDT);
            System.Threading.Thread.Sleep(500);
            return RedirectToAction("Index");
        }
    }
}