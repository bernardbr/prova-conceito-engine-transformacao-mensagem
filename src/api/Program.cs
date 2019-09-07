namespace BernardBr.PoCs.TransformacaoMensagem.API
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;

    /// <summary>
    /// Classe de entrada da API.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Método principal de configuração inicial da API.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            WebHost
                .CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build()
                .Run();
        }
    }
}
