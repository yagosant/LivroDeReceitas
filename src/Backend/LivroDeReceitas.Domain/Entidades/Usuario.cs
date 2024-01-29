using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceitas.Domain.Entidades
{
    public class Usuario : EntidadeBase
    {
       
        public string Name { get; set; }
        public string Email{ get; set;}
        public string Telefone { get; set; }
        public string Senha { get; set; }
    }
}
