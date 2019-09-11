namespace BernardBr.PoCs.TransformacaoMensagem.API.Parsers
{
    using BernardBr.PoCs.TransformacaoMensagem.API.Models;
    using BernardBr.PoCs.TransformacaoMensagem.Core.Config;
    using BernardBr.PoCs.TransformacaoMensagem.Core.Config.Impl;

    /// <summary>
    /// Parse de <see cref="ConfiguracaoContrato"/> e <see cref="IConfiguracao" />.
    /// </summary>
    public static class ConfiguracaoParser
    {
        /// <summary>
        /// Converte <see cref="ConfiguracaoContrato"/> em <see cref="IConfiguracao" />.
        /// </summary>
        /// <param name="contrato">O contrato a ser convertido.</param>
        /// <returns>A instância de configuração.</returns>
        public static IConfiguracao Parse(ConfiguracaoContrato contrato)
        {
            IConfiguracao configuracao = new Configuracao();
            configuracao.ConfiguracaoBairro = new ConfiguracaoItem();
            configuracao.ConfiguracaoBairro.PathObjeto = contrato.PathBairro;
            configuracao.ConfiguracaoBairro.PropriedadeHabitantes = contrato.PropriedadeHabitantesBairro;
            configuracao.ConfiguracaoBairro.PropriedadeNome = contrato.PropriedadeNomeBairro;

            configuracao.ConfiguracaoCidade = new ConfiguracaoItem();
            configuracao.ConfiguracaoCidade.PathObjeto = contrato.PathCidade;
            configuracao.ConfiguracaoCidade.PropriedadeHabitantes = contrato.PropriedadeHabitantesCidade;
            configuracao.ConfiguracaoCidade.PropriedadeNome = contrato.PropriedadeNomeCidade;

            return configuracao;
        }
    }
}