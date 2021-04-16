using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Define o uso de Controllers
            services.AddControllers();
            services
                //Define a forma de autenticação
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })

                //Define o padrão de validação do token
                .AddJwtBearer("JwtBearer",options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        //validar quem está emitindo
                        ValidateIssuer = true,
                        //validar o destinatário/recebendo
                        ValidateAudience = true,
                        //validar o tempo de expiração
                        ValidateLifetime = true,
                        //A forma de criptografia e a chave de autenticação
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao")),
                        //tempo de expiração/intervalo de tempo que o token será válido
                        ClockSkew = TimeSpan.FromMinutes(30),
                        //Nome do Issuer(emissor)
                        ValidIssuer = "Filmes.webApi",
                        //Nome do Audience(destinatário)
                        ValidAudience = "Filmes.webApi"
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization(); //Habilita o uso de Autorização
            app.UseAuthentication(); //Habilita o uso de Autenticação
            app.UseEndpoints(endpoints =>
            {
               
                //Define o mapeamento dos Controllers
                endpoints.MapControllers();
            });
        }
    }
}
