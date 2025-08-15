using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<List<Band>> GetAsync();
        Task<Band> GetByIdAsync(int id);
        Task<Band> DeleteAsync(int id);
        Task<Band> UpdateAsync(int id, Band model);
    }
}
