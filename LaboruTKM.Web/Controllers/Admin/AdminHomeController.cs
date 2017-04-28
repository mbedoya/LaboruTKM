using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaboruTKM.Web.Controllers.Admin
{
    public class AdminHomeController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Evaluations()
        {
            return View();
        }

        public ActionResult Companies()
        {
            return View();
        }
    }
}
