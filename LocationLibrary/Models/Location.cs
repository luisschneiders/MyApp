using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocationLibrary.Models
{
    public class Location
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "float(10,6)")]
        public float Lat { get; set; }

        [Required]
        [Column(TypeName = "float(10,6)")]
        public float Lng { get; set; }

        [Required]
        public string Suburb { get; set; }

        [Required]
        public string Postcode { get; set; }

        [Required]
        public string State { get; set; }

        public Guid CustomerId { get; set; }
        public Guid SupplierId { get; set; }
    }
}
