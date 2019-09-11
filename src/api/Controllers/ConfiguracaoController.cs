namespace BernardBr.PoCs.TransformacaoMensagem.API.Controllers
{
    using BernardBr.PoCs.TransformacaoMensagem.API.Utils;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using BernardBr.PoCs.TransformacaoMensagem.Core.Config.Impl;
    using BernardBr.PoCs.TransformacaoMensagem.API.Models;
    using BernardBr.PoCs.TransformacaoMensagem.API.Parsers;

    /// <summary>
    /// Controller responsável pela configuração das transformações de mensagens.
    /// </summary>
    [RoutePrefix("censo/{uf}/configuracoes")]
    public class ConfiguracaoController : Controller
    {
        /// <summary>
        /// Adiciona ou atualiza a configuração para uma uf.
        /// </summary>
        /// <param name="uf">A uf da configuração.</param>
        /// <param name="configuracao">A configuração.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Configurar(
            [FromRoute]
            string uf,
            [SwaggerParameter(Required = true)]
            [FromBody]ConfiguracaoContrato configuracao)
        {
            ConfiguracaoPool.AdicionarOuAtualizarConfiguracao(uf, ConfiguracaoParser.Parse(configuracao));
            return this.Ok();
        }
    }
}