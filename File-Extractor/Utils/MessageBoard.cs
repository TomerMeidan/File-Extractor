using ATETelem;
using System;
using System.Linq;

namespace XMLExtractorTest
{
    /// <summary>
    /// Provides static methods for displaying messages and information to the console.
    /// Utilizes colored console output to differentiate between types of messages.
    /// </summary>
    public class MessageBoard
    {


        public static void IniMessage()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\nMake sure to write the xml file path in Settings.ini file");
            Console.WriteLine("\tINI File Structure:");
            Console.WriteLine("\t[CONFIG]");
            Console.WriteLine("\tFILE_PATH: filepath/.../file.XML\n");
            Console.ResetColor();
        }


        /// <summary>
        /// Prints the details of a given test group to the console.
        /// </summary>
        /// <param name="testGroup">The test group to print.</param>

        public static void PrintGroup(TestGroup testGroup)
        {
            Console.WriteLine($"ID: {testGroup.Id}");
            Console.WriteLine($"Name: {testGroup.Name}");
            Console.WriteLine($"Type: {testGroup.Type}");
            Console.WriteLine($"Description: {testGroup.Description}");
        }

        /// <summary>
        /// Prints the details of a given test component to the console.
        /// </summary>
        /// <param name="comp">The test component to print.</param>
        public static void PrintComponent(TestComponent comp)
        {

            Console.WriteLine("\t" + "-----------------------------------------");
            Console.WriteLine("\t" + $"ID: {comp.Id}");
            Console.WriteLine("\t" + $"Name: {comp.Name}");
            Console.WriteLine("\t" + $"Description: {comp.Description}");
            Console.WriteLine("\t" + $"Importance: {comp.Importance}");
            Console.WriteLine("\t" + $"IsCritical: {comp.IsCritical}");
            Console.WriteLine("\t" + $"RegisterAddress: {comp.RegisterAddress}");
            Console.WriteLine("\t" + $"LowerRange: {comp.LowerRange}");
            Console.WriteLine("\t" + $"UpperRange: {comp.UpperRange}");
            Console.WriteLine("\t" + "-----------------------------------------\n");


        }


        /// <summary>
        /// Displays an error message in red.
        /// </summary>
        /// <param name="msg">The error message to display.</param>

        public static void ErrorMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ERROR: ");
            Console.WriteLine(msg);
            Console.ResetColor();
        }


        /// <summary>
        /// Displays a feature or note message in blue.
        /// </summary>
        /// <param name="msg">The feature or note message to display.</param>
        public static void FeatureMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("NOTE: ");
            Console.WriteLine(msg);
            Console.ResetColor();
        }




    }
}
