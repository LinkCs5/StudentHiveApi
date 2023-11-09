using StudentHive.Infrastructure.Data;
using StudentHive.Infrastructure.Repositories;
using StudentHive.Services.Features.Publicaciones;
using StudentHive.Services.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StudentHive.Services.MappingsM;
using StudentHive.Domain.Entities;
using StudentHive.Services.Features.Reservaciones;
using StudentHive.Services.Features.Matchs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<PublicacionesService>();
builder.Services.AddTransient<PublicacionesRepository>();

builder.Services.AddScoped<ReservacionesService>();
builder.Services.AddTransient<ReservacionesRepository>();

builder.Services.AddScoped<MatchService>();
builder.Services.AddTransient<MatchRepository>();


var Configuration = builder.Configuration;

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddDbContext<StudentHiveDbContext>(
    options => {
    options.UseSqlServer(Configuration.GetConnectionString("gemDevelopment"));
    }
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(ResponseMappingProfile).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
