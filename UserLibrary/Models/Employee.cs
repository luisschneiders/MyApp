using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ContactDetailsLibrary;
using LocationLibrary;

namespace EmployeeLibrary.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string EmployeeFirstName { get; set; }

        [Required]
        public string EmployeeLastName { get; set; }

        [Required]
        public string EmployeeUsername { get; set; }

        [Required]
        public string EmployeePassword { get; set; }

        [Required]
        public ICollection<ContactDetails> ContactDetails { get; set; }

        [Required]
        public ICollection<Location> Location { get; set; }
    }
}
