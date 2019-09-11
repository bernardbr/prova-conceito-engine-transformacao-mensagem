namespace BernardBr.PoCs.TransformacaoMensagem.Core.Config
{
    /// <summary>
    /// Interface de item de configuração.
    /// </summary>    
    public interface IConfiguracaoItem
    {
        /// <summary>
        /// Obtém ou define o path do objeto.
        /// </summary>
        /// <example>body/regions/region/cities/city</example>
        /// <example>neighborhoods/neighborhood</example>        
        string PathObjeto { get; set; }

        /// <summary>
        /// Obtém ou define o nome da propriedade "nome".
        /// </summary>        
        string PropriedadeNome { get; set; }

        /// <summary>
        /// Obtém ou define o nome da propriedade "habitantes".
        /// </summary>        
        string PropriedadeHabitantes { get; set; }
    }
}