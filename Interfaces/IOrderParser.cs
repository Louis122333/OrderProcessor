namespace OrderProcessor.Interfaces
{
    /// <summary>
    /// Interface for parsing orders from a file and saving them.
    /// </summary>
    public interface IOrderParser
    {
        /// <summary>
        /// Parses orders from a given file, and saves the parsed orders using the provided order saver.
        /// </summary>
        /// <param name="filePath">The path to the file containing order data.</param>
        /// <param name="outputFolder">The folder where the parsed order should be saved.</param>
        /// <param name="orderSaver">The service responsible for saving the parsed order.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task ParseAndSaveOrdersAsync(string filePath, string outputFolder, IOrderSaver orderSaver);
    }
}