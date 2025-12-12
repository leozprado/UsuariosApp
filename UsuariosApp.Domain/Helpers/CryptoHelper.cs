using System.Security.Cryptography;
using System.Text;

namespace UsuariosApp.Domain.Helpers
{
    /// <summary>
    /// Classe auxiliar para rotinas de criptografia de dados.
    /// </summary>
    public static class CryptoHelper
    {
        /// <summary>
        /// Método para criptografar strings usando o algoritmo SHA-256.
        /// </summary>
        /// <param name="input">Texto a ser criptografado.</param>
        /// <returns>Hash SHA-256 em formato hexadecimal.</returns>
        public static string ToSha256(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha.ComputeHash(bytes);

                var sb = new StringBuilder();
                foreach (var b in hash)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }
    }
}