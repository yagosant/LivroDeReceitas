using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LivroDeReceitas.Domain.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LivroDeReceitas.Domain.Repositorios;
using LivroDeReceitas.Infrastructure.AcessoRepositorio.Repositorio;
using LivroDeReceitas.Infrastructure.AcessoRepositorio;
using Microsoft.EntityFrameworkCore;

namespace LivroDeReceitas.Infrastructure
{
    public static class Bootstrapper
    {
        public static void AddRepositorio(this IServiceCollection services, IConfiguration configurationManager)
        {
            AddFluentMigrator(services, configurationManager);
            addContexto(services, configurationManager);
            AddUnidadeDeTrabalho(services);
            AddRepositorios(services);
        }

        private static void addContexto(IServiceCollection services, IConfiguration configurationManager)
        {
            var versaoservidor = new MySqlServerVersion(new Version(10,4,11));
            var conectionString = configurationManager.GetConexaoCompleta();

            services.AddDbContext<ReceitasContext>(dbContextOptions =>
            dbContextOptions.UseMySql(conectionString, versaoservidor)
            );
        }
        private static void AddUnidadeDeTrabalho(IServiceCollection services)
        {
            services.AddScoped<IUnidadeDeTrabalho, UnidadeDeTrabalho>();
        }

        private static void AddRepositorios(IServiceCollection services)
        {
            services.AddScoped<IUsuarioWriteOnlyRepositorio, UsuarioRepositorio>()
                .AddScoped<IUsuarioReadOnlyRepositorio, UsuarioRepositorio>();
        }
        private static void AddFluentMigrator(IServiceCollection services, IConfiguration configurationManager)
        {
            services.AddFluentMigratorCore().ConfigureRunner(c =>
            c.AddMySql5()
            .WithGlobalConnectionString(configurationManager.GetConexaoCompleta()).ScanIn(Assembly.Load("LivroDeReceitas.Infrastructure")).For.All()
            );
        }
    }
}
