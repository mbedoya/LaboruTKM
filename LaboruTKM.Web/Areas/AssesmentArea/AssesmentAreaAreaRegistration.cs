using System.Web.Mvc;

namespace LaboruTKM.Web.Areas.AssesmentArea
{
    public class AssesmentAreaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AssesmentArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AssesmentArea_default",
                "AssesmentArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
