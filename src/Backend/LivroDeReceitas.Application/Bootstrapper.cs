using LivroDeReceitas.Application.UseCases.Usuario.Registrar;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceitas.Application
{
    public static class Bootstrapper
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRegistrarUsuarioUseCase, RegistrarUsuarioUseCase>();
        }
    }
}
