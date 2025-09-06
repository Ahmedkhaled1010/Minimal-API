using Minimal_API.NewFolder.Classes.Model;

namespace Minimal_API.NewFolder.Interfaces
{
    public interface IPizzaRepository
    {
        Task<IEnumerable<Pizza>> GetAlllAsync();
        Task<Pizza?> GetByIdAsync(int id);
        Task AddAsync(Pizza entity);

        void Update(Pizza entity);
        void Delete(Pizza entity);
    }
}
