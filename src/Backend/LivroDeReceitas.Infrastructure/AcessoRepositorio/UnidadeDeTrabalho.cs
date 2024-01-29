using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivroDeReceitas.Domain.Repositorios;

namespace LivroDeReceitas.Infrastructure.AcessoRepositorio
{
    public sealed class UnidadeDeTrabalho : IDisposable, IUnidadeDeTrabalho
    {
        private readonly ReceitasContext _context;
        private bool _disposed;

        public UnidadeDeTrabalho(ReceitasContext receitasContext)
        {
            _context = receitasContext;
        }

        public async Task Commit()
        {
           await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }
}
