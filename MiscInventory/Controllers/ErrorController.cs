using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiscInventory.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/



        //400
        public ViewResult BadRequest()
        {
            return View("BadRequest");
        }
        //401
        public ViewResult Unauthorized()
        {
            return View("Unauthorized");
        }
        //403
        public ViewResult Forbidden()
        {
            return View("Forbidden");
        }
        //404
        public ActionResult NotFound()
        {
            return View();
        }
        //408
        public ViewResult RequestTimeout()
        {
            return View("RequestTimeout");
        }
        //500
        public ViewResult Internal()
        {
            return View("RequestTimeout");
        }
        //501
        public ViewResult NotImplemented()
        {
            return View("NotImplemented");
        }
        //502
        public ViewResult BadGateway()
        {
            return View("BadGateway");
        }
        //503
        public ViewResult ServiceUnavailable()
        {
            return View("ServiceUnavailable");
        }
        //504
        public ViewResult GatewayTimeout()
        {
            return View("GatewayTimeout");
        }
        //505
        public ViewResult HTTPVersionNotSupported()
        {
            return View("HTTPVersionNotSupported");
        }
    }
}
