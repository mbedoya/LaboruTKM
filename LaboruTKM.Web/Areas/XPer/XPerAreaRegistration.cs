using System.Web.Mvc;

namespace LaboruTKM.Web.Areas.XPer
{
    public class XPerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "XPer";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "XPer_default",
                "XPer/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
