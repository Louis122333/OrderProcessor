namespace OrderProcessor.Interfaces
{
    /// <summary>
    /// Interface for processing files containing order data.
    /// </summary>
    public interface IFileProcessor
    {
        /// <summary>
        /// Processes a given file by parsing its content and saving the parsed data to the specified output folder.
        /// </summary>
        /// <param name="filePath">The path to the file to be processed.</param>
        /// <param name="outputFolder">The folder where the processed file's output will be saved.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task ProcessFileAsync(string filePath, string outputFolder);
    }
}
