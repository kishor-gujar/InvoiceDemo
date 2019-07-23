using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class OrdersController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Orders
        public ActionResult Index()
        {

            List<Customer> customers = db.Customers.ToList();
            IList<Order> orders = db.Orders.ToList();
            IList<Product> products = db.Products.ToList();
            ViewData["customers"] = customers;
            ViewData["products"] = products;
            return View(orders);
        }

        // GET: Doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            {
            }
            Order doctor = db.Orders.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Invoice(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Order order = db.Orders.Where(x => x.Id == id).FirstOrDefault();
            return View(order);
        }

        public async Task<ActionResult> SaveOrder(OrderViewModel order)
        {
            var newOrder = new Order
            {
                CustomerId = order.CustomerId,
                Date = DateTime.Now
            };
            db.Orders.Add(newOrder);
            await db.SaveChangesAsync();

            foreach (var p in order.Products)
            {
                OrderProduct orderProduct = new OrderProduct
                {
                    OrderId = newOrder.Id,
                    ProductId = p.ProductId,
                    Qty = p.Qty
                };
                db.OrderProducts.Add(orderProduct);
                await db.SaveChangesAsync();
            }
            return Json(new {id = newOrder.Id, Date = newOrder.Date });
//            return RedirectToAction("Create");
        }


    }

    public class OrderViewModel
    {
        public int CustomerId { get; set; }
        public ProductViewModel[] Products { get; set; } 
    }

    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public int Qty { get; set; }
    }
}