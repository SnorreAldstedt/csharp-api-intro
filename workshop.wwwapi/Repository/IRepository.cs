using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        List<Band> Get();
        Band GetById(int id);
        Band Delete(int id);
        Band Update(int id, Band model);
    }
}
