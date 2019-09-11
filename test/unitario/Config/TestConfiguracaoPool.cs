namespace BernardBr.PoCs.TransformacaoMensagem.Test.Unitario.Config
{
    using BernardBr.PoCs.TransformacaoMensagem.Core.Config.Impl;
    using BernardBr.PoCs.TransformacaoMensagem.Core.Exceptions;
    using NUnit.Framework;

    /// <summary>
    /// Classe de testes de <see cref="ConfiguracaoPool" />.
    /// </summary>
    [TestFixture]
    public class TestConfiguracaoPool
    {
        /// <summary>
        /// Teste: Deve retornar exceção ao tentar recuperar a configuração de uma uf que ainda não esteja configurada.
        /// </summary>
        [Test]
        [Description(@"Deve retornar exceção ao tentar recuperar a configuração de uma uf que ainda não esteja configurada.")]
        public void Deve_Retornar_Excecao_Ao_Tentar_Recuperar_A_Configuracao_De_Uma_Uf_Que_Ainda_Nao_Esteja_Configurada()
        {
            Assert.Throws<UfNaoConfiguradaException>(() => ConfiguracaoPool.ObterConfiguracao("XX"));
        }
    }
}