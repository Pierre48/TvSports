using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TvSports.Core.Interfaces;
using TvSports.Infrastructure.Data;
using TvSports.Core.Services;
using TvGames.Core.Services;
using System.IO;
using Swashbuckle.AspNetCore.Swagger;

namespace TvSports.Api
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

             services
                .AddSingleton(GetConfiguration())
                .AddScoped(typeof(CommonRepository<>), typeof(CommonRepository<>))
                .AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
                .AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>))
                .AddScoped<ITeamService, TeamService>()
                .AddScoped<ICompetitionService, CompetitionService>()
                .AddScoped<ISportService, SportService>()
                .AddScoped<IZoneService, ZoneService>()
                .AddScoped<ICompetitionInstanceService, CompetitionInstanceService>()
                .AddScoped<ICompetitionInstanceParticipantService, CompetitionInstanceParticipantService>()
                .AddScoped<IGameService, GameService>();

            services.AddDbContext<TvSportsContext>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "TvSports API", Version = "v1" });
            });
        }

        static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TvSports V1");
            });

            app.UseMvc();
        }
    }
}
