using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaseLibrary.Models;

namespace TrackingInventoryLibrary.Models
{
	public class TrackingInventoryMop : Base
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		public DateTime ScanTime { get; set; }

        [Required]
        [Description("EntryType has value of 1(Pickup Time) and value of 2(Return Time)")]
        [Range(1, 2, ErrorMessage = "Please select Pickup time or Return time")]
        public int EntryType { get; set; }

        /*
		 * Custom error message not displaying, needs investigation.
		 */
        [Required(ErrorMessage = "The Clean mop quantity field must be a number")]
        public int CleanMopQuantity { get; set; }

        [Required(ErrorMessage = "The Dirty mop quantity field must be a number")]
        public int DirtyMopQuantity { get; set; }

		[Required]
		[ForeignKey("LabelMop")]
		public Guid LabelMopId { get; set; }
	}
}
