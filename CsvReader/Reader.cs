﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DictionarySnippets
{
    class Reader
    {
        private string csvFilePath;

        public Reader(string csvfilepath)
        {
            this.csvFilePath = csvfilepath;
        }

        public List<Country> ReadAllCountries()
        {
            List<Country> countries = new List<Country>();

            using (StreamReader sr = new StreamReader(csvFilePath))
            {
                sr.ReadLine();

                string csvline;
                while ((csvline = sr.ReadLine()) != null)
                {
                    
                    countries.Add(ReadCountryFromCsvLine(csvline));
                }
            }

            return countries;
        }

        public Country ReadCountryFromCsvLine(string csvLine)
        {
            string[] parts = csvLine.Split(',');
            string name;
            string code;
            string region;
            string popText;
            switch (parts.Length)
            {
                case 4:
                    name = parts[0];
                    code = parts[1];
                    region = parts[2];
                    popText = parts[3];
                    break;
                case 5:
                    name = parts[0] + ", " + parts[1];
                    name = name.Replace("\"", null).Trim();
                    code = parts[2];
                    region = parts[3];
                    popText = parts[4];
                    break;
                default:
                    throw new Exception($"Can't parse country from csvLine: {csvLine}");
            }

            // TryParse leaves population=0 if can't parse
            int.TryParse(popText, out int population);
            return new Country(name, code, region, population);
        }
    }
}
