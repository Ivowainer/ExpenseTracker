using DotEnv.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

{
    new EnvLoader()
        .AddEnvFile("config.env")
        .Load();
}

builder.Services.AddTransient<EnvReader>();

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