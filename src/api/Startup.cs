namespace BernardBr.PoCs.TransformacaoMensagem.API
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Classe que é invocada na inicialização da API.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="Startup" />.
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// A instância de configuração da API.
        /// </summary>
        /// <value></value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Método executado pelo runtime, onde se configura os serviços da API.
        /// </summary>
        /// <param name="services">A coeção de serviços que será configurada.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        /// <summary>
        /// Método responsável pela configuração do Pipeline de requests.
        /// </summary>
        /// <param name="app">A instância de <see cref="IApplicationBuilder" />.</param>
        /// <param name="env">As variáveis de ambiente da aplicação.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
