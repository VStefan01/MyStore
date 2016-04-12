using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public class StoreService
    {
        private StoreDatabaseContext _db;

        public Array GetCategories()
        {
            return _db.Categories.OrderBy(c => c.Name).ToArray();
        }



    }
}
