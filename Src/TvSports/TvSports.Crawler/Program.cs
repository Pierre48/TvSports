using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StructureMap;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TvGames.Core.Services;
using TvSports.Core.Extensions;
using TvSports.Core.Interfaces;
using TvSports.Core.Services;
using TvSports.Crawler.Crawlers;
using TvSports.Crawler.Crawlers.NbaNet;
using TvSports.Crawler.Crawlers.NbaNet.Services;
using TvSports.Infrastructure.Data;

namespace TvSports.Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ConfigureService();
            var injectedContainer = serviceProvider.GetService<IContainer>();

            var loggerFactory = injectedContainer.GetInstance<ILoggerFactory>();
            loggerFactory.AddConsole(LogLevel.Trace);

            var logger= loggerFactory.CreateLogger<Program>();
            logger.LogInformation("Starting ...");
            injectedContainer.GetAllInstances<ICrawler>().ForEach(c => c.Start());
            Console.ReadLine();
            injectedContainer.GetAllInstances<ICrawler>().ForEach(c => c.Stop());
        }

        private static IServiceProvider ConfigureService()
        {
            var services = new ServiceCollection()
                .AddSingleton(GetConfiguration())
                .AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
                .AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>))
                .AddScoped<ITeamService, TeamService>()
                .AddScoped<ICompetitionService, CompetitionService>()
                .AddScoped<ISportService, SportService>()
                .AddScoped<IZoneService, ZoneService>()
                .AddScoped<INbaNetService, NbaNetService > ()
                .AddScoped<IGameService, GameService>();
            services.AddLogging(builder => builder.SetMinimumLevel(LogLevel.Trace));


            //using StructureMap;
            var container = new Container();
            container.Configure(config =>
            {
                config.For<ICrawler>().Add<NbaNetCrawler>().Named("NbaNet").AlwaysUnique();
                config.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        }

        static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}
