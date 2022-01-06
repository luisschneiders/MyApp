using System;
using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Models
{
    public abstract class Base
    {

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public Guid InsertedBy { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

    }
}
