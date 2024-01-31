using LivroDeReceitas.Comunicacao.Resposta;
using LivroDeReceitas.Exceptions;
using LivroDeReceitas.Exceptions.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace LivroDeReceitas.Api.Filtros
{
    public class FiltroExceptions : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
           if(context.Exception is LivrodeReceitasExecption) {
                TrataLivroReceitasExceptions(context);
            }
            else
            {

            }
        }

        private void TrataLivroReceitasExceptions(ExceptionContext context)
        {
            if(context.Exception is ErroValidacaoException)
            {
                TratarErrosValidacaoException(context);
            }
                       
        }

        private void TratarErrosValidacaoException(ExceptionContext context)
        {
            var erroValidacao = context.Exception as ErroValidacaoException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new ObjectResult(new RespostaErroJson(erroValidacao.MensagemDeErro));
        }

        private void LancarErroDesconhecido(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new RespostaErroJson(ResourceMensagensDeErro.ERRO_DESCONHECIDO));
        }
    }
}
