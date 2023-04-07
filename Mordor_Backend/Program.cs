using Microsoft.EntityFrameworkCore;
using Mordor_Backend.Models;
using Mordor_Backend.Repositories;
using Mordor_Backend.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string dbConnString = builder.Configuration.GetConnectionString("Default")
    ?? throw new InvalidOperationException("The default connection string is missing.");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(dbConnString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMordorService, MordorService>();
builder.Services.AddScoped<IOrkRepository, OrkRepository>();

builder.Services.AddCors(option => option
    .AddDefaultPolicy(p => p
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithOrigins("http://127.0.0.1:5500")));

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetRequiredService<AppDbContext>())
{
    await context.Database.MigrateAsync();
}

app.Run();
