using OrderProcessor.Interfaces;

namespace OrderProcessor.Services
{
    public class FileProcessor : IFileProcessor
    {
        private readonly IOrderParser _orderParser;
        private readonly IOrderSaver _orderSaver;

        public FileProcessor(IOrderParser orderParser, IOrderSaver orderSaver)
        {
            _orderParser = orderParser;
            _orderSaver = orderSaver;
        }

        public async Task ProcessFileAsync(string filePath, string outputFolder)
        {
            await _orderParser.ParseAndSaveOrdersAsync(filePath, outputFolder, _orderSaver);
        }
    }
}