using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Endpoints
{
    public static class BandEndpoints
    {
        public static void ConfigureBand(this WebApplication app)
        {
            var bands = app.MapGroup("bands");

            bands.MapGet("/", GetBands);
            bands.MapPost("/", AddBand);
            
        }

        public static async Task<IResult> GetBands()
        {
            return TypedResults.Ok(BandDataStore.GetBands());
        }
        public static async Task<IResult> AddBand(Band band)
        {
            BandDataStore.AddBand(band);

            return TypedResults.Ok(band);
        }

    }
}












/*
 app.MapPost("bands", (Band band) =>
            {
                BandDataStore.AddBand(band);
                return band;
            });
*/