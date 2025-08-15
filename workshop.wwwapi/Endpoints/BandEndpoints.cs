using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTOs;
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
            bands.MapGet("/{id}", GetBandById);
            bands.MapPost("/", AddBand);
            bands.MapDelete("/{id}", Delete);
            bands.MapPut("/{id}", Update);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetBandById(IRepository repository, int id)
        {
            var item = await repository.GetByIdAsync(id);
            if (item == null) return TypedResults.NotFound(new { Error="No Band Found!"});
            return TypedResults.Ok(item);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBands(IRepository repository)
        {
            var results = await repository.GetAsync();
            return TypedResults.Ok(results);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddBand(IRepository repository, BandPost model)
        {
            Band entity = new Band();
            entity.Name = model.Name;
            entity.Genre = model.Genre;
            entity.MemberCount = model.MemberCount;
            var results = await repository.AddAsync(entity);

            return TypedResults.Created($"https://localhost:7239/bands/{entity.Id}",new { BandName=model.Name, BandGenre=model.Genre, DateCreate=DateTime.Now, BandMemberCount=model.MemberCount });
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
        public static async Task<IResult> Update(IRepository repository, int id, BandPut model)
        {            
            var entity = await repository.GetByIdAsync(id);

            if (model.Name != null) entity.Name = model.Name;
            if (model.MemberCount != null) entity.MemberCount = model.MemberCount.Value;
            if (model.Genre != null) entity.Genre = model.Genre;


            



            return TypedResults.Ok(entity);

        }
    }
}
