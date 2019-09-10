namespace BernardBr.PoCs.TransformacaoMensagem.Core.Config
{
    /// <summary>
    /// Classe item de configuração.
    /// </summary>
    public class ConfiguracaoItem
    {
        /// <summary>
        /// Obtém ou define o path do objeto.
        /// </summary>
        /// <example>body/regions/region/cities/city</example>
        /// <example>neighborhoods/neighborhood</example>
        public string PathObjeto { get; set; }

        /// <summary>
        /// Obtém ou define o nome da propriedade "nome".
        /// </summary>
        public string PropriedadeNome { get; set; }

        /// <summary>
        /// Obtém ou define o nome da propriedade "habitantes".
        /// </summary>
        public string PropriedadeHabitantes { get; set; }         
    }
}