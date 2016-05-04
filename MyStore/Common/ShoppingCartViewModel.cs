using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyStore.Common
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<CartProduct> Products { get; set; }
        public decimal Total { get; set; }

    }
}
