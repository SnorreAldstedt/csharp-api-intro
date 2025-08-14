using Microsoft.AspNetCore.Mvc;
using System.Reflection;
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
            bands.MapDelete("/{id}", Delete);
            bands.MapPut("/{id}", Update);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBands()
        {
            return TypedResults.Ok(BandDataStore.GetBands());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddBand(Band band)
        {
            BandDataStore.AddBand(band);

            return TypedResults.Ok(band);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> Delete(int id)
        {
            var bands = BandDataStore.GetBands();
            var target = bands.FirstOrDefault(b => b.Id== id);
                       
            return BandDataStore.DeleteBandById(id) ? TypedResults.Ok(target) : TypedResults.NotFound();

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> Update(int id, Band model)
        {
            var bands = BandDataStore.GetBands();

            var entity = bands.FirstOrDefault(b => b.Id == id);

            if (entity is null)
            {
                return TypedResults.NotFound();
            }

            //entity.Id = model.Id;
            entity.Name = model.Name;
            entity.Genre = model.Genre;
            entity.MemberCount = model.MemberCount;

            return TypedResults.Ok(entity);

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