using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DivisorOdds.Domain.Mapper.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DivisorOdds.Domain.DependencyInjection;
using DivisorsOdds.Presentation.Configurations;
using DivisorOdds.CrossCutting.DefaultObjects;
using DivisorOdds.CrossCutting.Middlewares;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace DivisorOdds.Presentation
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
            services.AddControllers();
            services.ConfigureCompression();
            services.AddAutoMapper(typeof(AutoMapperConfiguration));
            services.AddDomainDependecies();
            services.ConfigureMvc();
            services.ConfigureJwtTokenService(Configuration);
            services.ConfigureSwaggerService();
            services.Configure<Token>(Configuration.GetSection("TokenConfigurations"));
            services.AddRouting(options => options.LowercaseUrls = true);
            services.ConfigureCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "OddDivisors V1");
                    c.RoutePrefix = "swagger";
                    c.DocumentTitle = "OddDivisors API Documentation";
                    c.DocExpansion(DocExpansion.None);
                });
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseException();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
