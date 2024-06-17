## Overview

This project showcases the utilization of C# 4.7.2 to handle XML serialization and file operations. It focuses on loading data from an XML file into a custom class named `HardwareTests`, utilizing `XmlSerializer` for serialization and deserialization processes, and displaying the extracted data in the console. The project serves as a practical guide for developers looking to understand and implement XML file processing in.NET applications.

![Design Diagram (1)](https://github.com/TomerMeidan/XMLExtractorTest/assets/92635815/6e4113f5-d4b1-4051-9438-1f4f1a244586)

## Features

- **XML File Loading**: Demonstrates how to programmatically load an XML file into a C# application.
- **Object Deserialization**: Utilizes `XmlSerializer` to convert XML data into instances of the `HardwareTests` class.
- **Console Output**: Prints the deserialized data to the console, providing clear insights into the application's functionality.

## Requirements

- Visual Studio 2015 or later version.
-.NET Framework 4.7.2.
- ```Settings.ini``` file in main root.

## INI File Structure
```[CONFIG]```\
```FILE_PATH = file_path/.../file.xml```

## Installation

1. Launch Visual Studio.
2. Create a new Console Application project targeting.NET Framework 4.7.2.
3. Replace the default code in `Program.cs` with the provided implementation.
4. Ensure the XML file is correctly placed at the specified path within `Program.cs`.

## Usage

After setting up the project as described above, build and execute the application. The program will attempt to load the XML file, deserialize its contents into a `HardwareTests` object, and print the relevant data to the console.

## To Do List

- [ ] Make a fully functional console user interaction.
- [ ] Add more actions to perform such as create XML files based on classes.
- [ ] Make the XML extractor more generic.
- [ ] Build a GUI Interface using WPF.
