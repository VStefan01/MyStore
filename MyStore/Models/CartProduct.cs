using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class CartProduct
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public DateTime DateCreated { get; set; }
        public string CartId { get; set; }
    }
}




