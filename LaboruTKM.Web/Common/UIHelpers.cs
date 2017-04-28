using LaboruTKM.Web.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.WebPages.Html;
using System.Threading;

namespace LaboruTKM.Web.Common
{
    public static class UIHelpers
    {
        public static IHtmlString GetGlobalizedText(string name)
        {
            string uiCulture = GetBrowserUICulture();
            HtmlString result = new HtmlString(AdminResource.ResourceManager.GetString(name));
            if (uiCulture != "es")
            {
                result = new HtmlString(AdminResource.ResourceManager.GetString(name, new System.Globalization.CultureInfo(uiCulture)));
            }

            return result;
        }

        public static string GetBrowserUICulture()
        {
            string[] languages = HttpContext.Current.Request.UserLanguages;
            
            if (languages != null && languages.Length > 0 && languages[0] != "es")
            {
                return "en";
            }

            return languages[0];
        }
    }
}