using Dapper;
using MySqlConnector;

namespace LivroDeReceitas.Infrastructure.Migrations;

public static class DataBase
{
    public static void CriarDataBase(string conexaoComBancoDedados, string nomeDataBase)
    {
        using var minhaconexao = new MySqlConnection(conexaoComBancoDedados);
        var parametros = new DynamicParameters();

        parametros.Add("nome", nomeDataBase);

        var registros = minhaconexao.Query("SELECT * FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = @nome", parametros);

        if (!registros.Any())
        {
            minhaconexao.Execute($"CREATE DATABASE {nomeDataBase}");
        }


    }
}
