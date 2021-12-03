using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocationLibrary.Models
{
    public class Location
    {
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
    }
}
