using AutoMapper;
using LivroDeReceitas.Application.Services.Criptografia;
using LivroDeReceitas.Comunicacao.Requisicao;
using LivroDeReceitas.Domain.Repositorios;
using LivroDeReceitas.Exceptions.ExceptionBase;
using LivroDeReceitas.Comunicacao.Resposta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivroDeReceitas.Application.Services.Token;
using LivroDeReceitas.Exceptions;

namespace LivroDeReceitas.Application.UseCases.Usuario.Registrar
{
    public class RegistrarUsuarioUseCase : IRegistrarUsuarioUseCase
    {
        private readonly IUsuarioWriteOnlyRepositorio _repositorio;
        private readonly IUsuarioReadOnlyRepositorio _usuarioReadOnlyRepositorio;
        private readonly IMapper _mapper;
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
        private readonly EncriptadorSenha _encriptadorSenha;
        private readonly TokenController _tokenController;
        public RegistrarUsuarioUseCase(IUsuarioWriteOnlyRepositorio repositorio, IMapper mapper,
            IUnidadeDeTrabalho unidadeDeTrabalho, EncriptadorSenha encriptadorSenha, TokenController token, IUsuarioReadOnlyRepositorio usuarioReadOnlyRepositorio)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _unidadeDeTrabalho = unidadeDeTrabalho;
            _encriptadorSenha = encriptadorSenha;
            _tokenController = token;
            _usuarioReadOnlyRepositorio = usuarioReadOnlyRepositorio;
        }

        public async Task<RespostaUsuarioRegistradoJson> Executar(RequisicaoRegistrarUsuarioJson requisicao)
        {
           await Validar(requisicao);
            var entidade = _mapper.Map<Domain.Entidades.Usuario> (requisicao);
            entidade.Senha = _encriptadorSenha.Criptografar(requisicao.Senha);
            await _repositorio.Adicionar(entidade);
            await _unidadeDeTrabalho.Commit();

            var token = _tokenController.GerarToken(entidade.Email);

            return new RespostaUsuarioRegistradoJson
            {
                Token = token
            };

        }

        private async Task Validar(RequisicaoRegistrarUsuarioJson requisicao)
        {
            var validator = new RegistrarUsuarioValidator();
            var resultado = validator.Validate(requisicao);

          var existeEmail = await  _usuarioReadOnlyRepositorio.ExisteUsuarioComEmail(requisicao.Email);

            if (existeEmail)
            {
                resultado.Errors.Add(new FluentValidation.Results.ValidationFailure("email", ResourceMensagensDeErro.USUARIO_JA_EXISTE));
            }
            if(!resultado.IsValid)
            {
                var msgErro = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();
                throw new ErroValidacaoException(msgErro);
            }
        }
    }
}
