using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;

namespace WebApplication1.Pages.Sandwiches
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication1.Models.SandwichContext _context;

        public CreateModel(WebApplication1.Models.SandwichContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Sandwich Sandwich { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sandwich.Add(Sandwich);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}