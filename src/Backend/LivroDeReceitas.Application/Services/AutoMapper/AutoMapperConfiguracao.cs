using AutoMapper;
using LivroDeReceitas.Comunicacao.Requisicao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceitas.Application.Services.AutoMapper
{
    public class AutoMapperConfiguracao : Profile
    {
        public AutoMapperConfiguracao() { 

            CreateMap<RequisicaoRegistrarUsuarioJson, Domain.Entidades.Usuario>()
                .ForMember(destino => destino.Senha, config => config.Ignore()); //ignora a senha por causa da criptografia
        }
    }
}
