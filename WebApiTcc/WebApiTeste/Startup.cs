using Data.Repository;
using Data.Repository.Categoria;
using Data.Repository.Home;
using Data.Repository.Produto;
using Data.Services.Categoria;
using Data.Services.Home;
using Data.Services.Produto;
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


        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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
