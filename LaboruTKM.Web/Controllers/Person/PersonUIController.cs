using LaboruTKM.Common;
using LaboruTKM.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaboruTKM.Web.Controllers.Person
{
    public class PersonUIController : Controller
    {
        LaboruTKM.Model.Person model = new Model.Person();

        //
        // GET: /PersonUI/

        public ActionResult GetPeople()
        {
            var people = model.GetAll();

            return Json(people, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetVisibleToCompany()
        {
            if (Session[SessionConstants.Company] == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            var people = model.GetVisibleToCompany(GetSessionCompany().CompanyId);

            return Json(people, JsonRequestBehavior.AllowGet);
        }

        private CompanyDTO GetSessionCompany()
        {
            return (CompanyDTO)Session[SessionConstants.Company];
        }
    }
}
