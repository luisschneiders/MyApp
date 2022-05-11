using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LabelLibrary.Models
{
    public class LabelMop : Label
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Barcode { get; set; }

        [Required]
        [Range(1, 30, ErrorMessage = "Quantity must be between 1 and 30")]
        public int Quantity { get; set; }

        [Required]
        public DateTime TimeIn { get; set; }

        [Required]
        public DateTime TimeOut { get; set; }
    }
}
