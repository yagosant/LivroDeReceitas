using LivroDeReceitas.Comunicacao.Requisicao;
using LivroDeReceitas.Comunicacao.Resposta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceitas.Application.UseCases.Usuario.Registrar
{
    public interface IRegistrarUsuarioUseCase
    {
        Task<RespostaUsuarioRegistradoJson> Executar(RequisicaoRegistrarUsuarioJson requisicao);
    }
}
