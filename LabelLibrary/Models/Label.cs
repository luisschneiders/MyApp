using System;
using System.ComponentModel.DataAnnotations;

namespace LabelLibrary.Models
{
    public abstract class Label
    {
        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
