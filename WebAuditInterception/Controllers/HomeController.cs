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
        private AuditInterceptor _auditInterceptor;

        public AuditInterceptor AuditInterceptor
        {
            get
            {
                if (Session["auditInterceptor"] != null)
                { 
                    _auditInterceptor = (AuditInterceptor) Session["auditInterceptor"];
                }
                else
                { 
                    _auditInterceptor = new AuditInterceptor();
                    Session["auditInterceptor"] = _auditInterceptor;
                }
                
                return _auditInterceptor;
            }
        }

        public ActionResult Index()
        {
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

        public ActionResult AtivarDBInterceptor()
        {
            DbInterception.Add(AuditInterceptor);
            return RedirectToAction("Index");
        }

        public ActionResult DesativarDBInterceptor()
        {
            DbInterception.Remove(AuditInterceptor);
            return RedirectToAction("Index");
        }   
    }
}