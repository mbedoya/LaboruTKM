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
        public const string DemoKey = "Demo";
        public const string DemoCompany = "intrepidez";
        public const string CookieName = "email";

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

        public ActionResult Candidate()
        {
            return CheckAndRoute();
        }

        public ActionResult Person()
        {
            return CheckAndRoute();
        }

        public ActionResult RecruitmentDone()
        {
            return CheckAndRoute();
        }

        public ActionResult Logout()
        {
            Session[SessionConstants.Company] = null;
            Session[SessionConstants.Demo] = null;
            return Json(new { success = true }, JsonRequestBehavior.AllowGet );
        }

        public ActionResult SignIn(string email, string password, bool rememberMe)
        {
            CompanyDTO element = model.Login(email, password);
            Session[SessionConstants.Company] = element;
            if (rememberMe)
            {
                AddRememberMeCookie(email);
            }

            return Json(element, JsonRequestBehavior.AllowGet);
        }

        private void AddRememberMeCookie(string email)
        {
            HttpCookie cookie = new HttpCookie(CookieName, email);
            cookie.Expires = DateTime.Now.AddMonths(6);

            Response.Cookies.Add(cookie);
        }

        public ActionResult CheckAndRoute()
        {
            if (Request.RawUrl.ToLower().Contains(DemoKey.ToLower()))
            {
                SignIn(DemoCompany, "", false);
                Session[SessionConstants.Demo] = true;
            }

            if (Session[SessionConstants.Company] == null)
            {
                return View(LoginPage);
            }

            return View((CompanyDTO)Session[SessionConstants.Company]);
        }

    }
}
