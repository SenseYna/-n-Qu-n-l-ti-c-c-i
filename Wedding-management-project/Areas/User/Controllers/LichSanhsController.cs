using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedding_management_project.Models;

namespace Wedding_management_project.Areas.User.Controllers
{
    public class LichSanhsController : Controller
    {
        // GET: Admin/SoDatTiecs
        public ActionResult Index()
        {
            ListTinhTrangSanh strTTS = new ListTinhTrangSanh();
            dynamic mymodel = new ExpandoObject();
            mymodel.TTS = strTTS.getTinhTrangSanh(string.Empty);
            DateTime i = DateTime.Now;
            mymodel.day = i.ToString("dd");
            mymodel.month = i.ToString("MM");
            mymodel.year = i.ToString("yyyy");
            mymodel.index = "";

            return View(mymodel);
        }



        [HttpPost]

        public ActionResult Index_custom(dynamic Mymodel)
        {
            if (ModelState.IsValid)
            {

                ListTinhTrangSanh strTTS = new ListTinhTrangSanh();
                dynamic mymodel = new ExpandoObject();
                mymodel.TTS = strTTS.getTinhTrangSanh(string.Empty);
                DateTime i = DateTime.Now;
                mymodel.day = i.ToString("dd");
                if (Mymodel.index.ToString().Length == 1)
                    Mymodel.index = "0" + Mymodel.index;
                mymodel.month = Mymodel.index;
                mymodel.year = i.ToString("yyyy");
                mymodel.index = Mymodel.index;
                return View(mymodel);
            }
            return View(Mymodel);
        }

    }
}