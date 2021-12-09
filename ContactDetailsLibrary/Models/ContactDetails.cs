using System;
using System.ComponentModel.DataAnnotations;

namespace ContactDetailsLibrary.Models
{
    public class ContactDetails
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

#nullable enable
        [Required]
        public string? Phone { get; set; }

        [Required]
        public string? Mobile { get; set; }

    }
}
