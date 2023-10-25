using StudentHive.Infrastructure.Data;
using StudentHive.Infrastructure.Repositories;
using StudentHive.Services.Features.Reservas;
using StudentHive.Services.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StudentHive.Services.MappingsM;
using StudentHive.Services.Features.Publicaciones;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddScoped<ReservacionesService>();
builder.Services.AddTransient<ReservaRepository>();

builder.Services.AddScoped<PublicacionesService>();
builder.Services.AddTransient<PublicacionesRepository>();

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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
