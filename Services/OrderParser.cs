using OrderProcessor.Interfaces;
using OrderProcessor.Models;
using System.Globalization;

namespace OrderProcessor.Services
{
    public class OrderParser : IOrderParser
    {
        private readonly CultureInfo _invariantCulture = CultureInfo.InvariantCulture;
        private readonly int _batchSize = 100;

        public async Task ParseAndSaveOrdersAsync(string filePath, string outputFolder, IOrderSaver orderSaver)
        {
            using FileStream fs = new(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            using StreamReader sr = new(fs);
            string? line;
            Order? currentOrder = null;
            int processedRows = 0;

            while ((line = await sr.ReadLineAsync()) != null)
            {
                if (line.Length >= 2)
                {
                    if (line[0] == 'H')
                    {
                        if (currentOrder != null)
                        {
                            orderSaver.SaveOrderToFile(currentOrder, outputFolder);
                        }

                        currentOrder = new Order
                        {
                            OrderNumber = line.AsSpan(2, 9).ToString().Trim(),
                            CompanyCode = line.AsSpan(11, 7).ToString().Trim(),
                            OrderDate = line.AsSpan(18, 13).ToString().Trim(),
                            PosNumber = line.AsSpan(31, 5).ToString().Trim(),
                            Address = line.AsSpan(36, 25).ToString().Trim(),
                            Phone = line.AsSpan(61, 15).ToString().Trim(),
                            Rows = new List<OrderRow>()
                        };
                    }
                    else if (line[0] == 'R' && currentOrder != null)
                    {
                        var orderRow = new OrderRow
                        {
                            ArticleNumber = line.AsSpan(2, 9).ToString().Trim(),
                            Size = line.AsSpan(11, 5).ToString().Trim(),
                            Quantity = int.Parse(line.AsSpan(16, 6).ToString().Trim(), _invariantCulture),
                            PriceIncVat = decimal.Parse(line.AsSpan(22, 11).ToString().Trim(), _invariantCulture),
                            PriceExcVat = decimal.Parse(line.AsSpan(33, 11).ToString().Trim(), _invariantCulture),
                            Color = line.AsSpan(44, 17).ToString().Trim(),
                            Reference = line.AsSpan(61, 30).ToString().Trim()
                        };

                        currentOrder.Rows.Add(orderRow);
                        processedRows++;

                        if (processedRows % _batchSize == 0)
                        {
                            orderSaver.SaveOrderToFile(currentOrder, outputFolder);
                            currentOrder.Rows.Clear();
                        }
                    }
                }
            }

            if (currentOrder != null && currentOrder.Rows.Count > 0)
            {
                orderSaver.SaveOrderToFile(currentOrder, outputFolder);
            }
        }
    }
}