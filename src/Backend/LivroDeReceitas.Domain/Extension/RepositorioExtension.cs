using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceitas.Domain.Extension
{
    public static class RepositorioExtension
    {
        public static string GetConexaoDatabase(this IConfiguration configurationManager)
        {
            var conexao = configurationManager.GetConnectionString("Conexao");
            return conexao;
        }

        public static string GetNomeDatabase(this IConfiguration configurationManager)
        {
            var nomeDB = configurationManager.GetConnectionString("DataBase");
            return nomeDB;
        }

        public static string GetConexaoCompleta(this IConfiguration configurationManager)
        {
            var conexao = configurationManager.GetConexaoDatabase();
            var nomeDB = configurationManager.GetNomeDatabase();

            return $"{conexao}Database={nomeDB}";
        }
    }
}
