//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using MyStore.Data;
//using MyStore.Models;

//namespace MyStore.Controllers
//{
//    public class ProductsController : Controller
//    {
//        private StoreDatabaseContext _db = new StoreDatabaseContext();

//        // GET: Products
//        public async Task<ActionResult> Products()
//        {
//            return View(await _db.Products.ToListAsync());
//        }






//        // GET: Products/Details/5
//        public async Task<ActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Product product = await _db.Products.FindAsync(id);
//            if (product == null)
//            {
//                return HttpNotFound();
//            }
//            return View(product);
//        }



//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                _db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
