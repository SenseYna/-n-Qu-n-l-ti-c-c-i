using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedding_management_project.Models;

namespace Wedding_management_project.Areas.User.Controllers
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
     
    }
}