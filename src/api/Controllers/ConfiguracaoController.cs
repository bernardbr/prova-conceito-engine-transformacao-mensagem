namespace BernardBr.PoCs.TransformacaoMensagem.API.Controllers
{
    using BernardBr.PoCs.TransformacaoMensagem.Core.Parsers;
    using BernardBr.PoCs.TransformacaoMensagem.API.Utils;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using BernardBr.PoCs.TransformacaoMensagem.Core.Config;

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
            [FromBody]Configuracao configuracao)
        {
            ConfiguracaoPool.AdicionarOuAtualizarConfiguracao(uf, configuracao);
            return this.Ok();
        }
    }
}