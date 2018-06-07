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
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.Models.SandwichContext _context;

        public DeleteModel(WebApplication1.Models.SandwichContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sandwich = await _context.Sandwich.FindAsync(id);

            if (Sandwich != null)
            {
                _context.Sandwich.Remove(Sandwich);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
