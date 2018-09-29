using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAuditInterception.Models;

namespace WebAuditInterception.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //DbInterception.Add(new AuditInterceptor("People"));
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}