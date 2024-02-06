using LivroDeReceitas.Application.UseCases.Usuario.Registrar;
using LivroDeReceitas.Comunicacao.Requisicao;
using LivroDeReceitas.Comunicacao.Resposta;
using LivroDeReceitas.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace LivroDeReceitas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(RespostaUsuarioRegistradoJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> RegistrarUsuario(
            [FromServices] IRegistrarUsuarioUseCase useCase,
            [FromBody] RequisicaoRegistrarUsuarioJson request
            )
        {
          //  if (!ModelState.IsValid) return BadRequest(ModelState);

            var resultado = await useCase.Executar(request);

            return Created(string.Empty, resultado);
        }
    }
}
