using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Pages.Sandwiches
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.Models.SandwichContext _context;

        public DetailsModel(WebApplication1.Models.SandwichContext context)
        {
            _context = context;
        }

        public Sandwich Sandwich { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sandwich = await _context.Sandwich.SingleOrDefaultAsync(m => m.ID == id);

            if (Sandwich == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
