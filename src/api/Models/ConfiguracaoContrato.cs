namespace BernardBr.PoCs.TransformacaoMensagem.API.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Contrato de configuração da UF para leitura e transformação dos arquivos.
    /// </summary>
    public class ConfiguracaoContrato
    {
        /// <summary>
        /// Obtém ou define o path para obtenção dos dados de cidade.
        /// </summary>
        /// <example>body/regions/region/cities/city</example>
        [JsonProperty("pathCidade")]
        public string PathCidade { get; set; }

        /// <summary>
        /// Obtém ou define o nome da propriedade "nome" para os dados de cidade.
        /// </summary>
        [JsonProperty("propriedadeNomeCidade")]
        public string PropriedadeNomeCidade { get; set; }

        /// <summary>
        /// Obtém ou define o nome da propriedade "habitantes" para os dados de cidade.
        /// </summary>
        [JsonProperty("propriedadeHabitantesCidade")]
        public string PropriedadeHabitantesCidade { get; set; }

        /// <summary>
        /// Obtém ou define o path para obtenção dos dados de Bairro.
        /// </summary>
        /// <example>neighborhoods/neighborhood</example>
        [JsonProperty("pathBairro")]
        public string PathBairro { get; set; }

        /// <summary>
        /// Obtém ou define o nome da propriedade "nome" para os dados de Bairro.
        /// </summary>
        [JsonProperty("propriedadeNomeBairro")]
        public string PropriedadeNomeBairro { get; set; }

        /// <summary>
        /// Obtém ou define o nome da propriedade "habitantes" para os dados de Bairro.
        /// </summary>
        [JsonProperty("propriedadeHabitantesBairro")]
        public string PropriedadeHabitantesBairro { get; set; }
    }
}