using LaboruTKM.Common;
using LaboruTKM.Web.Common;
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
        public const string LoginPage = "Login";

        //
        // GET: /CompanyUI/

        public ActionResult Index()
        {
            return CheckAndRoute();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Recruitment()
        {
            return CheckAndRoute();
        }

        public ActionResult Logout()
        {
            Session[SessionConstants.Company] = null;
            return Json(new { success = true }, JsonRequestBehavior.AllowGet );
        }

        public ActionResult SignIn(string email, string password)
        {
            CompanyDTO element = model.Login(email, password);
            Session[SessionConstants.Company] = element;

            return Json(element, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CheckAndRoute()
        {
            if (Session[SessionConstants.Company] == null)
            {
                return View(LoginPage);
            }

            return View((CompanyDTO)Session[SessionConstants.Company]);
        }

    }
}
