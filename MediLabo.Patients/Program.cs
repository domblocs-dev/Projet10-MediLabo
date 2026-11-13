using MediLabo.Patients.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("PatientsDb")
    ?? throw new InvalidOperationException("Chaîne de connexion 'PatientsDb' introuvable.");

builder.Services.AddDbContext<PatientsDbContext>(options =>
    options.UseSqlServer(connectionString)
        .UseSeeding(PatientsSeed.Seed)
        .UseAsyncSeeding(PatientsSeed.SeedAsync));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
