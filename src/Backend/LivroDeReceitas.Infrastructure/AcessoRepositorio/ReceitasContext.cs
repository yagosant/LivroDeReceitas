using LivroDeReceitas.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceitas.Infrastructure.AcessoRepositorio
{
    public class ReceitasContext : DbContext
    {
        public ReceitasContext(DbContextOptions<ReceitasContext> options) : base(options) { }

        //var para conectar com o bd
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReceitasContext).Assembly);
        }
    }
}
