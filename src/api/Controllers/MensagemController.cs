namespace BernardBr.PoCs.TransformacaoMensagem.API.Controllers
{
    using System.Threading.Tasks;
    using System.Xml;
    using BernardBr.PoCs.TransformacaoMensagem.Core.Parsers;
    using BernardBr.PoCs.TransformacaoMensagem.Core.Models;
    using BernardBr.PoCs.TransformacaoMensagem.API.Utils;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Swashbuckle.AspNetCore.Annotations;
    using FluentValidation;
    using System;
    using BernardBr.PoCs.TransformacaoMensagem.Core.Exceptions;

    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("censo/{uf}/dados")]
    public class MensagemController : Controller
    {
        private readonly IValidator<IFormFile> validadorFormFile;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="MensagemController"/>.
        /// </summary>
        /// <param name="validadorFormFile"></param>
        public MensagemController(IValidator<IFormFile> validadorFormFile)
        {
            this.validadorFormFile = validadorFormFile;
        }

        /// <summary>
        /// Transforma um arquivo de censo em um formato específico em uma estrutura padrão Json.
        /// </summary>
        /// <param name="uf"></param>
        /// <param name="arquivo"></param>
        /// <returns></returns>
        [SwaggerResponse(200, "Arquivo convertido com sucesso.", typeof(Retorno))]
        [SwaggerResponse(400, "O arquivo não foi informado ou seu tipo não é suportado.")]
        [HttpPost]
        public async Task<IActionResult> Transformar(
            [FromRoute]string uf,
            [SwaggerParameter(Required = true)]
            [FromForm]IFormFile arquivo)
        {
            try
            {
                var validation = validadorFormFile.Validate(arquivo);
                if (!validation.IsValid)
                {
                    return this.BadRequest(validation.Errors);
                }

                var retornoParser = new RetornoParser(uf);
                var retorno = retornoParser.Parse(arquivo.ContentType, await arquivo.LerConteudo());

                return this.Ok(retorno);
            }
            catch (UfNaoConfiguradaException ex)
            {
                return this.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.Ok(ex);
            }
        }
    }
}