using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Pages.Sandwiches
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Models.SandwichContext _context;

        public IndexModel(WebApplication1.Models.SandwichContext context)
        {
            _context = context;
        }

        public IList<Sandwich> Sandwich { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var sandwiches = from s in _context.Sandwich select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                sandwiches = sandwiches.Where(str => str.Name.Contains(searchString));
            }
            Sandwich = await sandwiches.ToListAsync();
        }
    }
}
