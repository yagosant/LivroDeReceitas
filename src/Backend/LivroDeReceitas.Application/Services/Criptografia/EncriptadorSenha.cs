using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceitas.Application.Services.Criptografia
{
    public class EncriptadorSenha
    {
        private readonly string _chaveDeEncriptacao;

        public EncriptadorSenha(string chaveDeEncriptacao)
        {
            _chaveDeEncriptacao = chaveDeEncriptacao;
        }
        public string Criptografar(string senha)
        {
            var senhaoComChaveAdicional = $"{senha}{_chaveDeEncriptacao}";

            var bytes = Encoding.UTF8.GetBytes(senhaoComChaveAdicional);
            var shar512 = SHA512.Create();
            byte[] hashbytes = shar512.ComputeHash(bytes);
            return StringBytes(hashbytes);
        }

        private static string StringBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(b);
            }
            return sb.ToString();
        }

    }
}
