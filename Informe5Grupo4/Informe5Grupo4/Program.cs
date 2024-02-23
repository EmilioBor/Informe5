using Data.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//---------------------------------------------------------------
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


//CORS


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000/", "http://localhost:3001/", "http://localhost:3000/Bonos")
                            .AllowAnyHeader()  // Permite todos los encabezados
                            .AllowAnyMethod();  // Permite todos los métodos HTTP
                      });
});
//--------------------------------

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DBContext
builder.Services.AddDbContext<Informe4Context>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("Connection")));




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
