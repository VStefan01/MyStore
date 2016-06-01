using MyStore.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyStore.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private StoreDatabaseContext _db = new StoreDatabaseContext();

        // GET: Categories
        public async Task<ActionResult> Index()
        {
            return View(await _db.Categories.ToListAsync());
        }

        public async Task<ActionResult> Browse(string id)
        {
            var category = _db.Categories;
            var products = await _db.Products.Include("Category").Where(p => p.Category.Name == id).ToListAsync();

            if (!products.Any())
            {
                return HttpNotFound();
            }

            return View(products);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            var product = await _db.Products.Include("Category").Where(p => p.Id == id).SingleOrDefaultAsync();

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);


        }
    }
}



