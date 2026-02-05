using Minimal_API.NewFolder.Classes.Model;

namespace Minimal_API.NewFolder.Interfaces
{
    public interface IPizzaServicesEF
    {
        Task<IEnumerable<Pizza>> GetAllPizzaAsync();
        Task<Pizza> GetPizzaByIdAsync(int id);

        Task AddAsync(Pizza entity);

        Task Update( Pizza entity);
        Task Delete(int id);
    }
}
