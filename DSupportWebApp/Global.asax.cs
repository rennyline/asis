using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DSupportWebApp.Models;

namespace DSupportWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_AcquireRequestState(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session != null)
            {
                // huidige culture en language code
                Session["systemStartLangCulture"] = CultureInfo.CurrentCulture.Name;
                Session["systemStartLangCode"] = Session["systemStartLangCulture"].ToString().Substring(0, 2).ToUpper();
                // culture en language code van asis
                Session["asisLangCulture"] = AsisModelHelper.GetAsisLanguageCulture();
                Session["asisLangCode"] = AsisModelHelper.GetAsisLanguageCode();
                //Session["IDUser"] = null; //AsisModelHelper.GetIDUser();
                Session["IDUser"] = 1; //AsisModelHelper.GetIDUser();
                Session["IDUserGroup"] = AsisModelHelper.GetIDUserGroup(Convert.ToInt32(Session["IDUser"]));
                Session["AppName"] = "DSupportWebApp"; // Wordt gebruikt om data op te halen van een datamodel
                                          //Session["IDUserGroup"] = 1;
                                          //Session["IDUser"] = 1;

            }
        }
    }
}
