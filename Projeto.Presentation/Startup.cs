using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.CrosssCutting.Cryptography.Contracts;
using Projeto.CrosssCutting.Cryptography.Services;
using Projeto.Data.Contracts;
using Projeto.Data.Repositories;

namespace Projeto.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //atributo utilizado para ler o arquivo appsetings.json
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //habilitar o recurso de MVC para o projeto..
            services.AddMvc();

            //habilitar o uso de autenticação no projeto
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            //ler o valor da connectionstring
            //armazenado no arquivo appsetings.json
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            //mapeamento a injeção de 
            //dependência para os repositórios 
            services.AddTransient<IFuncionarioRepository, FuncionarioRepository>(map => new FuncionarioRepository(connectionString));

            services.AddTransient<IPerfilRepository, PerfilRepository>(map => new PerfilRepository(connectionString));

            services.AddTransient<IUsuarioRepository, UsuarioRepository>(map => new UsuarioRepository(connectionString));

            services.AddTransient<IMD5Service, MD5Service>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //habilitar autenticação
            app.UseCookiePolicy();
            app.UseAuthentication();

            //habilitar o uso da pasta /wwwroot
            app.UseStaticFiles();

            //mapear a página inicial do projeto MVC
            app.UseMvc(
                routes => {
                    //mapeamento de conteúdo da área restrita do projeto
                    routes.MapRoute(
                        name: "areas", //mapear uma subarea do projeto
                        template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                    routes.MapRoute(
                        name : "default", //caminho de página padrão do sistema
                        template : "{controller=Home}/{action=Index}/{id?}"); //ROTA default /Home/Index
                        //ROTA default /Home/Index
                });

        }
    }
}
