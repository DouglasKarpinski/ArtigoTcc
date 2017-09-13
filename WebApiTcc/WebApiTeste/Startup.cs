using Data.Repository.Home;
using Data.Services.Home;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiTcc.Application.Home;
using WebApiTcc.Helpers.DataBaseInvoker;
using WebApiTcc.Repository.Home;
using WebApiTcc.Services.Home;

namespace WebApiTcc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            
            services.AddSingleton<IDatabaseInvoker, DatabaseInvoker>();
            services.AddSingleton<IHomeApplication, HomeApplication>();
            services.AddSingleton<IHomeServices, HomeServices>();
            services.AddSingleton<IHomeRepository, HomeRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
