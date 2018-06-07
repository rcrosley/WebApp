using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class SandwichContext : DbContext
    {
        public SandwichContext(DbContextOptions<SandwichContext> options) : base(options)
        {
        }
        public DbSet<Sandwich> Sandwich { get; set; }
    }
}
