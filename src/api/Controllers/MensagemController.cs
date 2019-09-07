namespace BernardBr.PoCs.TransformacaoMensagem.API.Controllers
{
    using System.Threading.Tasks;
    using BernardBr.PoCs.TransformacaoMensagem.API.Utils;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// 
    /// </summary>
    [Route("api/v1/mensagens")]
    public class MensagemController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Gravar([FromForm]IFormFile arquivo)
        {
            return this.Ok(await arquivo.LerConteudo());
        }
    }
}