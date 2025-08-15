using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

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
        public static async Task<IResult> GetBands(IRepository repository)
        {
            var results = await repository.GetAsync();
            return TypedResults.Ok(results);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddBand(IRepository repository, Band model)
        {
            var results = await repository.AddAsync(model);

            return TypedResults.Ok(model);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> Delete(IRepository repository, int id)
        {            
            var entity = await repository.DeleteAsync(id);
            return entity is not null ? TypedResults.Ok(entity) : TypedResults.NotFound();

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> Update(IRepository repository, int id, Band model)
        {            
            var entity = repository.GetByIdAsync(id);           



            return TypedResults.Ok(entity);

        }
    }
}
