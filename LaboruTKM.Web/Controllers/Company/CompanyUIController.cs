using LaboruTKM.Common;
using LaboruTKM.Web.Common;
using MvcSiteMapProvider;
using Newtonsoft.Json;
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
        LaboruTKM.Model.Person personModel = new Model.Person();
        LaboruTKM.Model.RecruitmentModel.RecruitmentProcess processModel = new Model.RecruitmentModel.RecruitmentProcess();

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

        public ActionResult Employees()
        {
            return CheckAndRoute();
        }

        [MvcSiteMapNode(Title = "Candidate", ParentKey = "ActiveApplicants", Key = "Candidate", PreservedRouteParameters = "id")]
        public ActionResult Candidate(int id)
        {
            return CheckAndRoute();
        }

        public ActionResult Person(int id)
        {
            ViewBag.Person = personModel.Get(id);

            return CheckAndRoute();
        }

        public ActionResult RecruitmentDone()
        {
            return CheckAndRoute();
        }

        public ActionResult XPers()
        {
            return CheckAndRoute();
        }

        #region Job Openings

        public ActionResult AddApplicant()
        {
            return CheckAndRoute();
        }

        public ActionResult AddApplicantToJobOpening(int personId, int jobOpeningId, string email, string name, string comments)
        {
            if (Session[SessionConstants.Company] == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            JobOfferDTO jobOpening = new JobOfferDTO();
            jobOpening.JobOfferId = jobOpeningId;

            PersonDTO person = new PersonDTO();
            person.PersonId = personId;
            person.Name = name;
            person.Email = email;

            RecruitmentProcessDTO process = new RecruitmentProcessDTO();
            ApplicantDTO applicant = new ApplicantDTO();
            applicant.JobOffer = jobOpening;
            applicant.Person = person;

            process.Applicant = applicant;

            RecruitmentProcessDTO result = processModel.Start(process, comments);
            if (result.State == RecruitmentProcessState.Started)
            {
                UpdateCompany();
            }

            return Json(new { state = result.State }, JsonRequestBehavior.AllowGet);
        }

        public void UpdateCompany()
        {
            Session[SessionConstants.Company] = model.Get(GetSessionCompany().CompanyId);
        }

        public ActionResult GetJobOpeningApplicants(int jobOpeningId)
        {
            if (Session[SessionConstants.Company] == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            return Json(processModel.GetProcessesByCompanyAndOpening(GetSessionCompany().CompanyId, jobOpeningId), JsonRequestBehavior.AllowGet);
        }

        [MvcSiteMapNode(Title = "Job Opening", ParentKey = "JobOpenings", Key = "JobOpening", PreservedRouteParameters = "id")]
        public ActionResult JobOpening(int id)
        {
            if (Session[SessionConstants.Company] == null)
            {
                return View(LoginPage);
            }

            ViewBag.JobOpening = model.GetJobOpening(id, GetSessionCompany().CompanyId);

            return View(GetSessionCompany());
        }

        public ActionResult JobOpenings()
        {
            return CheckAndRoute();
        }

        public ActionResult GetJobOpenings()
        {
            if (Session[SessionConstants.Company] == null)
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }

                List<JobOfferDTO> list = model.GetJobOpenings(GetSessionCompany().CompanyId);

                return Json(new { list }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetEmployees()
        {
            if (Session[SessionConstants.Company] == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            var result = model.GetEmployees(GetSessionCompany().CompanyId);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [MvcSiteMapNode(Title = "Employee", ParentKey = "Employees", Key = "Employee", PreservedRouteParameters = "id")]
        public ActionResult Employee(int id)
        {
            if (Session[SessionConstants.Company] == null)
            {
                return View(LoginPage);
            }

            ViewBag.Employee = model.GetEmployee(id, GetSessionCompany().CompanyId);

            return View(GetSessionCompany());
        }

        private string SerializeObject(object value)
        {
            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore, Formatting = Formatting.None };
            var result = JsonConvert.SerializeObject(value, jss);

            return result;
        }

        public ActionResult GetActiveRecruitments()
        {
            if (Session[SessionConstants.Company] == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            return Json(processModel.GetProcessesByCompany(GetSessionCompany().CompanyId), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Login

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
            if (element != null && rememberMe)
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

        #endregion

        #region General

        private CompanyDTO GetSessionCompany()
        {
            return (CompanyDTO)Session[SessionConstants.Company];
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

            return View(GetSessionCompany());
        }

        #endregion
    }
}
