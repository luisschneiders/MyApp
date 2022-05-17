using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaseLibrary.Models;

namespace LabelLibrary.Models
{
    public abstract class Label : Base
    {
        [Required]
        public string? CompanyName { get; set; }

        [Required]
        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; }

        [Required]
        public string? Location { get; set; }

    }
}
