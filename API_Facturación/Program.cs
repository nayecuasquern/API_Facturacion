using API_FActuración.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

//


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbFacturacionContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));

//Politica CORS
builder.Services.AddCors(p => p.AddPolicy("corspolicy", build => build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//
app.UseCors("corspolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
