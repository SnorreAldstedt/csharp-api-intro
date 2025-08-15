using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;
        public Repository(DataContext db)
        {
            _db = db;
        }
        public async Task<List<Band>> GetAsync()
        {
            return await _db.Bands.ToListAsync();            
        }

        public async Task<Band> DeleteAsync(int id)
        {
            var target = await _db.Bands.FindAsync(id);
            _db.Bands.Remove(target);
            await _db.SaveChangesAsync();
            return target;

        }
       
        public async Task<Band> GetByIdAsync(int id)
        {
            return await _db.Bands.FindAsync(id);
        }

        public async Task<Band> UpdateAsync(int id, Band model)
        {
            throw new NotImplementedException();
        }
    }
}
