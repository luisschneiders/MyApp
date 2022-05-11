using System;
using System.ComponentModel.DataAnnotations;
using BaseLibrary.Models;

namespace LabelLibrary.Models
{
    public abstract class Label : Base
    {
        [Required]
        public string? CompanyName { get; set; }

        [Required]
        public string? Department { get; set; }

        [Required]
        public string? Location { get; set; }

    }
}
