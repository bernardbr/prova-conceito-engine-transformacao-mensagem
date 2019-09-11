namespace BernardBr.PoCs.TransformacaoMensagem.Core.Exceptions
{
    using System;

    /// <summary>
    /// Classe de exceção para UF não configurada.
    /// </summary>
    public class UfNaoConfiguradaException : Exception
    {
        private const string MENSAGEM_EXCECAO = @"A UF {0} não está configurada. Para realizar a transformação do arquivo para esta UF é necessário realizar a configuração da mesma.";

        /// <summary>
        /// Inicializa uma nova instância de <see cref="UfNaoConfiguradaException"/>.
        /// </summary>
        /// <param name="uf">A uf não configurada.</param>
        public UfNaoConfiguradaException(string uf)
            : base(string.Format(MENSAGEM_EXCECAO, uf))
        {
        }
    }
}