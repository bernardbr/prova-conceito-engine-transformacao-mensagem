namespace BernardBr.PoCs.TransformacaoMensagem.Core.Config
{
    /// <summary>
    /// Modelo de configuração do sistema.
    /// </summary>
    public class Configuracao
    {
        /// <summary>
        /// Obtém ou define as configurações de transformação da bairro.
        /// </summary>
        public ConfiguracaoItem ConfiguracaoBairro { get; set; }

        /// <summary>
        /// Obtém ou define as configurações de transformação do cidade.
        /// </summary>
        public ConfiguracaoItem ConfiguracaoCidade { get; set; }        
    }
}