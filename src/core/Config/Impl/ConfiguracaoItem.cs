namespace BernardBr.PoCs.TransformacaoMensagem.Core.Config.Impl
{
    /// <summary>
    /// Classe item de configuração.
    /// </summary>
    public class ConfiguracaoItem : IConfiguracaoItem
    {
        /// <summary>
        /// Obtém ou define o path do objeto.
        /// </summary>
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