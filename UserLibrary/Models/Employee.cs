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

        [ValidateComplexType]
        public ContactDetails ContactDetails { get; set; }

        [ValidateComplexType]
        public Location Location { get; set; }
    }
}
