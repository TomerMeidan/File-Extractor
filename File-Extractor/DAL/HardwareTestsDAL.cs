using ATETelem;
using System;
using System.Collections.Generic;
using System.Linq;


namespace XMLExtractorTest
{
    /// <summary>
    /// Data access layer for XML files related to hardware tests.
    /// This class provides LINQ operations on various fields contained in models that resemble the structure of a HardwareTests XML file.
    /// </summary>
    class HardwareTestsDAL
    {
        /// <summary>
        /// Stores the parsed hardware tests data from an XML file.
        /// </summary>
        private HardwareTests _hardwareTestsData;

        /// <summary>
        /// Initializes a new instance of the HardwareTestsDAL class with the given hardware tests data.
        /// </summary>
        /// <param name="hardwareTestsData">The hardware tests data to be stored.</param>
        public HardwareTestsDAL(HardwareTests hardwareTestsData)
        {
            this._hardwareTestsData = hardwareTestsData;
        }

        /// <summary>
        /// Retrieves a list of all components belonging to a specified test group.
        /// </summary>
        /// <param name="testGroup">The test group whose components are to be retrieved.</param>
        /// <returns>A list of all components in the specified test group.</returns>
        public List<TestComponent> GetAllComponentsByGroup(TestGroup testGroup)
        {
            var response = from value in testGroup.TestComponents.TestComponent
                           select value;
            return response.ToList();
        }

        /// <summary>
        /// Retrieves a single test component by its ID from all available test components across different test groups.
        /// </summary>
        /// <param name="testComponentId">The ID of the test component to retrieve.</param>
        /// <returns>The test component with the specified ID, or null if not found.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the specified test component ID is not found.</exception>

        public TestComponent GetComponentByID(string testComponentId)

        {
            TestComponent response = _hardwareTestsData.TestGroup
                                   // Flatten the collection of TestComponents from all groups
                                   .SelectMany(group => group.TestComponents.TestComponent)
                                   // Ensure Id comparison is correct type
                                   .FirstOrDefault(component => component.Id == testComponentId.ToString());

            if (response == null)
                throw new KeyNotFoundException($"Test Component ID '{testComponentId}' not found.");

            return response;
        }
    }
}
