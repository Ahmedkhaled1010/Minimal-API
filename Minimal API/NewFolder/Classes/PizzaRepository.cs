using Microsoft.EntityFrameworkCore;
using Minimal_API.NewFolder.Classes.Model;
using Minimal_API.NewFolder.Context;
using Minimal_API.NewFolder.Interfaces;

namespace Minimal_API.NewFolder.Classes
{
    public class PizzaRepository(PizzaContext context) : IPizzaRepository
    {
        public async Task AddAsync(Pizza entity)
        {
          await context.Pizzas.AddAsync(entity);
        }

        public void Delete(Pizza entity)
        {
           context.Pizzas.Remove(entity);
            
        }

        public async Task<IEnumerable<Pizza>> GetAlllAsync()
        {
             return await context.Pizzas.ToListAsync();
        }

        public async Task<Pizza?> GetByIdAsync(int id)
        {
           return await context.Pizzas.FindAsync(id);
        }

        public async Task Update(Pizza entity)
        {
            var pizza =await context.Pizzas.FirstOrDefaultAsync(p => p.Id == entity.Id);
            if (pizza is not null)
            {
                pizza.Name = entity.Name;
            }

        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
