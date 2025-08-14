using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public static class BandDataStore
    {
        private static List<Band> _bands = new List<Band>();


        public static void Initialize()
        {
            _bands.Add(new Band() { Id = 1, Name = "Empty Reflection", Genre = "Progressive Rock", MemberCount = 4 });
            _bands.Add(new Band() { Id = 2, Name = "Aha", Genre = "Pop", MemberCount = 3 });
            _bands.Add(new Band() { Id = 3, Name = "GnR", Genre = " Rock", MemberCount = 4 });
            _bands.Add(new Band() { Id = 4, Name = "Tinlicker", Genre = "Trance", MemberCount = 2 });
        }
        public static List<Band> GetBands()
        {
            return _bands;
        }
        public static void AddBand(Band band)
        {
            _bands.Add(band);
        }
        public static bool DeleteBandById(int id)
        {
            return _bands.RemoveAll(x => x.Id == id) > 0 ? true : false;
        }
        public static Band GetBandById(int id)
        {
            var entity = _bands.FirstOrDefault(b => b.Id == id);
            return entity;
        }
    }
}
