using System.Collections.Generic;
using System.Xml.Serialization;

namespace ATETelem
{
    [XmlRoot(ElementName = "TestComponent")]
    public class TestComponent
    {
        [XmlElement(ElementName = "Id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "Importance")]
        public string Importance { get; set; }
        [XmlElement(ElementName = "IsCritical")]
        public string IsCritical { get; set; }
        [XmlElement(ElementName = "RegisterAddress")]
        public string RegisterAddress { get; set; }
        [XmlElement(ElementName = "LowerRange")]
        public string LowerRange { get; set; }
        [XmlElement(ElementName = "UpperRange")]
        public string UpperRange { get; set; }
    }

    [XmlRoot(ElementName = "TestComponents")]
    public class TestComponents
    {
        [XmlElement(ElementName = "TestComponent")]
        public List<TestComponent> TestComponent { get; set; }
    }

    [XmlRoot(ElementName = "TestGroup")]
    public class TestGroup
    {
        [XmlElement(ElementName = "TestComponents")]
        public TestComponents TestComponents { get; set; }
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "Description")]
        public string Description { get; set; }

        public TestComponent this[string componentName]
        {
            get
            {
                foreach (var component in TestComponents.TestComponent)
                {
                    if (component.Name == componentName)
                        return component;
                }
                throw new KeyNotFoundException($"Test Component '{componentName}' not found in Test Group '{Name}'.");
            }
        }
    }

    [XmlRoot(ElementName = "HardwareTests")]
    public class HardwareTests
    {
        [XmlElement(ElementName = "TestGroup")]
        public List<TestGroup> TestGroup { get; set; }

        public TestGroup this[string groupName]
        {
            get
            {
                foreach (var group in TestGroup)
                {
                    if (group.Type == groupName)
                        return group;
                }
                throw new KeyNotFoundException($"Test Group '{groupName}' not found.");
            }
        }
    }
}
