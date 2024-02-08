using StudentHive.Infrastructure.Data;
using StudentHive.Services.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StudentHive.Services.MappingsM;
using StudentHive.Services.Features.Users;
using StudentHive.Infrastructure.Repository;
using StudentHive.Services.Features.RentalH;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

// User services and repositories
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserRepository>();
// RentalHouse services and repositories
builder.Services.AddScoped<RentalHouseService>();
builder.Services.AddScoped<RentalHouseRepository>();

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddDbContext<StudentHiveApiDbContext>(
    options => {
    options.UseSqlServer(Configuration.GetConnectionString("gemDevelopment"));
    }
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(ResponseMappingProfile).Assembly);
builder.Services.AddAutoMapper(typeof(RequestCreateMappingProfile).Assembly);
builder.Services.AddAutoMapper(typeof(UpdateMappingProfile).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
