using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace WebApplication1.Attributes
{
    public class LocalizationAttribute : ActionFilterAttribute
    {
        private string _DefaultLanguage = "en";

        public LocalizationAttribute(string defaultLanguage)
        {
            _DefaultLanguage = defaultLanguage;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string lang = (string)filterContext.RouteData.Values["lang"] ?? _DefaultLanguage;
            if (lang != _DefaultLanguage)
            {
                try
                {
                    Thread.CurrentThread.CurrentCulture =
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
                }
                catch (Exception)
                {
                    throw new NotSupportedException(string.Format("ERROR: Invalid language code '{0}'.", lang));
                }
            }
        }
    }
}