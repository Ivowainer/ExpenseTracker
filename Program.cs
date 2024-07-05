using DotEnv.Core;
using ExpenseTracker.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<EnvReader>();
builder.Services.Configure<ExpenseTrackerDatabaseSettings>(builder.Configuration.GetSection("ExpenseTrackerDatabase"));

{
    new EnvLoader()
        .AddEnvFile("config.env")
        .Load();
}


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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