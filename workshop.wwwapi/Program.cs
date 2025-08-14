using Microsoft.AspNetCore.Mvc;
using Scalar.AspNetCore;
using System.Reflection.Metadata.Ecma335;
using workshop.wwwapi;
using workshop.wwwapi.Data;
using workshop.wwwapi.Endpoints;
using workshop.wwwapi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Demo API");
    });
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

BandDataStore.Initialize();

//app.ConfigureNigelify();

//app.ConfigureBand();

app.Run();

