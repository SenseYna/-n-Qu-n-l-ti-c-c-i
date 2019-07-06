using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedding_management_project.Models;
using System.IO;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;


namespace Wedding_management_project.Areas.Admin.Controllers
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
                System.Threading.Thread.Sleep(500);
                return RedirectToAction("Index");
            }
            return View();
        }
        //Sửa phiếu đặt tiệc
        public ActionResult Edit(string mapdt = "")
        {
            ListPhieuDatTiec PDT = new ListPhieuDatTiec();
            List<QLPhieuDatTiec> obj = PDT.getPhieuDatTiec_ED(mapdt);
            return View(obj.FirstOrDefault());
        }

        [HttpPost]

        public ActionResult Edit(QLPhieuDatTiec strPDT)
        {
            ListPhieuDatTiec PDT = new ListPhieuDatTiec();
            PDT.EditPhieuDatTiec(strPDT);
            System.Threading.Thread.Sleep(500);
            return RedirectToAction("Index");
        }

        //Xóa phiếu đặt tiệc
        public ActionResult Delete(string mapdt = "")
        {
            ListPhieuDatTiec PDT = new ListPhieuDatTiec();
            List<QLPhieuDatTiec> obj = PDT.getPhieuDatTiec_ED(mapdt);
            return View(obj.FirstOrDefault());
        }

        [HttpPost]

        public ActionResult Delete(QLPhieuDatTiec strPDT)
        {
            ListPhieuDatTiec PDT = new ListPhieuDatTiec();
            PDT.DeletePhieuDatTiec(strPDT);
            System.Threading.Thread.Sleep(500);
            return RedirectToAction("Index");
        }
    }
}