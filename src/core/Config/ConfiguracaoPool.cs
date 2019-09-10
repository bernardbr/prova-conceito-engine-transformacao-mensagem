namespace BernardBr.PoCs.TransformacaoMensagem.Core.Config
{
    using System;
    using System.Collections.Concurrent;

    /// <summary>
    /// Classe que representa as configurações do parser de resultado.
    /// </summary>
    public class ConfiguracaoPool
    {
        private static readonly ConcurrentDictionary<string, Configuracao> configuracoes;

        /// <summary>
        /// Esconde o construtor padrão de <see cref="ConfiguracaoPool"/>.
        /// </summary>
        private ConfiguracaoPool() { }

        /// <summary>
        /// Inicializa os membros estáticos de <see cref="ConfiguracaoPool"/>.
        /// </summary>
        static ConfiguracaoPool()
        {
            configuracoes = new ConcurrentDictionary<string, Configuracao>();
        }

        /// <summary>
        /// Obtém a configuração para parse do retorno para uma uf.
        /// </summary>
        /// <param name="uf">A uf da qual se deseja a configuração.</param>
        /// <returns>A instância de <see cref="ConfiguracaoPool"/> da uf solicitada.</returns>
        /// <exception cref="Exception">Caso a uf não esteja configurada.</exception>
        public static Configuracao ObterConfiguracao(string uf)
        {
            if (!configuracoes.TryGetValue(uf, out var configuracao))
            {
                throw new Exception("UF não configurada");
            }

            return configuracao;
        }

        /// <summary>
        /// Adiciona ou atualiza a configuração para uma uf.
        /// </summary>
        /// <param name="uf">A uf da configuração.</param>
        /// <param name="configuracao">A configuração.</param>
        public static void AdicionarOuAtualizarConfiguracao(string uf, Configuracao configuracao)
        {
            configuracoes.AddOrUpdate(uf, configuracao, (key, old) => configuracao);
        }
    }
}