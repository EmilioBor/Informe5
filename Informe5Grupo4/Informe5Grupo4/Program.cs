using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Interface;

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

//----
builder.Services.AddScoped<IBonoService, BonoService>();
builder.Services.AddScoped<IBonoEstadoService, BonoEstadoService>();
builder.Services.AddScoped<IDomicilioService, DomicilioService>();
builder.Services.AddScoped<IEntregaService, EntregaService>();
builder.Services.AddScoped<ILocalidadService, LocalidadService>();
builder.Services.AddScoped<IObraSocialService, ObraSocialService>();
builder.Services.AddScoped<IOdontologoEstadoService,  OdontologoEstadoService>();
builder.Services.AddScoped<IOdontologoService, OdontologoService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IPracticaService, PracticaService>();
builder.Services.AddScoped<IProvinciaService, ProvinciaService>();

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
