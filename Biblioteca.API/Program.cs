using Biblioteca.Application.Command.CadastrarUsuario;
using Biblioteca.Core.Repository;
using Biblioteca.Infrastructure.Persistence;
using Biblioteca.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();

builder.Services.AddDbContext<BibliotecaDbContext>(options => 
{
    options.UseInMemoryDatabase("BibliotecaInMemory");
});

builder.Services.AddMediatR(t => t.RegisterServicesFromAssembly(typeof(CadastrarUsuarioCommandHandler).Assembly));


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
