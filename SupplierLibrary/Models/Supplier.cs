using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ContactDetailsLibrary;
using LocationLibrary;

namespace SupplierLibrary.Models
{
    public class Supplier
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string SupplierName { get; set; }

        [Required]
        public string SupplierABN { get; set; }

        [Required]
        public ContactDetails ContactDetails { get; set; }

        [Required]
        public Location Location { get; set; }
    }
}
