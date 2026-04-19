using AutoMapper;
using JabilMoviesAPI.Mapping;
using JabilMoviesAPI.Models.Data;
using JabilMoviesAPI.Models.DTOs;
using JabilMoviesAPI.Services;
using JabilMoviesAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Inyeccción de dependencias
builder.Services.AddScoped<IService<MoviesDTO, MoviesInsertDTO, MoviesUpdateDTO>, MoviesServices>();
builder.Services.AddScoped<IService<DirectorDTO, DirectorInsertDTO, DirectorUpdateDTO>, DirectorsServices>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//Conexión base de Datos
builder.Services.AddDbContext<JabilMoviesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection")));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var origenesPermitidos = builder.Configuration.GetValue<string>("OrigenesPermitidos").Split(",");

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(origenesPermitidos).AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
