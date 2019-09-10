namespace BernardBr.PoCs.TransformacaoMensagem.API.Utils
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Atributo para as controllers 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class RoutePrefixAttribute : RouteAttribute
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="RoutePrefixAttribute" />.
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public RoutePrefixAttribute(string template)
            : base(FormatarComTemplateBase(template))
        {
        }

        private static string FormatarComTemplateBase(string template)
        {
            // TODO: Recuperar o base template da configuração.
            return $"/api/v1{(template.StartsWith("/") ? string.Empty : "/")}{template}";
        }
    }
}