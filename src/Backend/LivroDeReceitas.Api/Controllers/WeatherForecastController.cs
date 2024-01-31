using LivroDeReceitas.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace LivroDeReceitas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        
        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            var mensagem = ResourceMensagensDeErro.NOME_USUARIO_EMBRANCO;

            return Ok();
        }
    }
}
