using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SandwichContext(
                serviceProvider.GetRequiredService<DbContextOptions<SandwichContext>>()))
            {
                if (context.Sandwich.Any())
                {
                    return;
                }
                context.Sandwich.AddRange(
                    new Sandwich
                    {
                        Name = "BLT",
                        Birthday = DateTime.Parse("1996-11-8"),
                        Price = 5.00M
                    },
                    new Sandwich
                    {
                        Name = "Club",
                        Birthday = DateTime.Parse("1492-2-2"),
                        Price = 22.22M
                    }
                    );
                context.SaveChanges();
            }
        }
        
    }
}
