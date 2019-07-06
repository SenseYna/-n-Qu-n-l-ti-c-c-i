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
    public class SoDatTiecsController : Controller
    {
        // GET: Admin/SoDatTiecs
        public ActionResult Index()
        {
            ListSoDatTiec strSDT = new ListSoDatTiec();
            List<QLSoDatTiec> obj = strSDT.getSoDatTiec(string.Empty);
            return View(obj);
        }
        //Thêm phiếu đặt tiệc
        public ActionResult Create() 
        {
            //DropdownList
            ListMonAn strMA = new ListMonAn();
            List<QLMonAn> ListMA = strMA.getMonAn(string.Empty);
            ViewBag.ListMA = ListMA;

            ListThucUong strTU = new ListThucUong();
            List<QLThucUong> ListTU = strTU.getThucUong(string.Empty);
            ViewBag.ListTU = ListTU;

            ListDichVu strDV = new ListDichVu();
            List<QLDichVu> ListDV = strDV.getDichVu(string.Empty);
            ViewBag.ListDV = ListDV;

            return View();
        }

        [HttpPost]

        public ActionResult Create(QLSoDatTiec strSDT)
        {
            if (ModelState.IsValid)
            {
                ListSoDatTiec SDT = new ListSoDatTiec();
                SDT.AddSoDatTiec(strSDT);
                System.Threading.Thread.Sleep(500);
                return RedirectToAction("Index");
            }
            return View();
        }
        //Sửa phiếu đặt tiệc
        public ActionResult Edit(string masdt = "")
        {
            ListSoDatTiec SDT = new ListSoDatTiec();
            List<QLSoDatTiec> obj = SDT.getSoDatTiec_ED(masdt);

            //DropdownList 
            ListMonAn strMA = new ListMonAn();
            List<QLMonAn> ListMA = strMA.getMonAn(string.Empty);
            ViewBag.ListMA = ListMA;

            ListThucUong strTU = new ListThucUong();
            List<QLThucUong> ListTU = strTU.getThucUong(string.Empty);
            ViewBag.ListTU = ListTU;

            ListDichVu strDV = new ListDichVu();
            List<QLDichVu> ListDV = strDV.getDichVu(string.Empty);
            ViewBag.ListDV = ListDV;

            return View(obj.FirstOrDefault());
        }

        [HttpPost]

        public ActionResult Edit(QLSoDatTiec strSDT)
        {
            ListSoDatTiec SDT = new ListSoDatTiec();
            SDT.EditSoDatTiec(strSDT);
            System.Threading.Thread.Sleep(500);
            return RedirectToAction("Index");
        }

        //Xóa phiếu đặt tiệc
        public ActionResult Delete(string masdt = "")
        {
            ListSoDatTiec SDT = new ListSoDatTiec();
            List<QLSoDatTiec> obj = SDT.getSoDatTiec_ED(masdt);
            return View(obj.FirstOrDefault());
        }

        [HttpPost]

        public ActionResult Delete(QLSoDatTiec strSDT)
        {
            ListSoDatTiec SDT = new ListSoDatTiec();
            SDT.DeleteSoDatTiec(strSDT);
            System.Threading.Thread.Sleep(500);
            return RedirectToAction("Index");
        }
    }
}