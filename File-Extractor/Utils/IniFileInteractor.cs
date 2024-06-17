using System;
using IniParser;
using IniParser.Model;

namespace XMLExtractorTest
{
    public class IniFileInteractor
    {
        private readonly string _filePath;
        private FileIniDataParser _parser;

        public IniFileInteractor(string filePath)
        {
            _filePath = filePath;
            _parser = new FileIniDataParser();
        }

        public IniData Read()
        {
            IniData iniData = null;
            try
            {
                iniData = _parser.ReadFile(_filePath);
            }
            catch (IniParser.Exceptions.ParsingException e)
            {
                throw new IniParser.Exceptions.ParsingException(e.InnerException.Message);
            }

            return iniData;
        }

        public void Write(IniData data)
        {
            _parser.WriteFile(_filePath, data);
        }

        public string GetValue(string section, string key)
        {
            try
            {
                IniData iniData = Read();
                if (iniData == null)
                    throw new NullReferenceException();

                if (iniData.Sections.ContainsSection(section) && iniData[section].ContainsKey(key))
                {
                    var value = iniData[section][key];
                    return value;
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }
    }
}
