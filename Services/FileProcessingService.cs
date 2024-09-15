using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace OrderProcessor.Services
{
    public class FileProcessingService
    {
        private readonly FileProcessor _fileProcessor;
        private readonly ILogger<FileProcessingService> _logger;
        private readonly IConfiguration _configuration;

        public FileProcessingService(FileProcessor fileProcessor, ILogger<FileProcessingService> logger, IConfiguration configuration)
        {
            _fileProcessor = fileProcessor;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task ProcessFilesAsync()
        {
            string? inputFolder = _configuration["FilePaths:InputFolder"];
            string? outputFolder = _configuration["FilePaths:OutputFolder"];

            if (string.IsNullOrEmpty(inputFolder) || string.IsNullOrEmpty(outputFolder))
            {
                _logger.LogError("Configuration is missing for input or output folder.");
                return;
            }

            var textFiles = Directory.GetFiles(inputFolder, "*.txt");

            foreach (var filePath in textFiles)
            {
                _logger.LogInformation($"Processing file: {Path.GetFileName(filePath)}");

                try
                {
                    await _fileProcessor.ProcessFileAsync(filePath, outputFolder);
                    _logger.LogInformation($"Finished processing {Path.GetFileName(filePath)}.\n");
                }
                catch (FileNotFoundException ex)
                {
                    _logger.LogError(ex, $"File not found: {filePath}");
                }
                catch (IOException ex)
                {
                    _logger.LogError(ex, $"I/O error processing file {filePath}: {ex.Message}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Unexpected error processing file {Path.GetFileName(filePath)}");
                }
            }
        }
    }
}