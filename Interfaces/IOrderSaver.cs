using OrderProcessor.Models;

namespace OrderProcessor.Interfaces
{
    /// <summary>
    /// Interface for saving an order to a file.
    /// </summary>
    public interface IOrderSaver
    {
        /// <summary>
        /// Saves the provided order to a specified output folder in a JSON format.
        /// </summary>
        /// <param name="order">The order to be saved.</param>
        /// <param name="outputFolder">The folder where the order will be saved as a JSON file.</param>
        void SaveOrderToFile(Order order, string outputFolder);
    }
}