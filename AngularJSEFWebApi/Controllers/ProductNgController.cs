using AngularJSEFWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularJSEFWebApi.Controllers
{
    public class ProductNgController : Controller
    {
        // GET: ProductNg
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<Product> products = new List<Product>();
            products = db.Products.ToList();

            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}