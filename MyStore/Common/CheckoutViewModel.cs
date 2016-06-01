using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Common
{
    public class CheckoutViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(80)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(80)]
        public string LastName { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 5)]
        public string Address { get; set; }

        [Required]
        [StringLength(80)]
        public string City { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        [StringLength(12, MinimumLength = 5)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(80)]
        public string Country { get; set; }

        [Required]
        [StringLength(24)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public decimal Total { get; set; }
    }
}
