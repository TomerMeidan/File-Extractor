using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLExtractorTest
{
    class Tools
    {
        public static void ClearAndDisplayTitle()
        {
            // Clear the console
            Console.Clear();

            // Render the canvas
            var title = new FigletText("XML Extractor")
                    .LeftJustified()
                    .Color(Color.Blue);

            AnsiConsole.Write(title);
        }
    }
}
