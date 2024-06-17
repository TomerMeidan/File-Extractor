using System;
using System.IO;
using System.Xml.Serialization;
using XMLExtractorTest;

namespace XMLUtils
{
    /// <summary>
    /// A generic class for extracting and deserializing XML data into a specified class type.
    /// This class simplifies the process of reading XML files and converting them into strongly-typed objects.
    /// </summary>
    /// <typeparam name="T">The type of the class into which the XML data will be deserialized.</typeparam>
    public class XMLExtractor<T> where T : class
    {
        /// <summary>
        /// An instance of XmlSerializer used to deserialize XML data.
        /// </summary>
        private XmlSerializer _serializer = null;

        /// <summary>
        /// Gets the deserialized XML data represented as an instance of the specified class type.
        /// </summary>
        public T XMLClassInstance { get; private set; }

        /// <summary>
        /// Initializes a new instance of the XMLExtractor class with the specified XML file path.
        /// This constructor reads and deserializes the XML file into an instance of the specified class type.
        /// </summary>
        /// <param name="filename">The file path to the XML file to be deserialized.</param>
        public XMLExtractor(string filename)
        {

            _serializer = new XmlSerializer(typeof(T));
            XMLClassInstance = ReadFileIntoClass(filename);

        }

        /// <summary>
        /// Reads and deserializes an XML file into an instance of the specified class type.
        /// </summary>
        /// <param name="filename">The file path to the XML file.</param>
        /// <returns>An instance of the specified class type representing the deserialized XML data.</returns>
        private T ReadFileIntoClass(string filename)
        {
            // A FileStream is needed to read the XML document.
            FileStream fs = null;

            // Declare an object variable of the type to be deserialized.
            T xmlClass;

            try
            {
                fs = new FileStream(filename, FileMode.Open);

                // Use the Deserialize method to restore
                // the object's state with data from the XML document.
                xmlClass = (T)_serializer.Deserialize(fs);
                fs.Close();
                return xmlClass;
            }catch(System.IO.FileNotFoundException ex)
            {
                throw new System.IO.FileNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                fs.Close();
                throw new Exception(ex.GetBaseException().Message);
            }
        }

        // Additional methods for creating XML files can be added here.
    }
}
