using DotEnv.Core;
using ExpenseTracker.Models;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// MongoDbAccess Config
var settings = builder.Configuration.GetSection("ExpenseTrackerDatabase").Get<ExpenseTrackerDatabaseSettings>();
builder.Services.AddSingleton(settings);

builder.Services.AddSingleton<MongoDbAccess>();

// ENV Settings
{
    new EnvLoader()
        .AddEnvFile("config.env")
        .Load();
}
builder.Services.AddTransient<IEnvReader, EnvReader>();

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