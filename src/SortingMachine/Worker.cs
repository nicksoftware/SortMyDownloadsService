using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FileSortingMachine
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var downloadsDirectory = Path.Combine(FileOrganiser.GetFolderPath(), @"Downloads\SortFilesInHere\");

                    var downloadsFiles = Directory.GetFiles(downloadsDirectory);

                    var DownloadsResults =  FileOrganiser.SortMyFiles(downloadsFiles);

                    if (DownloadsResults > 0)
                        _logger.LogInformation($"{DownloadsResults} files Succesfully moved from Downloads at {DateTime.Now}");
                    else
                        _logger.LogWarning($" Folder is empty, No files were moved at {DateTime.Now}");

                }
                catch (Exception ex)
                {
                    _logger.LogError($"Failed to move files : {ex.Message}");
                }

                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
