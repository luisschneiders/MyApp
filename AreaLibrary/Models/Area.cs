using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaseLibrary.Models;

namespace AreaLibrary.Models
{
	public class Area : Base
	{
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; }
    }
}
