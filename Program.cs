using DotEnv.Core;
using ExpenseTracker;
using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;
using ExpenseTracker.Repositories;
using ExpenseTracker.Services;

var builder = WebApplication.CreateBuilder(args);

// MongoDbAccess Config
builder.Services.Configure<ExpenseTrackerDatabaseSettings>(builder.Configuration.GetSection("ExpenseTrackerDatabase"));

builder.Services.AddSingleton<MongoDbAccess>();

// ENV Settings
{
    new EnvLoader()
        .AddEnvFile("config.env")
        .Load();
}
builder.Services.AddTransient<IEnvReader, EnvReader>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();