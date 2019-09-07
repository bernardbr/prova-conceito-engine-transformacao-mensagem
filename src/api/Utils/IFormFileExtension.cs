namespace BernardBr.PoCs.TransformacaoMensagem.API.Utils
{
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Classe de extensão para <see cref="IFormFile"/>.
    /// </summary>
    public static class IFormFileExtension
    {
        /// <summary>
        /// Lê o conteúdo de uma instância de <see cref="IFormFile"/> de forma assíncrona.
        /// </summary>
        /// <param name="formFile">O <see cref="IFormFile"/> que terá o conteúdo lido.</param>
        /// <returns>O conteúdo do arquivo.</returns>
        public static async Task<string> LerConteudo(this IFormFile formFile)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(formFile.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    result.AppendLine(await reader.ReadLineAsync());
                }
            }

            return result.ToString();
        }
    }
}