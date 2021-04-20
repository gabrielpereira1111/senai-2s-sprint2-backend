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

namespace senai.inlock.webApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services
                //Define a forma de autentica��o
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })

                //Par�metros de valida��o do Token
                .AddJwtBearer("JwtBearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        //quem est� emitindo
                        ValidateIssuer = true,
                        //quem � o destinat�rio/ recebendo
                        ValidateAudience = true,
                        //tempo de expira��o
                        ValidateLifetime = true,
                        
                        //forma de criptografia e a chave de autentica��o
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("key-usuario-inlock")),

                        //tempo de expira��o do token
                        ClockSkew = TimeSpan.FromMinutes(30),
                        //emissor
                        ValidIssuer = "inlock.webApi",
                        //destinat�rio
                        ValidAudience = "inlock.webApi"

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
            //Habilita a autentica��o(o usu�rio estar logado ou n�o) 
            app.UseAuthentication();
            //Habilita a autoriza��o(permiss�o)
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
