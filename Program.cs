using StudentHive.Infrastructure.Data;
using StudentHive.Services.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StudentHive.Services.MappingsM;
using CloudinaryDotNet;
using StudentHive.Service.Features.Users;
using StudentHive.Infrastructure.Repositories;
using StudentHive.Service.Features.RentalHouses;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

// User services and repositories
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserRepository>();
// RentalHouse services and repositories
builder.Services.AddScoped<RentalHouseService>();
builder.Services.AddScoped<RentalHouseRepository>();

// Add  serealization and deserealization services
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.MaxDepth = 64;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});
// Add services to the container
builder.Services.AddDbContext<StudentHiveApiDbContext>(
    options => {
    options.UseSqlServer(Configuration.GetConnectionString("gemDevelopment"));
    }
);


var cloudinarySettings = builder.Configuration.GetSection("CloudinarySettings");
Account account = new Account(
    cloudinarySettings["CloudName"],
    cloudinarySettings["ApiKey"],
    cloudinarySettings["ApiSecret"]
);

Cloudinary cloudinary = new Cloudinary(account);

builder.Services.AddSingleton(cloudinary);

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
