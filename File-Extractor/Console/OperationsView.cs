using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Threading;

namespace XMLExtractorTest
{
    /// <summary>
    /// Operations view handler for the console application.
    /// Manages the display and interaction with the operations menu for handling hardware test data.
    /// </summary>
    class OperationsView : IView
    {
        private readonly IHardwareBLL _hardwareTestsBLL = new HardwareTestsBLL();

        private string _title = string.Format("\n----- XML Extractor Program - Operations Menu ----- \n"
                            + "Select the option in the console you wish to perform.\n"
                            + "Here are the following available operations:");

        /// <summary>
        /// Initializes a new instance of the OperationsView class and loads data from the specified file path.
        /// </summary>
        /// <param name="filePath">The file path to the data file.</param>
        public OperationsView(string filePath)
        {
            try
            {
                _hardwareTestsBLL.LoadDataFromPath(filePath);
                Console.WriteLine("Uploading was a success!");
            }
            catch (Exception e)
            {
                MessageBoard.ErrorMessage(e.Message);
                _hardwareTestsBLL = null;
            }
        }

        public string OperationsPrompt()
        {

            var response = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(_title)
                    .PageSize(5)
                    .MoreChoicesText("[grey](Move up and down to reveal more choices)[/]")
                    .AddChoices(new[] {
                        "Get All Components",
                        "Get Component by ID",
                        "Clear Console",
                        "Go Back",
                    }));

            Console.ResetColor();

            return response;

        }

        /// <summary>
        /// Displays the operations menu and handles user input for operations on hardware test data.
        /// </summary>
        public void DisplayMenu()
        {
            if (_hardwareTestsBLL == null)
            {
                MessageBoard.ErrorMessage("No file was uploaded to the project! Cannot display Operations menu.");
                return;
            }

            string userInput = OperationsPrompt();



            while (!userInput.Equals("Go Back"))
            {
                try
                {

                    switch (userInput)
                    {
                        case "Get All Components":
                            _hardwareTestsBLL?.PrintAllHardwareTestsData();
                            break;
                        case "Get Component by ID":

                            var userChoice = AnsiConsole.Prompt(
                            new TextPrompt<string>("Select Component ID (Type 'back' to exit this mode): ")
                                .PromptStyle("blue"));

                            userChoice = userChoice.ToLower();
                            if (userChoice.Equals("back"))
                                break;

                            _hardwareTestsBLL?.PrintComponentByID(userChoice);

                            break;
                        case "Clear Console":
                            Tools.ClearAndDisplayTitle();
                            break;
                        default:

                            break;
                    }

                    userInput = OperationsPrompt();

                }
                catch (FormatException e)
                {
                    MessageBoard.ErrorMessage($"{e.Message}");
                }
                catch (KeyNotFoundException e)
                {
                    MessageBoard.ErrorMessage($"{e.Message}");
                }

            }

            Tools.ClearAndDisplayTitle();
        }

    }
}
