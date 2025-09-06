using Microsoft.EntityFrameworkCore;
using Minimal_API.NewFolder.Classes.Model;

namespace Minimal_API.NewFolder.Context
{
    public class PizzaContext:DbContext
    {
        
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options)
        {

        }
        public DbSet<Pizza> Pizzas { get; set; }

    }
}
    