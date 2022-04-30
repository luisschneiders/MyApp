using System;
using System.ComponentModel.DataAnnotations;

namespace LabelLibrary.Models
{
    public class LabelMop : Label
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Barcode { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime TimeIn { get; set; }

        [Required]
        public DateTime TimeOut { get; set; }
    }
}
