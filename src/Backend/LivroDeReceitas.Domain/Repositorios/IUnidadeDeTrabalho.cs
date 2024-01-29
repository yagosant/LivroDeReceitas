using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceitas.Domain.Repositorios
{
    public interface IUnidadeDeTrabalho
    {
        Task Commit();
    }
}
