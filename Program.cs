using PicPay.Context;
using Microsoft.EntityFrameworkCore;
using PicPay.Service;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<TransacaoService>();
var connString= builder.Configuration.GetConnectionString("ConexãoPadrão");

builder.Services.AddDbContext<Contexto>(
    Options => Options.UseMySql(connString,
    ServerVersion.AutoDetect(connString)));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
