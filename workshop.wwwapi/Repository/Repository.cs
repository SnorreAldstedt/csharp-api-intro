using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        public Band Delete(int id)
        {
            var target = BandDataStore.GetBandById(id);
            return BandDataStore.DeleteBandById(id) ? target : null;
        }

        public List<Band> Get()
        {
            return BandDataStore.GetBands();
        }

        public Band GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Band Update(int id, Band model)
        {
            throw new NotImplementedException();
        }
        public void Add(Band band)
        {
            BandDataStore.AddBand(band);
        }
    }
}
