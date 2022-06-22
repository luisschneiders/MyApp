using System;
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
		public DateTime PickupTime { get; set; }

		[Required]
		public DateTime ReturnTime { get; set; }

		[Required]
		[Range(0, 30, ErrorMessage = "Quantity must be between 0 and 30")]
		public int CleanMopQuantity { get; set; }

		[Required]
		[Range(0, 30, ErrorMessage = "Quantity must be between 0 and 30")]
		public int DirtyMopQuantity { get; set; }

		[Required]
		[ForeignKey("LabelMop")]
		public Guid LabelMopId { get; set; }
	}
}
