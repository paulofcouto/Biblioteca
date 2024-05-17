using Biblioteca.Application.InputModel;
using Biblioteca.Application.Services.Interfaces;
using Biblioteca.Application.ViewModel;
using Biblioteca.Core.Entities;

namespace Biblioteca.Application.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly BibliotecaDbContext _dbContext;

        public UsuarioService(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int CadastrarUsuario(NovoUsuarioInputModel inputModel)
        {
            var usuario = new Usuario(inputModel.Nome, inputModel.Email, inputModel.TipoUsuario);

            _dbContext.Usuarios.Add(usuario);
            _dbContext.SaveChanges();

            return usuario.Id;
        }

        public List<UsuarioViewModel> ObterTodosUsuarios(string query)
        {
            var usuarios = _dbContext.Usuarios.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query))
            {
                //TODO: montar a lógica para filtrar a query
            }

            var usuariosViewModel = usuarios.Select(t => new UsuarioViewModel(t.Id, t.Nome, t.Email, t.TipoUsuario)).ToList();

            return usuariosViewModel;
        }
    }
}
