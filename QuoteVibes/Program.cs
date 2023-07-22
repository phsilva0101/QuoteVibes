using Microsoft.EntityFrameworkCore;
using QuoteVibes.CrossCutting.Settings;
using QuoteVibes.IoC;
using QuoteVibes.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var appConfig = builder.Configuration.Get<ConfigApp>();

builder.Services.AddDbContext<QuoteVibesContext>(options =>
    options.UseSqlServer(appConfig.ConnectionStrings.SQL));

builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
