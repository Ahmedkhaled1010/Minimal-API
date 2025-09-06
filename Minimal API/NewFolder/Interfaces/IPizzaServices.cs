using Minimal_API.NewFolder.Classes.Model;

namespace Minimal_API.NewFolder.Interfaces
{
    public interface IPizzaServices
    {
        List<Pizza> GetPizzas();
        Pizza? GetPizza(int id);
        Pizza CreatePizza(Pizza pizza);
        Pizza UpdatePizza(Pizza update);
        void RemovePizza(int id);
    }
}
