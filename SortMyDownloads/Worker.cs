using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SortMyDownloads
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

  
        public override Task StartAsync(CancellationToken cancellationToken)
        {

   
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {

                    var downloadsPath = Path.Combine(FileOrganiser.GetFolderPath(), $"Downloads\\");
                    var downloadsFiles = Directory.GetFiles(downloadsPath);

                    if (downloadsFiles != null)
                    {
                        var DownloadsResults = await FileOrganiser.SortMyFilesAsync(downloadsFiles);

                        if (DownloadsResults > 0)
                            _logger.LogInformation($"{DownloadsResults} files Succesfully moved from Downloads at {DateTime.Now}");
                        else
                            _logger.LogWarning($" Folder is empty, No files were moved at {DateTime.Now}");
                    }
                    else
                    {
                        _logger.LogError($"Failed to get files in downloads folder at {DateTime.Now}");
                    }
                }catch(Exception ex)
                {
                    _logger.LogError($"Failed to move files : {ex.Message}");
                }

                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
