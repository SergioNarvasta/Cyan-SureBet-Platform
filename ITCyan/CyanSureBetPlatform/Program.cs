using Cyan.Application.Interfaces;
using Cyan.Application.Services;
using Cyan.Infraestructure.Interfaces;
using Cyan.Infraestructure.Services;
using Cyan.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureSQLDatabaseConnection"));
});

builder.Services.AddTransient<IBetHistoryService, BetHistoryService>();
builder.Services.AddTransient<IBetHistoryAppService, BetHistoryAppService>();
builder.Services.AddTransient<IScrapperService, ScrapperService>();

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
