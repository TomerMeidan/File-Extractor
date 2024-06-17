using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace XMLExtractorTest
{
    /// <summary>
    /// Main menu view handler for the console application.
    /// Manages the initial menu and user interactions for uploading files and navigating to operations.
    /// </summary>
    public class MainMenuView : IView
    {
        private readonly IniFileInteractor _iniFileInteractor;

        private string _title = string.Format("\n----- XML Extractor Program - Main Menu ----- \n"
                        + "Select the option in the console you wish to perform.\n"
                        + "Here are the following available operations:");

        // Console Views
        private IView _operationsView = null;

        /// <summary>
        /// Initializes a new instance of the MainMenuView class with the specified INI file interactor.
        /// </summary>
        /// <param name="iniFileInteractor">The INI file interactor.</param>
        public MainMenuView(IniFileInteractor iniFileInteractor)
        {
            _iniFileInteractor = iniFileInteractor;
        }

        /// <summary>
        /// Displays the main menu and handles user input for navigation and file upload.
        /// </summary>
        public void DisplayMenu()
        {

            var userInput = MainMenuPrompt();

            while (!userInput.Equals("Exit Program"))
            {

                switch (userInput)
                {
                    case "Upload XML File":
                        UploadXMLFileHandler();
                        break;
                    case "File Operations":
                        bool uploadStatus = FileUploadStatus(_operationsView);
                        if (uploadStatus == true)
                        {
                            Tools.ClearAndDisplayTitle();
                            _operationsView.DisplayMenu();
                        }
                        break;
                    case "Clear Console":
                        Tools.ClearAndDisplayTitle();
                        break;
                    default:
                        MessageBoard.ErrorMessage("Invalid option. Please try again.");
                        break;
                }

                userInput = MainMenuPrompt();

            }
        }

        /// <summary>
        /// Checks if a file has been uploaded successfully.
        /// </summary>
        /// <param name="_hardwareTestsBLL">The HardwareTests BLL handler.</param>
        /// <returns>True if the file has been uploaded, false otherwise.</returns>
        public bool FileUploadStatus(IView view)
        {
            if (view == null)
            {
                MessageBoard.ErrorMessage("No file was uploaded to the project!");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Displays the welcome prompt for the XML Extractor Program Main Menu.
        /// Highlights the available operations in yellow.
        /// </summary>
        public string MainMenuPrompt()
        {

            var response = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(_title)
                    .PageSize(5)
                    .MoreChoicesText("[grey](Move up and down to reveal more choices)[/]")
                    .AddChoices(new[] {
                        "Upload XML File",
                        "File Operations",
                        "Clear Console",
                        "Exit Program",
                    }));

            return response;

        }

        /// <summary>
        /// Handles the upload of an XML file based on the configuration specified in the INI file.
        /// </summary>
        private void UploadXMLFileHandler()
        {
            string filePath = "";
            try
            {

                // Read the DATA of the XML attached to CLASS HardwareTests
                filePath = _iniFileInteractor.GetValue("CONFIG", "FILE_PATH");

            }
            catch (KeyNotFoundException e)
            {
                MessageBoard.ErrorMessage($"Main: {e.Message}");
                return;
            }
            catch(Exception e)
            {
                MessageBoard.ErrorMessage($"Main: {e.Message}");
                return;
            }

            // Link file path to other console view points
            if (filePath != null)
            {
                _operationsView = new OperationsView(filePath);
            }
            else
            {
                MessageBoard.ErrorMessage("Null file path from .ini file, Uploading file failed!");
                _operationsView = null;
            }

        }
    }
}
