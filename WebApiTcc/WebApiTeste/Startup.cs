using System.Globalization;
using Data.Repository;
using Data.Repository.Categoria;
using Data.Repository.ConsultaSatisfacao;
using Data.Repository.Estacao;
using Data.Repository.Home;
using Data.Repository.Login;
using Data.Repository.Produto;
using Data.Repository.UnidadeNegocio;
using Data.Services.Categoria;
using Data.Services.ConsultaSatisfacao;
using Data.Services.Emotion;
using Data.Services.Estacao;
using Data.Services.Home;
using Data.Services.Login;
using Data.Services.Produto;
using Data.Services.UnidadeNegocio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiTcc.Application.Home;

namespace WebApiTcc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton(Configuration.GetSection("ConnectionStrings").Get<UI>());

            services.AddSingleton<IHomeApplication, HomeApplication>();
            services.AddSingleton<IHomeServices, HomeServices>();
           // services.AddSingleton<IHomeRepository, HomeRepository>();
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IEstacaoService, EstacaoService>();
            services.AddTransient<IEstacaoRepository, EstacaoRepository>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<IEmotionService, EmotionService>();
            services.AddTransient<IConsultaSatisfacaoService, ConsultaSatisfacaoService>();
            services.AddTransient<IConsultaSatisfacaoRepository, ConsultaSatisfacaoRepository>();
            services.AddTransient<IUnidadeNegocioService, UnidadeNegocioService>();
            services.AddTransient<IUnidadeNegocioRepository, UnidadeNegocioRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var cultureInfo = new CultureInfo("pt-BR");

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
