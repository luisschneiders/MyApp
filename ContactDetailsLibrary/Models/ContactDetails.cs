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
        public string? Phone { get; set; }

        public string? Mobile { get; set; }

    }
}
