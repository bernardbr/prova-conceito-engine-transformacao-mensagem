namespace BernardBr.PoCs.TransformacaoMensagem.Core.Config.Impl
{
    using System;
    using System.Collections.Concurrent;
    using BernardBr.PoCs.TransformacaoMensagem.Core.Exceptions;

    /// <summary>
    /// Classe que representa as configurações do parser de resultado.
    /// </summary>
    public sealed class ConfiguracaoPool
    {
        private static readonly ConcurrentDictionary<string, IConfiguracao> configuracoes;

        /// <summary>
        /// Esconde o construtor padrão de <see cref="ConfiguracaoPool"/>.
        /// </summary>
        private ConfiguracaoPool() { }

        /// <summary>
        /// Inicializa os membros estáticos de <see cref="ConfiguracaoPool"/>.
        /// </summary>
        static ConfiguracaoPool()
        {
            configuracoes = new ConcurrentDictionary<string, IConfiguracao>();
        }

        /// <summary>
        /// Obtém a configuração para parse do retorno para uma uf.
        /// </summary>
        /// <param name="uf">A uf da qual se deseja a configuração.</param>
        /// <returns>A instância de <see cref="ConfiguracaoPool"/> da uf solicitada.</returns>
        /// <exception cref="Exception">Caso a uf não esteja configurada.</exception>
        public static IConfiguracao ObterConfiguracao(string uf)
        {
            if (!configuracoes.TryGetValue(uf, out var configuracao))
            {
                throw new UfNaoConfiguradaException(uf);
            }

            return configuracao;
        }

        /// <summary>
        /// Adiciona ou atualiza a configuração para uma uf.
        /// </summary>
        /// <param name="uf">A uf da configuração.</param>
        /// <param name="configuracao">A configuração.</param>
        public static void AdicionarOuAtualizarConfiguracao(string uf, IConfiguracao configuracao)
        {
            configuracoes.AddOrUpdate(uf, configuracao, (key, old) => configuracao);
        }
    }
}