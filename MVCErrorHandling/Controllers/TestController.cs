using MVCErrorHandling.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCErrorHandling.Controllers
{
   
    public class TestController : Controller
    {
        // GET: Test

        public ActionResult Index()
        {

            var test = int.Parse("test");

            return View();
        }

        public ActionResult Deneme()
        {
            throw new Exception("asdasd");
        }
    }
}