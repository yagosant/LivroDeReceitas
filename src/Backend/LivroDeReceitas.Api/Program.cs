using LivroDeReceitas.Domain.Extension;
using LivroDeReceitas.Infrastructure;
using LivroDeReceitas.Infrastructure.Migrations;

namespace LivroDeReceitas.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddRepositorio(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            AtualizarBaseDeDados();

            app.Run();

           void AtualizarBaseDeDados()
            {
               var conexao =  builder.Configuration.GetConexaoDatabase();
               var nomeDB =  builder.Configuration.GetNomeDatabase();
                DataBase.CriarDataBase(conexao, nomeDB);

                app.MigrateBancoDeDados();
            }
        }
    }
}
