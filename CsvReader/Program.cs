using System;
using System.Collections.Generic;

namespace DictionarySnippets
{
    class Program
    {
        static void Main(string[] args)
        {
            Country norway = new Country("Norwary", "NOR", "Europe", 5_282_223);
            Country finland = new Country("Finland", "FIN", "Europe", 5_511_303);

            //Dictionary keys are unique!

            var countries = new Dictionary<string, Country>();
            countries.Add(norway.Code, norway);
            countries.Add(finland.Code, finland);

            bool exists = countries.TryGetValue("MUS", out Country country);

            if (exists)
                Console.WriteLine(country.Name);
            else
                Console.WriteLine("There is no Country with the code MUS");

            //simplied initiatio version of above by visual studio 
            //var countries = new Dictionary<string, Country>
            //{
            //    { norway.Code, norway },
            //    { finland.Code, finland }
            //};

            Country countryselected = countries["NOR"];
            Console.WriteLine(countryselected.Name);

            foreach (var country2 in countries.Values)
            {
                Console.WriteLine(country2.Name);
            }

            //foreach (var country in countries)
            //{
            //    Console.WriteLine(country.Value.Name);
            //}

            Dictionary<string, Country> countries2 = new Dictionary<string, Country>();
            countries2.Add("NOR", norway);
            countries2.Add("FIN", finland);

        }
    }
}
