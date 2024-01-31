using BloodBankManager.API.Controllers;
using BloodBankManager.Application.Services.Implementations;
using BloodBankManager.Application.Services.Interfaces;
using BloodBankManager.Core.Entities;
using BloodBankManager.Infrastructure.Persistence;
using BloodBankManager.Infrastructure.Persistence.Interfaces;
using BloodBankManager.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDonorService, DonorService>();
builder.Services.AddScoped<IDonationService, DonationService>();
builder.Services.AddScoped<IDonorRepository, DonorRepository>();
builder.Services.AddScoped<IDonationRepository, DonationRepository>();

var connectionString = builder.Configuration.GetConnectionString("BloodBankManager");
builder.Services.AddDbContext<BloodBankDbContext>(options => options.UseInMemoryDatabase(connectionString));

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
