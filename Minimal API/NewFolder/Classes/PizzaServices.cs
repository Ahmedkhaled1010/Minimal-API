using Minimal_API.NewFolder.Classes.Model;
using Minimal_API.NewFolder.Interfaces;

namespace Minimal_API.NewFolder.Classes
{
    public class PizzaServices:IPizzaServices
    {
        private PizzaDb _pizzaDb = new PizzaDb();
     
        public Pizza? GetPizza(int id)
        {
            return _pizzaDb.pizzas.FirstOrDefault(p => p.Id == id);
        }



        public List<Pizza> GetPizzas()
        {
            return _pizzaDb.pizzas;

        }
        public Pizza CreatePizza(Pizza pizza)
        {
            _pizzaDb.pizzas.Add(pizza);
            return pizza;
        }

        public void RemovePizza(int id)
        {
            _pizzaDb.pizzas = _pizzaDb.pizzas.FindAll(p => p.Id != id).ToList();
        }

        public Pizza UpdatePizza(Pizza update)
        {
            _pizzaDb.pizzas = _pizzaDb.pizzas.Select(p =>
            {
                if (p.Id == update.Id)
                {
                    p.Name = update.Name;
                }
                return p;
            }).ToList();
            return update;
        }

    }
}
