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

namespace LivroDeReceitas.Infrastructure
{
    public static class Bootstrapper
    {
        public static void AddRepositorio(this IServiceCollection services, IConfiguration configurationManager)
        {
            AddFluentMigrator(services, configurationManager);
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
