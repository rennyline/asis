using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DSupportWebApp.Models;

namespace DSupportWebApp.Controllers
{
    public class AsisErrorController : Controller
    {

        private static dsupportwebappEntities db = new dsupportwebappEntities();

        // GET: AsisError
        public ActionResult Index(int IDMessage, string prefix)
        {
            ViewBag.Name = AsisModelHelper.GetMessage(IDMessage, prefix, Session["asisLangCode"] as string);

            return View("AsisError");
        }
    }
}