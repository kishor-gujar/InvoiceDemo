using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Product
        public ActionResult Show(int id)
        {

            return id == null ? HttpNotFound() : (ActionResult)Json(db.Products.Where(x => x.Id == id).FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }
    }
}