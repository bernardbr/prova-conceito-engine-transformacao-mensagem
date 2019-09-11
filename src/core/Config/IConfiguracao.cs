namespace BernardBr.PoCs.TransformacaoMensagem.Core.Config
{
    /// <summary>
    /// Interface de modelo de configuração do sistema.
    /// </summary>
    public interface IConfiguracao
    {
        /// <summary>
        /// Obtém ou define as configurações de transformação da bairro.
        /// </summary>
        IConfiguracaoItem ConfiguracaoBairro { get; set; }

        /// <summary>
        /// Obtém ou define as configurações de transformação do cidade.
        /// </summary>
        IConfiguracaoItem ConfiguracaoCidade { get; set; }
    }
}