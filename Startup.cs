using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlataformaITB.API.Models;
using PlataformaITB.API.Repositories;
using PlataformaITB.API.Services;

namespace PlataformaITB.API
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
            services.AddCors();

            services.AddControllers()
                    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;

            services.AddDbContext<ItbDadosContext>(options =>
            {
                //options.UseLazyLoadingProxies();
                options.EnableSensitiveDataLogging();
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionApplicationData"));
                //options.UseSqlServer(Configuration.GetConnectionString("ConnectionApplicationData"),
                //    sqlServerOptionsAction: sqlOptions => { sqlOptions.EnableRetryOnFailure(); });
            });

            services.AddScoped<IPedaMatriculaRepository, PedaMatriculaRespository>();
            services.AddScoped<IPedaMatriculasService, PedaMatriculaService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            app.UseCors(option => option.AllowAnyOrigin());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
