using System;
using System.ComponentModel.DataAnnotations;
using BaseLibrary.Models;
using ContactDetailsLibrary.Models;
using LocationLibrary.Models;

namespace SupplierLibrary.Models
{
    public class Supplier : Base
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string SupplierName { get; set; }

        [Required]
        public string SupplierABN { get; set; }

        [ValidateComplexType]
        public ContactDetails ContactDetails { get; set; }

        [ValidateComplexType]
        public Location Location { get; set; }
    }
}
