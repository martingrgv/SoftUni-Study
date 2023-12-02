using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    internal class Program
    {
        static List<FoodItem> foodItems = new();
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            foodItems = GetFoodItemsList(text);

            int totalCalories = GetTotalCalories();
            int surviveDays = totalCalories / 2000;

            Console.WriteLine($"You have food to last you for: {surviveDays} days!");

            foreach (FoodItem item in foodItems)
            {
                Console.WriteLine($"Item: {item.Name}, Best before: {item.ExpirationDate}, Nutrition: {item.Calories}");
            }
        }

        static List<FoodItem> GetFoodItemsList(string text)
        {
            List<FoodItem> items = new();

            string pattern = @"(#|\|)(?<FoodName>[A-Za-z ]+)\1(?<ExpireDate>\d{2}\/\d{2}\/\d{2})\1(?<Calories>\d+)\1";
            MatchCollection matches = Regex.Matches(text, pattern);

            foreach (Match match in matches)
            {
                FoodItem item = new FoodItem();

                item.Name = match.Groups["FoodName"].Value;
                item.ExpirationDate = match.Groups["ExpireDate"].Value;
                item.Calories = int.Parse(match.Groups["Calories"].Value);

                items.Add(item);
            }

            return items;
        }

        static int GetTotalCalories()
        {
            int total = 0;

            foodItems.ForEach(i => total += i.Calories);
            return total;
        }
    }
}