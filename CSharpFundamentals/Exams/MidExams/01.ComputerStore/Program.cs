using System.Data;

namespace _01.ComputerStore;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        bool isSpecial = input == "special" ? true : false;

        double partsCost = 0;
        int partsCount = 0;

        while (input != "special" || input != "regular")
        {
            int price = int.Parse(input);
            
            if (price > 0)
            {
                partsCount++;
                partsCost += int.Parse(input);
            }
            else if (price == 0)
            {
                System.Console.WriteLine("Invalid order!");
            }
            else
            {
                System.Console.WriteLine("Invalid price!");
            }
        }

        // Apply taxes
        double taxedCost = partsCost + ((partsCost * 0.2) * partsCount);
        double total = partsCost + taxedCost;

        if (isSpecial) // Apply special customer discount
        {
            total -= total * 0.1;
        }

        System.Console.WriteLine("Congratulations you've just bought a new computer!");
        System.Console.WriteLine($"Price without taxes: {partsCost:f2}");
        System.Console.WriteLine($"Taxes: {taxedCost:f2}");
        System.Console.WriteLine("-----------");
        System.Console.WriteLine($"Total price: {total:f2}$");
    }
}
