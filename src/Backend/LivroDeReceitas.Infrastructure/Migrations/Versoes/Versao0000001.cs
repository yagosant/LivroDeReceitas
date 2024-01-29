using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceitas.Infrastructure.Migrations.Versoes
{
    [Migration((long)EnumVersoes.CriarTabelaUsuario, "Criando a tabela usuário")]
    public class Versao0000001 : Migration
    {
        public override void Down()
        {
            //reverte uma versão de migration
            throw new NotImplementedException();
        }

        public override void Up()
        {
            //cria as tabelas
           var tabela =  VersaoBase.InserirColunasPadrao(Create.Table("Usuario"));

            tabela
                .WithColumn("Name").AsString(100).PrimaryKey().NotNullable()
                .WithColumn("Email").AsString().NotNullable()
                .WithColumn("Senha").AsString(2000).NotNullable()
                .WithColumn("Telefone").AsString(14).NotNullable();
        }
    }
}
