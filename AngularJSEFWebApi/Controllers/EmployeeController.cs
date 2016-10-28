using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularJSEFWebApi.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employree
        public ActionResult Index()
        {
            return View();
        }
    }
}