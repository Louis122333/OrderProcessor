using Microsoft.Extensions.Logging;
using OrderProcessor.Interfaces;
using OrderProcessor.Models;
using System.Text.Json;

namespace OrderProcessor.Services
{
    public class OrderSaver : IOrderSaver
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly ILogger<OrderSaver> _logger;

        public OrderSaver(JsonSerializerOptions jsonSerializerOptions, ILogger<OrderSaver> logger)
        {
            _jsonSerializerOptions = jsonSerializerOptions;
            _logger = logger;
        }

        public void SaveOrderToFile(Order order, string outputFolder)
        {
            string fileName = Path.Combine(outputFolder, $"Order_{order.OrderNumber}_{order.OrderDate.Replace(" ", "_")}.json");
            string orderJson = JsonSerializer.Serialize(order, _jsonSerializerOptions);

            File.WriteAllText(fileName, orderJson);
            _logger.LogInformation($"Order {order.OrderNumber} saved to {fileName}");
        }
    }
}