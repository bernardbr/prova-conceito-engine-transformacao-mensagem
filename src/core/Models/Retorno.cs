namespace BernardBr.PoCs.TransformacaoMensagem.Core.Models
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// O contrato de retorno padrão.
    /// </summary>
    public class Retorno
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="Retorno"/>.
        /// </summary>
        public Retorno()
        {
            this.Cidades = new List<Cidade>();
        }

        /// <summary>
        /// Obtém ou define a lista de cidades do retorno.
        /// </summary>
        [JsonProperty("result")]
        public List<Cidade> Cidades { get; set; }
    }
}