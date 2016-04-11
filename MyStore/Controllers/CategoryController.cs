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
    }
}