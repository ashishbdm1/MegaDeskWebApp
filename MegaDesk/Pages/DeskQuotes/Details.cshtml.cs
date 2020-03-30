using MegaDesk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MegaDesk.Pages.DeskQuotes
{
	public class DetailsModel : PageModel
	{
		private readonly MegaDesk.Data.MegaDeskContext _context;

		public DetailsModel( MegaDesk.Data.MegaDeskContext context )
		{
			_context = context;
		}

		public DeskQuote DeskQuote { get; set; }

		public async Task<IActionResult> OnGetAsync( int? id )
		{
			if ( id == null )
			{
				return NotFound();
			}

			DeskQuote = await _context.DeskQuotes.Include( dq => dq.Desk )
				.Include( dq => dq.Desk.SurfaceMaterial ).FirstOrDefaultAsync( m => m.DeskQuoteId == id );

			if ( DeskQuote == null )
			{
				return NotFound();
			}
			return Page();
		}
	}
}
