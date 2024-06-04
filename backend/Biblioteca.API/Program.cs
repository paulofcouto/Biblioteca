using Biblioteca.Application.Command.CadastrarUsuario;
using Biblioteca.Core.Repository;
using Biblioteca.Infrastructure.Persistence;
using Biblioteca.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials();
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();


var configuration = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BibliotecaDbContext>(
    options => options.UseSqlServer(configuration, t => t.MigrationsAssembly("Biblioteca.Infrastructure"))
);


builder.Services.AddMediatR(t => t.RegisterServicesFromAssembly(typeof(CadastrarUsuarioCommandHandler).Assembly));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("AllowOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
