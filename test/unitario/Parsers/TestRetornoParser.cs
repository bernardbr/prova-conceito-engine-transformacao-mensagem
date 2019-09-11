namespace BernardBr.PoCs.TransformacaoMensagem.Test.Unitario.Parsers
{
    using BernardBr.PoCs.TransformacaoMensagem.Core.Config;
    using BernardBr.PoCs.TransformacaoMensagem.Core.Config.Impl;
    using BernardBr.PoCs.TransformacaoMensagem.Core.Parsers;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Classe de testes de <see cref="RetornoParser" />.
    /// </summary>
    [TestFixture]
    public class TestRetornoParser
    {
        /// <summary>
        /// Teste: Deve realizar a transformação de um arquivo de Acre.
        /// </summary>
        [Test]
        [Description("Deve realizar a transformação de um arquivo do Acre.")]
        public void DeveRealizarATransformacaoDoArquivoDeAc()
        {
            var configBairroMock = new Mock<IConfiguracaoItem>(MockBehavior.Strict);
            configBairroMock.SetupGet(mock => mock.PathObjeto).Returns(@"neighborhoods");
            configBairroMock.SetupGet(mock => mock.PropriedadeNome).Returns(@"name");
            configBairroMock.SetupGet(mock => mock.PropriedadeHabitantes).Returns(@"population");

            var configCidadeMock = new Mock<IConfiguracaoItem>(MockBehavior.Strict);
            configCidadeMock.SetupGet(mock => mock.PathObjeto).Returns(@"cities");
            configCidadeMock.SetupGet(mock => mock.PropriedadeNome).Returns(@"name");
            configCidadeMock.SetupGet(mock => mock.PropriedadeHabitantes).Returns(@"population");

            var configMock = new Mock<IConfiguracao>(MockBehavior.Strict);
            configMock.SetupGet(mock => mock.ConfiguracaoBairro).Returns(configBairroMock.Object);
            configMock.SetupGet(mock => mock.ConfiguracaoCidade).Returns(configCidadeMock.Object);

            const string UF = @"ac";
            ConfiguracaoPool.AdicionarOuAtualizarConfiguracao(UF, configMock.Object);

            const string CONTENT_TYPE = @"application/json";
            const string CONTEUDO_ARQUIVO = @"
                {
                    ""cities"": [
                        {
                            ""name"": ""Rio Branco"",
                            ""population"": 576589,
                            ""neighborhoods"": [
                                {
                                ""name"": ""Habitasa"",
                                ""population"": 7503
                                }
                            ]
                        }
                    ]
                }            
            ";

            var parser = new RetornoParser(UF);
            var retorno = parser.Parse(CONTENT_TYPE, CONTEUDO_ARQUIVO);

            Assert.IsNotNull(retorno);
            Assert.AreEqual(1, retorno.Cidades.Count);
            Assert.AreEqual("Rio Branco", retorno.Cidades[0].Nome);
            Assert.AreEqual(576589, retorno.Cidades[0].Habitantes);
            Assert.AreEqual(1, retorno.Cidades[0].Bairros.Count);
            Assert.AreEqual("Habitasa", retorno.Cidades[0].Bairros[0].Nome);
            Assert.AreEqual(7503, retorno.Cidades[0].Bairros[0].Habitantes);
        }

        /// <summary>
        /// Teste: Deve realizar a transformação de um arquivo de Minas Gerais.
        /// </summary>
        [Test]
        [Description("Deve realizar a transformação de um arquivo de Minas Gerais.")]
        public void DeveRealizarATransformacaoDoArquivoDeMg()
        {
            var configBairroMock = new Mock<IConfiguracaoItem>(MockBehavior.Strict);
            configBairroMock.SetupGet(mock => mock.PathObjeto).Returns(@"neighborhoods/neighborhood");
            configBairroMock.SetupGet(mock => mock.PropriedadeNome).Returns(@"name");
            configBairroMock.SetupGet(mock => mock.PropriedadeHabitantes).Returns(@"population");

            var configCidadeMock = new Mock<IConfiguracaoItem>(MockBehavior.Strict);
            configCidadeMock.SetupGet(mock => mock.PathObjeto).Returns(@"body/region/cities/city");
            configCidadeMock.SetupGet(mock => mock.PropriedadeNome).Returns(@"name");
            configCidadeMock.SetupGet(mock => mock.PropriedadeHabitantes).Returns(@"population");

            var configMock = new Mock<IConfiguracao>(MockBehavior.Strict);
            configMock.SetupGet(mock => mock.ConfiguracaoBairro).Returns(configBairroMock.Object);
            configMock.SetupGet(mock => mock.ConfiguracaoCidade).Returns(configCidadeMock.Object);

            const string UF = @"mg";
            ConfiguracaoPool.AdicionarOuAtualizarConfiguracao(UF, configMock.Object);

            const string CONTENT_TYPE = @"application/xml";
            const string CONTEUDO_ARQUIVO = @"
                <body>
                    <region>
                        <name>Triangulo Mineiro</name>
                        <cities>
                            <city>
                                <name>Uberlandia</name>
                                <population>700001</population>
                                <neighborhoods>
                                    <neighborhood>
                                        <name>Santa Monica</name>
                                        <zone>Zona Leste</zone>
                                        <population>13012</population>
                                    </neighborhood>
                                </neighborhoods>
                            </city>
                            <city>
                                <name>Uberaba</name>
                                <population>289376</population>
                                <neighborhoods>
                                    <neighborhood>
                                        <name>Abaeté</name>
                                        <zone>Centro</zone>
                                        <population>22690</population>
                                    </neighborhood>
                                </neighborhoods>
                            </city>
                        </cities>
                    </region>
                </body>        
            ";

            var parser = new RetornoParser(UF);
            var retorno = parser.Parse(CONTENT_TYPE, CONTEUDO_ARQUIVO);

            Assert.IsNotNull(retorno);
            Assert.AreEqual(2, retorno.Cidades.Count);
            Assert.AreEqual("Uberlandia", retorno.Cidades[0].Nome);
            Assert.AreEqual(700001, retorno.Cidades[0].Habitantes);
            Assert.AreEqual(1, retorno.Cidades[0].Bairros.Count);
            Assert.AreEqual("Santa Monica", retorno.Cidades[0].Bairros[0].Nome);
            Assert.AreEqual(13012, retorno.Cidades[0].Bairros[0].Habitantes);            

            Assert.AreEqual("Uberaba", retorno.Cidades[1].Nome);
            Assert.AreEqual(289376, retorno.Cidades[1].Habitantes);
            Assert.AreEqual(1, retorno.Cidades[1].Bairros.Count);
            Assert.AreEqual("Abaeté", retorno.Cidades[1].Bairros[0].Nome);
            Assert.AreEqual(22690, retorno.Cidades[1].Bairros[0].Habitantes);            
        }

        /// <summary>
        /// Teste: Deve realizar a transformação de um arquivo de Rio de Janeiro.
        /// </summary>
        [Test]
        [Description("Deve realizar a transformação de um arquivo do Rio de Janeiro.")]
        public void DeveRealizarATransformacaoDoArquivoDoRj()
        {
            var configBairroMock = new Mock<IConfiguracaoItem>(MockBehavior.Strict);
            configBairroMock.SetupGet(mock => mock.PathObjeto).Returns(@"bairros/bairro");
            configBairroMock.SetupGet(mock => mock.PropriedadeNome).Returns(@"nome");
            configBairroMock.SetupGet(mock => mock.PropriedadeHabitantes).Returns(@"populacao");

            var configCidadeMock = new Mock<IConfiguracaoItem>(MockBehavior.Strict);
            configCidadeMock.SetupGet(mock => mock.PathObjeto).Returns(@"corpo/cidade");
            configCidadeMock.SetupGet(mock => mock.PropriedadeNome).Returns(@"nome");
            configCidadeMock.SetupGet(mock => mock.PropriedadeHabitantes).Returns(@"populacao");

            var configMock = new Mock<IConfiguracao>(MockBehavior.Strict);
            configMock.SetupGet(mock => mock.ConfiguracaoBairro).Returns(configBairroMock.Object);
            configMock.SetupGet(mock => mock.ConfiguracaoCidade).Returns(configCidadeMock.Object);

            const string UF = @"rj";
            ConfiguracaoPool.AdicionarOuAtualizarConfiguracao(UF, configMock.Object);

            const string CONTENT_TYPE = @"application/xml";
            const string CONTEUDO_ARQUIVO = @"
                <corpo>
                    <cidade>
                        <nome>Rio de Janeiro</nome>
                        <populacao>10345678</populacao>
                        <bairros>
                            <bairro>
                                <nome>Tijuca</nome>
                                <regiao>Zona Norte</regiao>
                                <populacao>135678</populacao>
                            </bairro>
                            <bairro>
                                <nome>Botafogo</nome>
                                <regiao>Zona Sul</regiao>
                                <populacao>105711</populacao>
                            </bairro>
                        </bairros>
                    </cidade>
                    <cidade>
                        <nome>Teresópolis</nome>
                        <populacao>182594</populacao>
                        <bairros>
                            <bairro>
                                <nome>Tijuca</nome>
                                <regiao>Centro</regiao>
                                <populacao>13678</populacao>
                            </bairro>
                        </bairros>
                    </cidade>
                </corpo>   
            ";

            var parser = new RetornoParser(UF);
            var retorno = parser.Parse(CONTENT_TYPE, CONTEUDO_ARQUIVO);

            Assert.IsNotNull(retorno);
            Assert.AreEqual(2, retorno.Cidades.Count);
            Assert.AreEqual("Rio de Janeiro", retorno.Cidades[0].Nome);
            Assert.AreEqual(10345678, retorno.Cidades[0].Habitantes);
            Assert.AreEqual(2, retorno.Cidades[0].Bairros.Count);
            Assert.AreEqual("Tijuca", retorno.Cidades[0].Bairros[0].Nome);
            Assert.AreEqual(135678, retorno.Cidades[0].Bairros[0].Habitantes);            
            Assert.AreEqual("Botafogo", retorno.Cidades[0].Bairros[1].Nome);
            Assert.AreEqual(105711, retorno.Cidades[0].Bairros[1].Habitantes);            

            Assert.AreEqual("Teresópolis", retorno.Cidades[1].Nome);
            Assert.AreEqual(182594, retorno.Cidades[1].Habitantes);
            Assert.AreEqual(1, retorno.Cidades[1].Bairros.Count);
            Assert.AreEqual("Tijuca", retorno.Cidades[1].Bairros[0].Nome);
            Assert.AreEqual(13678, retorno.Cidades[1].Bairros[0].Habitantes);            
        }        
    }
}