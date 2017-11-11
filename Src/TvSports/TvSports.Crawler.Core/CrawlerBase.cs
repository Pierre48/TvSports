using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TvSports.Core.Interfaces;

namespace TvSports.Crawler.Core
{
    public abstract class CrawlerBase : ICrawler
    {
        protected readonly ILogger _logger;
        protected CrawlerBase(ILogger logger)
        {
            _logger = logger;
        }

        public void Start()
        {
            _logger.LogInformation($"Starting {this}...");
            StartingAsync();
            _logger.LogInformation($"{this} started.");


        }

        public void Stop()
        {
            _logger.LogInformation($"Stopping {this}");
            Stopping();
            _logger.LogInformation($"{this} stopped.");
        }

        protected abstract void StartingAsync();
        protected abstract void Stopping();

    }
}
