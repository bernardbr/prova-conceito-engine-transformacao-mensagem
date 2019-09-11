namespace BernardBr.PoCs.TransformacaoMensagem.Core.Parsers
{
    using BernardBr.PoCs.TransformacaoMensagem.Core.Models;
    using BernardBr.PoCs.TransformacaoMensagem.Core.Config.Impl;
    using BernardBr.PoCs.TransformacaoMensagem.Core.Config;

    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Xml;
    using System;

    /// <summary>
    /// Parser para o retorno padrão.
    /// </summary>
    public class RetornoParser
    {
        private readonly IConfiguracao configuracao;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="RetornoParser" />.
        /// </summary>
        /// <param name="uf">A uf do parser.</param>
        public RetornoParser(string uf)
        {
            this.configuracao = ConfiguracaoPool.ObterConfiguracao(uf);
        }

        /// <summary>
        /// Realiza o parse da instância de <see cref="JObject"/> para uma instância de <see cref="Retorno"/>.
        /// </summary>
        /// <param name="contentType">O tipo do arquivo.</param>
        /// <param name="conteudoArquivo">O conteúdo do arquivo os dados que serão convertidos.</param>
        /// <returns>O objeto convertido.</returns>
        public Retorno Parse(string contentType, string conteudoArquivo)
        {
            var jsonObject = JObjectFactory.Create(contentType, conteudoArquivo);
            var retorno = new Retorno();
            Parse<Cidade>(this.configuracao.ConfiguracaoCidade.PathObjeto.Split('/'), jsonObject, retorno.Cidades, PreencherCidade);
            return retorno;
        }

        private static void Parse<T>(
            IEnumerable<string> pathObjeto,
            JToken jsonObject,
            List<T> objetos,
            Action<JToken, List<T>> preencherObjetos)
        {
            var paths = pathObjeto;
            if (!paths.Any())
            {
                return;
            }

            var pathAtual = paths.First();
            // Caso esteja no último nível do path, significa que é hora de adicionar os objetos.
            if (!paths.Skip(1).Any())
            {
                AdicionarObjetosALista(pathAtual, jsonObject, objetos, preencherObjetos);
                return;
            }

            if (jsonObject[pathAtual] is JObject)
            {
                Parse<T>(pathObjeto.Skip(1), jsonObject[pathAtual], objetos, preencherObjetos);
                return;
            }

            foreach (var item in jsonObject[pathAtual])
            {
                Parse<T>(pathObjeto.Skip(1), item, objetos, preencherObjetos);
            }
        }

        private static void AdicionarObjetosALista<T>(
            string path,
            JToken jsonObject,
            List<T> objetos,
            Action<JToken, List<T>> preencherObjetos)
        {
            if (jsonObject[path] is JObject)
            {
                var item = jsonObject[path];
                preencherObjetos(item, objetos);
                return;
            }

            foreach (var item in jsonObject[path])
            {
                preencherObjetos(item, objetos);
            }
        }

        private void PreencherCidade(JToken jsonObject, List<Cidade> cidades)
        {
            var cidade = new Cidade();
            cidade.Nome = jsonObject[this.configuracao.ConfiguracaoCidade.PropriedadeNome].Value<string>();
            cidade.Habitantes = jsonObject[this.configuracao.ConfiguracaoCidade.PropriedadeHabitantes].Value<long>();

            Parse<Bairro>(this.configuracao.ConfiguracaoBairro.PathObjeto.Split('/'), jsonObject, cidade.Bairros, PreencherBairro);

            cidades.Add(cidade);
        }

        private void PreencherBairro(JToken jsonObject, List<Bairro> bairros)
        {
            var bairro = new Bairro();
            bairro.Nome = jsonObject[this.configuracao.ConfiguracaoBairro.PropriedadeNome].Value<string>();
            bairro.Habitantes = jsonObject[this.configuracao.ConfiguracaoBairro.PropriedadeHabitantes].Value<long>();
            bairros.Add(bairro);
        }
    }


    /// <summary>
    /// Factory de <see cref="JObject" /> responsável por contruir a instância de acordo com o content-type.
    /// </summary>
    internal static class JObjectFactory
    {
        private static IDictionary<string, Func<string, JObject>> construtores;

        /// <summary>
        /// Inicializa os membros estáticos de <see cref="JObjectFactory" />.
        /// </summary>
        static JObjectFactory()
        {
            construtores = new ConcurrentDictionary<string, Func<string, JObject>>();
            construtores.Add("application/xml", CriarJObjectAPartirDeXml);
            construtores.Add("application/json", CriarJObjectAPartirDeJson);
        }

        private static JObject CriarJObjectAPartirDeJson(string conteudoArquivo)
        {
            return JObject.Parse(conteudoArquivo);
        }

        private static JObject CriarJObjectAPartirDeXml(string conteudoArquivo)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(conteudoArquivo);
            var json = JsonConvert.SerializeXmlNode(doc);
            JObject jsonObject = JObject.Parse(json);
            return jsonObject;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="JObject" /> de acordo com o content-type.
        /// </summary>
        /// <param name="contentType">O content-type.</param>
        /// <param name="conteudoArquivo">O conteúdo do arquivo.</param>
        /// <returns></returns>
        internal static JObject Create(string contentType, string conteudoArquivo)
        {
            return construtores[contentType](conteudoArquivo);
        }
    }
}