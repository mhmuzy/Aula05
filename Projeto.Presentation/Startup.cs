using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Projeto.Presentation
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //habilitar o recurso de MVC para o projeto..
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //habilitar o uso da pasta /wwwroot
            app.UseStaticFiles();

            //mapear a página inicial do projeto MVC
            app.UseMvc(
                routes => {
                    routes.MapRoute(
                        name : "default", //caminho de página padrão do sistema
                        template : "{controller=Home}/{action=Index}"); //ROTA default /Home/Index
                });

        }
    }
}
