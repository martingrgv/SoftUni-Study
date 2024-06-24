using System.Text.RegularExpressions;

namespace _01.Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Item> furnitures = new List<Item>();

            string input;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                Item furniture = GetItem(input);

                if (furniture.Name != null)
                    furnitures.Add(furniture);
            }

            PrintFurnitures(furnitures);
        }
        
        private static Item GetItem(string input)
        {
            string pattern = @">>(?<Name>[A-Za-z]+)<<(?<Price>\d+\.\d+|\d+)!(?<Quantity>\d+)";

            foreach (Match match in Regex.Matches(input, pattern))
            {
                Item furniture = new Item();
                furniture.Name = match.Groups["Name"].Value;
                furniture.Price = decimal.Parse(match.Groups["Price"].Value);
                furniture.Quantity = int.Parse(match.Groups["Quantity"].Value);

                return furniture;
            }

            return new Item();
        }

        private static void PrintFurnitures(List<Item> furnitures)
        {
            decimal total = 0;

            Console.WriteLine("Bought furniture:");

            foreach (Item furniture in furnitures)
            {
                Console.WriteLine(furniture.Name);
                total += furniture.Total;
            }

            Console.WriteLine($"Total money spend: {total:f2}");
        }
    }
}