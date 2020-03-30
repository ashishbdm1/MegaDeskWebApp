using System.ComponentModel.DataAnnotations;

namespace MegaDesk.Models
{
	public class Desk
	{
		public int DeskId { get; set; }

		[Required]
		public int Depth { get; set; }

		[Required]
		public int Width { get; set; }

		[Display( Name = "Drawers" )]
		public int NumberOfDrawers { get; set; }

		[Display( Name = "Surface Material" )]
		public SurfaceMaterial SurfaceMaterial { get; set; }
	}
}
