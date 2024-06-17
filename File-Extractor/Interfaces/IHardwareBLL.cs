namespace XMLExtractorTest
{
    /// <summary>
    /// Interface for managing hardware test data.
    /// Provides methods to load, display, and interact with hardware test data.
    /// </summary>
    public interface IHardwareBLL
    {
        /// <summary>
        /// Loads hardware test data from the specified file path.
        /// </summary>
        /// <param name="filePath">The file path to the data file.</param>
        void LoadDataFromPath(string filePath);

        /// <summary>
        /// Prints all hardware test data to the console.
        /// </summary>
        void PrintAllHardwareTestsData();

        /// <summary>
        /// Prints the data of a specific hardware component identified by the provided ID.
        /// </summary>
        /// <param name="id">The ID of the hardware component.</param>
        void PrintComponentByID(string id);
    }
}
