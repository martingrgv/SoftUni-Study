using System.Xml.Schema;

namespace _03.GamingStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string userInput = Console.ReadLine();
            double totalSpent = 0;

            // Buy games
            while (userInput != "Game Time") 
            {
                if (budget > 0)
                {
                    bool gameExists = userInput == "OutFall 4" || userInput == "CS: OG" || userInput == "Zplinter Zell" || userInput == "Honored 2" || userInput == "RoverWatch" || userInput == "RoverWatch Origins Edition";

                    if (gameExists)
                    {
                        string game = userInput;
                        double price = 0;

                        switch (game)
                        {
                            case "OutFall 4":
                                price = 39.99;
                                break;
                            case "CS: OG":
                                price = 15.99;
                                break;
                            case "Zplinter Zell":
                                price = 19.99;
                                break;
                            case "Honored 2":
                                price = 59.99;
                                break;
                            case "RoverWatch":
                                price = 29.99;
                                break;
                            case "RoverWatch Origins Edition":
                                price = 39.99;
                                break;
                        }

                        if (budget >= price)
                        {
                            budget -= price;
                            totalSpent += price;

                            Console.WriteLine($"Bought {game}");
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not Found");
                    }
                }

                if (budget <= 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
                userInput = Console.ReadLine();
            }

            if (budget > 0)
            {
                double remainingMoney = budget;
                Console.WriteLine($"Total spent: ${totalSpent:f2}. Remaining: ${remainingMoney:f2}");
            }
        }
    }
}