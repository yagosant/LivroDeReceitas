using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceitas.Exceptions.ExceptionBase
{
    public class ErroValidacaoException : LivrodeReceitasExecption
    {
        public List<string> MensagemDeErro { get; set; }

        public ErroValidacaoException(List<string> mensagemDeErro)
        {
            MensagemDeErro = mensagemDeErro;
        }
    }
}
