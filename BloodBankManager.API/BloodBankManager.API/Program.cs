using BloodBankManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using BloodBankManager.Application.DependencyInjection;
using BloodBankManager.Infrastructure.DependencyInjection;
using BloodBankManager.Core.Services.Interfaces;
using BloodBankManager.Core.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServiceDependencyInjection();
builder.Services.AddRepositoryDependencyInjection();
builder.Services.AddScoped<IDonationService, DonationService>();

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
