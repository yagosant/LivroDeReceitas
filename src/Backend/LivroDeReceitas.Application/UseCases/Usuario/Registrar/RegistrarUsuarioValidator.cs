﻿using FluentValidation;
using LivroDeReceitas.Comunicacao.Requisicao;
using LivroDeReceitas.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LivroDeReceitas.Application.UseCases.Usuario.Registrar
{
    public class RegistrarUsuarioValidator : AbstractValidator<RequisicaoRegistrarUsuarioJson>
    {
        public RegistrarUsuarioValidator()
        {
            RuleFor(c=> c.Name).NotEmpty().WithMessage(ResourceMensagensDeErro.NOME_USUARIO_EMBRANCO);
            RuleFor(c=> c.Email).NotEmpty().WithMessage(ResourceMensagensDeErro.EMAIL_USUARIO_EMBRANCO);
            RuleFor(c=> c.Senha).NotEmpty().WithMessage(ResourceMensagensDeErro.SENHA_USUARIO_EMBRANCO);
            RuleFor(c=> c.Telefone).NotEmpty().WithMessage(ResourceMensagensDeErro.TELEFONE_USUARIO_EMBRANCO);

            When(c => !string.IsNullOrWhiteSpace(c.Email), () =>
            {
                RuleFor(c => c.Email).EmailAddress().WithMessage(ResourceMensagensDeErro.EMAIL_USUARIO_INVALIDO);
            });

            When(c => !string.IsNullOrWhiteSpace(c.Senha), () =>
            {
                RuleFor(c => c.Senha.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMensagensDeErro.SENHA_USUARIO_MINIMO_SEIS_CARACTERES);
            });

            When(c => !string.IsNullOrWhiteSpace(c.Telefone), () =>
            {
                RuleFor(c => c.Telefone).Custom((telefone, contexto) =>
                {
                    string padraoTel = "[0-9]{2} [1-9]{1} [0-9]{4}-[0-9]{4}";
                      var isMatch =  Regex.IsMatch(telefone, padraoTel);
                    if (!isMatch)
                    {
                        contexto.AddFailure(new FluentValidation.Results.ValidationFailure(nameof(telefone), ResourceMensagensDeErro.TELEFONE_USUARIO_INVALIDO));
                    }

                });
            });
        }
    }
}
