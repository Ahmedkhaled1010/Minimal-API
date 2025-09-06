using Microsoft.AspNetCore.Mvc;
using Minimal_API.NewFolder.Classes.Model;
using Minimal_API.NewFolder.Interfaces;

namespace Minimal_API.NewFolder.Classes
{
    public class PizzaServicesEF(IPizzaRepository pizzaRepository) : IPizzaServicesEF
    {
        public async Task AddAsync(Pizza entity)
        {
            await   pizzaRepository.AddAsync(entity);
            await pizzaRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var pizza = await pizzaRepository.GetByIdAsync(id);
                if (pizza == null)
                {
                throw new KeyNotFoundException("Pizza Not Found");
            }
            pizzaRepository.Delete(pizza);
                await pizzaRepository.SaveChangesAsync();
           
        }

        public async Task<IEnumerable<Pizza>> GetAllPizzaAsync()
        {
           return await pizzaRepository.GetAlllAsync();
        }

        public async Task<Pizza> GetPizzaByIdAsync(int id)
        {
            var pizza = await pizzaRepository.GetByIdAsync(id);
            if (pizza is  null)
            {
                throw new KeyNotFoundException("Pizza Not Found");
            }
            return pizza;
        }

        public async Task Update(Pizza pizza)
        {
            var existingPizza = await pizzaRepository.GetByIdAsync(pizza.Id);
            if (existingPizza == null)
            {
                throw new KeyNotFoundException("Pizza Not Found");
            }
            await pizzaRepository.Update(pizza);
            await pizzaRepository.SaveChangesAsync();
        }
    }
}
