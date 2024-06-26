using ADSProjectBackend.Repositories;
using ADSProjectBackend.Repositories.Interfaces;
using ADSProyect.Interfaces;
using ADSProyect.RepoActualizarEstudiantesitories;
using ADSProyect.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();    


// Configurando  inyeccion de dependecias 
builder.Services.AddSingleton<IEstudiante, EstudianteRepository>();
builder.Services.AddSingleton<ICarrera , CarreraRepository>();
builder.Services.AddSingleton<IMateria, MateriaRepository>();
builder.Services.AddSingleton<IProfesor, ProfesorRepository>();
builder.Services.AddSingleton<IGrupo, GrupoRepository>();

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
