using HaritaUygulamasi;
using HaritaUygulamasi.Data;
using HaritaUygulamasi.Interfaces;
using HaritaUygulamasi.Repository;
using HaritaUygulamasi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//kullandýðýmýz eski servis:
//builder.Services.AddScoped<ICoordinateService, CoordinateService>();
//builder.Services.AddScoped<IPostgreService, PostgreService>();
//builder.Services.AddScoped<IRepository<Coordinate>, Repository<Coordinate>>();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql("server=localHost; port=5432; Database=dbCoordinates; user Id=postgres; password=33992562"));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEntityService<Coordinate>, EntityService<Coordinate>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
