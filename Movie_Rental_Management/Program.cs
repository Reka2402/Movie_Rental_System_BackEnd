using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Movie_Rental_Management.Database;
using Movie_Rental_Management.IRepository;
using Movie_Rental_Management.IService;
using Movie_Rental_Management.Repository;
using Movie_Rental_Management.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));
builder.Services.AddScoped<IUserservice, UserService>();
builder.Services.AddScoped<IUserRepository , UserRepository>();
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
