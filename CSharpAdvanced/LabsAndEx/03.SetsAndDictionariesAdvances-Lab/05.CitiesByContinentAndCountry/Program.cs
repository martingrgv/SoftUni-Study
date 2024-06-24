namespace _05.CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var continents = new Dictionary<string, Dictionary<string, List<string>>>();

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] continentArgs = Console.ReadLine().Split();
                AddContinent(continents, continentArgs);
            }

            foreach (var continent in continents)
            {
                string continentName = continent.Key;
                Dictionary<string, List<string>> countries = continent.Value;

                Console.WriteLine(continentName + ":");

                foreach (var country in countries)
                {
                    string countryName = country.Key;
                    List<string> capitals = country.Value;

                    Console.WriteLine($"   {countryName} -> {string.Join(", ", capitals)}");
                }
            }
        }

        private static void AddContinent(Dictionary<string, Dictionary<string, List<string>>> continents, string[] continentArgs)
        {
            string continentName = continentArgs[0];

            if (!continents.ContainsKey(continentName))
            {
                continents.Add(continentName, new Dictionary<string, List<string>>());
            }

            AddCountries(continents, continentName, continentArgs);
        }

        private static void AddCountries(Dictionary<string, Dictionary<string, List<string>>> continents, string continentName, string[] continentArgs)
        {
            string countryName = continentArgs[1];
            string capitalName = continentArgs[2];

            if (!continents[continentName].ContainsKey(countryName))
            {
                continents[continentName].Add(countryName, new List<string>());
            }

            continents[continentName][countryName].Add(capitalName);
        }
    }
}
