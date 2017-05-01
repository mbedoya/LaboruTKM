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

    }
}
