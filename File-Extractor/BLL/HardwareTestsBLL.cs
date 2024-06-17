using ATETelem;
using System;
using System.Collections.Generic;
using XMLUtils;

namespace XMLExtractorTest
{
    /// <summary>
    /// Business Logic Layer (BLL) for handling hardware tests data.
    /// This class orchestrates the retrieval and presentation of hardware tests data,
    /// leveraging both data access and utility layers.
    /// </summary>
    class HardwareTestsBLL : IHardwareBLL
    {
        /// <summary>
        /// Holds the parsed hardware tests data from an XML file.
        /// </summary>
        private HardwareTests _hardwareTestsData { get; set; }

        /// <summary>
        /// Facilitates data access operations for hardware tests data.
        /// </summary>
        private HardwareTestsDAL _hwTestDAL { get; set; }

        /// <summary>
        /// Initializes a new instance of the HardwareTestsBLL class with the specified XML file path.
        /// This constructor extracts XML data into a designated class and sets up the data access logic class.
        /// </summary>
        /// <param name="xmlFilePath">The file path to the XML file containing hardware tests data.</param>
        public HardwareTestsBLL(){}

        public void LoadDataFromPath(string xmlFilePath)
        {
            // Extract XML data into the designated class
            XMLExtractor<HardwareTests> xmlExtractor =
                new XMLExtractor<HardwareTests>(xmlFilePath);

            // Get class representation of the xml fields
            _hardwareTestsData = xmlExtractor.XMLClassInstance;

            // Set data access logic class
            _hwTestDAL = new HardwareTestsDAL(_hardwareTestsData);
        }

        /// <summary>
        /// Prints all hardware tests data to the console.
        /// This method iterates through all test groups and their components, presenting the data in a structured format.
        /// </summary>
        public void PrintAllHardwareTestsData()
        {
            List<TestGroup> hardwareTestGroups = _hardwareTestsData.TestGroup;

            foreach (var testGroup in hardwareTestGroups)
            {
                Console.WriteLine("-----------------------------------------");
                MessageBoard.PrintGroup(testGroup);

                List<TestComponent> components = _hwTestDAL.GetAllComponentsByGroup(testGroup);

                Console.WriteLine($"Components List:\n");

                foreach (var comp in components)
                {
                    MessageBoard.PrintComponent(comp);
                }
            }

            Console.WriteLine("-----------------------------------------");
        }

        /// <summary>
        /// Prints a specific test component by its ID to the console.
        /// This method retrieves a test component by its ID and presents its details.
        /// </summary>
        /// <param name="id">The ID of the test component to retrieve and print.</param>

        public void PrintComponentByID(string id)

        {
            TestComponent var = _hwTestDAL.GetComponentByID(id);
            MessageBoard.PrintComponent(var);
        }

    }
}
