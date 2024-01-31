using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceitas.Comunicacao.Resposta
{
    public class RespostaErroJson
    {
        public List<string> Mensagem {  get; set; }

        public RespostaErroJson(string msg)
        {
            Mensagem = new List<string>
            {
                msg
            };
        }

        public RespostaErroJson(List<string> msg)
        {
            Mensagem = msg;
        }
    }
}
