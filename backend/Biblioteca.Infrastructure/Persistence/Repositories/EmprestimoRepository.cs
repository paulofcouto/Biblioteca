﻿using Biblioteca.Core.Entities;
using Biblioteca.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Persistence.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly BibliotecaDbContext _dbContext;

        public EmprestimoRepository(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CadastrarAssincrono(Emprestimo emprestimo)
        {
            var livro = await _dbContext.Livros.SingleOrDefaultAsync(l => l.Id == emprestimo.LivroId);
            if (livro == null)
            {
                throw new Exception($"LivroId {emprestimo.LivroId} não existe.");
            }

            var usuarioExiste = await _dbContext.Usuarios.AnyAsync(u => u.Id == emprestimo.UsuarioId);
            if (!usuarioExiste)
            {
                throw new Exception($"UsuarioId {emprestimo.UsuarioId} não existe.");
            }

            livro.MarcarEmprestado();
            await _dbContext.Emprestimos.AddAsync(emprestimo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Emprestimo>> ObterTodosAssincrono()
        {
            var emprestimos = await _dbContext.Emprestimos
                .Include(e => e.Usuario)        
                .Include(e => e.Livro)
                .AsNoTracking()
                .ToListAsync();

            return emprestimos;
        }

        public async Task<string> DevolverLivroAssincrono(int id)
        {
            var emprestimo = await _dbContext.Emprestimos.SingleOrDefaultAsync(p => p.Id == id);
            

            if(emprestimo != null)
            {
                var livro = await _dbContext.Livros.SingleOrDefaultAsync(p => p.Id == emprestimo.LivroId);
                
                if (livro != null)
                {
                    emprestimo.DevolverLivro();
                    livro.MarcarDisponivel();
                    await _dbContext.SaveChangesAsync();

                    if(emprestimo.DataDeDevolucao.Date > emprestimo.DataDeDevolucaoLimite.Date)
                    {
                        var diasEmAtraso = (emprestimo.DataDeDevolucao.Date - emprestimo.DataDeDevolucaoLimite.Date);
                        return "Devolução realizada com sucesso, porém com " + diasEmAtraso.TotalDays + " dias em atraso.";
                    }

                    return "Devolução realizada com sucesso";
                }
            }

            return "Não foi possível concluir a devolução do erro";
        }
    }
}
