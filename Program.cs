using StudentHive.Infrastructure.Data;
using StudentHive.Services.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StudentHive.Services.MappingsM;
using StudentHive.Services.Features.Users;
using StudentHive.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserRepository>();

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

var app = builder.Build();

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
