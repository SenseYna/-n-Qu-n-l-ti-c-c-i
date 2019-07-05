using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedding_management_project.Common;
using Wedding_management_project.Models;

namespace Wedding_management_project.Areas.Admin.Controllers
{
    public class BaoCaosController : Controller
    {
        // GET: Admin/BaoCaos
        public ActionResult Index()
        {
            ListBaoCao strBC = new ListBaoCao();
            List<QLBaoCao> obj = strBC.getBaoCao(string.Empty);
            return View(obj);

        }
    }
}