using LivroDeReceitas.Domain.Entidades;
using LivroDeReceitas.Domain.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceitas.Infrastructure.AcessoRepositorio.Repositorio
{
    public class UsuarioRepositorio : IUsuarioWriteOnlyRepositorio, IUsuarioReadOnlyRepositorio
    {
        private readonly ReceitasContext _context;
        public UsuarioRepositorio(ReceitasContext receitasContext)
        {
            _context = receitasContext;
        }
        public async Task Adicionar(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
           // await _context.SaveChangesAsync();

        }

        public async Task<bool> ExisteUsuarioComEmail(string email)
        {
            return await _context.Usuarios.AnyAsync(x=> x.Email.Equals(email));
        }
    }
}
