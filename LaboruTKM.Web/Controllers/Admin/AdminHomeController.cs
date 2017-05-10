using LaboruTKM.Common;
using LaboruTKM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaboruTKM.Web.Controllers.Admin
{
    public class AdminHomeController : Controller
    {
        Evaluation evalModel = new Evaluation();
        Section sectionModel = new Section();

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

        public ActionResult Evaluation(int id)
        {
            EvaluationDTO eval = evalModel.Get(id);

            return View(eval);
        }

        public ActionResult Section(int id)
        {
            SectionDTO section = sectionModel.Get(id);

            return View(section);
        }

        public ActionResult Companies()
        {
            return View();
        }
    }
}
