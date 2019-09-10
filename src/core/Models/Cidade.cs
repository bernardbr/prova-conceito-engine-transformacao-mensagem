namespace BernardBr.PoCs.TransformacaoMensagem.Core.Models
{
    using System.Collections.Generic;
    
    using Newtonsoft.Json;

    /// <summary>
    /// Contrato com os dados padrão do censo de uma cidade.
    /// </summary>
    public class Cidade
    {
        /// <summary>
        /// Incializa uma nova instância de <see cref="Cidade"/>.
        /// </summary>
        public Cidade()
        {
            this.Bairros = new List<Bairro>();
        }

        /// <summary>
        /// Obtém ou deifine o nome da cidade.
        /// </summary>
        [JsonProperty("cidade")]
        public string Nome { get; set; }

        /// <summary>
        /// Obtém ou define a quantidade de habitantes da cidade.
        /// </summary>
        [JsonProperty("habitantes")]
        public long Habitantes { get; set; }

        /// <summary>
        /// Obtém ou define a lista de bairros da cidade.
        /// </summary>
        /// <value></value>
        [JsonProperty("bairros")]
        public List<Bairro> Bairros { get; set; }
    }
}