using System.ComponentModel;
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
        [Range(1, 30, ErrorMessage = "Quantity must be between 1 and 30")]
        public int Quantity { get; set; }

        [Required]
        public DateTime TimeIn { get; set; }

        [Required]
        public DateTime TimeOut { get; set; }

        [Required]
        [Description("ShiftType has value of 1(Pickup Time) and value of 2(Return Time)")]
        [Range(1, 3, ErrorMessage = "Please select Morning, Afternoon or Night shift")]
        public int ShiftType { get; set; }
    }
}
