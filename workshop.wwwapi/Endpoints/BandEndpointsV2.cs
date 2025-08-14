using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class BandEndpointsV2
    {
        public static void ConfigureBandV2(this WebApplication app)
        {
            var bands = app.MapGroup("bands");

            bands.MapGet("/", GetBands);
            bands.MapPost("/", AddBand);
            bands.MapDelete("/{id}", Delete);
            bands.MapPut("/{id}", Update);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBands(IRepository repository)
        {
            var results = repository.Get();
            return TypedResults.Ok(results);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddBand(IRepository repository, Band band)
        {
            var results = repository.Get();

            return TypedResults.Ok(band);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> Delete(IRepository repository, int id)
        {            
            var entity = repository.Delete(id);
            return entity is not null ? TypedResults.Ok(entity) : TypedResults.NotFound();

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> Update(IRepository repository, int id, Band model)
        {            
            var entity = repository.GetById(id);           

            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.Genre = model.Genre;
            entity.MemberCount = model.MemberCount;

            return TypedResults.Ok(entity);

        }
    }
}
