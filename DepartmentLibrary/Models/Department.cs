using System;
using System.ComponentModel.DataAnnotations;
using BaseLibrary.Models;

namespace DepartmentLibrary.Models
{
    public class Department : Base
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}
