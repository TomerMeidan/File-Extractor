using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;

namespace XMLExtractorTest
{

    partial class Program
    {

        static void Main(string[] args)
        {
            Tools.ClearAndDisplayTitle();

            MessageBoard.IniMessage();

            IniFileInteractor _iniFileInteractor = new IniFileInteractor("../../Settings.ini");
            IView mainMenu = new MainMenuView(_iniFileInteractor);

            mainMenu.DisplayMenu();

            Console.WriteLine("\nPress ENTER key to continue...");
            Console.Read();
        }


    }
}
