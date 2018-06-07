using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Pages.Sandwiches
{
    public class EditModel : PageModel
    {
        private readonly WebApplication1.Models.SandwichContext _context;

        public EditModel(WebApplication1.Models.SandwichContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Sandwich).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SandwichExists(Sandwich.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SandwichExists(int id)
        {
            return _context.Sandwich.Any(e => e.ID == id);
        }
    }
}
