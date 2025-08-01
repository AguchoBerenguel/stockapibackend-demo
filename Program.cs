using Microsoft.EntityFrameworkCore;
using StockApi.Data;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://*:80");

// Servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StockDbContext>(options =>
    options.UseSqlite("Data Source=database.db"));

builder.Services.AddCors();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
