namespace BernardBr.PoCs.TransformacaoMensagem.Core.Config.Impl
{

    /// <summary>
    /// Modelo de configuração do sistema.
    /// </summary>
    public class Configuracao : IConfiguracao
    {
        /// <summary>
        /// Obtém ou define as configurações de transformação da bairro.
        /// </summary>
        public IConfiguracaoItem ConfiguracaoBairro { get; set; }

        /// <summary>
        /// Obtém ou define as configurações de transformação do cidade.
        /// </summary>
        public IConfiguracaoItem ConfiguracaoCidade { get; set; }
    }
}