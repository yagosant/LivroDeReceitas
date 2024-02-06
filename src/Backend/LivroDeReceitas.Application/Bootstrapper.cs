using LivroDeReceitas.Application.Services.Criptografia;
using LivroDeReceitas.Application.Services.Token;
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
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            AdicionarChaveAdicionalsenha(services, configuration);
            AdicionarTokenJWT(services, configuration);

            services.AddScoped<IRegistrarUsuarioUseCase, RegistrarUsuarioUseCase>();
        }

        private static void AdicionarChaveAdicionalsenha(IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetRequiredSection("Configuracoes:ChaveAdicionalSenha");
            services.AddScoped(option => new EncriptadorSenha(section.Value));
        }

        private static void AdicionarTokenJWT(IServiceCollection services, IConfiguration configuration)
        {
            var sectionTempoVida = configuration.GetRequiredSection("Configuracoes:TempoVidaToken");
            var sectionKey = configuration.GetRequiredSection("Configuracoes:ChaveToken");

            services.AddScoped(option => new TokenController(int.Parse(sectionTempoVida.Value), sectionKey.Value));
        }
    }
}
