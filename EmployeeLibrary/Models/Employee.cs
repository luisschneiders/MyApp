using System;
using System.ComponentModel.DataAnnotations;
using BaseLibrary.Models;
using ContactDetailsLibrary.Models;
using LocationLibrary.Models;

namespace EmployeeLibrary.Models
{
    public class Employee : Base
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
        public ContactDetails ContactDetails { get; set; } = new();

        [ValidateComplexType]
        public Location Location { get; set; } = new();

        // Shadow properties
        public Guid ContactDetailsId { get; set; }
        public Guid LocationId { get; set; }
    }
}
