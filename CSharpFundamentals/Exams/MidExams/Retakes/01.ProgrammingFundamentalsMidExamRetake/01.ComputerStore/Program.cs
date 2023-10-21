namespace _01.ComputerStore;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        double partsCost = 0;
        double taxedCost = 0;

        while (true)
        {
            if (input == "special" || input == "regular")
            {
                if (partsCost == 0)
                {
                    System.Console.WriteLine("Invalid order!");
                    return;
                }
                else
                {
                    break;
                }
            }

            double price = double.Parse(input);
            
            if (price > 0)
            {
                partsCost += price;
                taxedCost += price * 0.2;
            }
            else if (price == 0)
            {
                System.Console.WriteLine("Invalid order!");
            }
            else
            {
                System.Console.WriteLine("Invalid price!");
            }

            input = Console.ReadLine();
        }

        // Apply taxes
        double total = partsCost + taxedCost;

        bool isSpecial = input == "special" ? true : false;

        if (isSpecial) // Apply special customer discount
        {
            total -= total * 0.1;
        }

        System.Console.WriteLine("Congratulations you've just bought a new computer!");
        System.Console.WriteLine($"Price without taxes: {partsCost:f2}$");
        System.Console.WriteLine($"Taxes: {taxedCost:f2}$");
        System.Console.WriteLine("-----------");
        System.Console.WriteLine($"Total price: {total:f2}$");
    }
}
