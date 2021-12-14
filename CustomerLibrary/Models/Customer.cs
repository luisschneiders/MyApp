using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ContactDetailsLibrary.Models;
using LocationLibrary.Models;

namespace CustomerLibrary.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string CustomerFirstName { get; set; }

        [Required]
        public string CustomerLastName { get; set; }

        [Required]
        public DateTime CustomerDOB { get; set; }

        [Required]
        public ICollection<ContactDetails> ContactDetails { get; set; }

        [Required]
        public ICollection<Location> Location { get; set; }

    }
}
