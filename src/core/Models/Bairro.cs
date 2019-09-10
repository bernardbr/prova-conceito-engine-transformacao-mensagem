namespace BernardBr.PoCs.TransformacaoMensagem.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Contrato com dados de um bairro pertencente a uma cidade. 
    /// </summary>
    public class Bairro
    {
        /// <summary>
        /// Obtém ou define o nome do bairro.
        /// </summary>
        [JsonProperty("nome")]
        public string Nome { get; set; }

        /// <summary>
        /// Obtém ou define a quantidade de habitantes do bairro.
        /// </summary>
        [JsonProperty("habitantes")]
        public long Habitantes { get; set; }
    }
}