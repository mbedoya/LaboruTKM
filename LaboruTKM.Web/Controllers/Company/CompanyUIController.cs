using LaboruTKM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaboruTKM.Web.Controllers.Company
{
    public class CompanyUIController : Controller
    {
        LaboruTKM.Model.Company model = new LaboruTKM.Model.Company();

        //
        // GET: /CompanyUI/

        public ActionResult Index()
        {
            if (Session["company"] == null)
            {
                return View("Login");
            }

            return View((CompanyDTO)Session["company"]);
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SignIn(string email, string password)
        {
            CompanyDTO element = model.Login(email, password);

            Session["company"] = element;

            return Json(element, JsonRequestBehavior.AllowGet);
        }

    }
}
