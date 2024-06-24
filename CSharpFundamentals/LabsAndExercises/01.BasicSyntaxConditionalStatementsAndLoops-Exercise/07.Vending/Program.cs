using System.Diagnostics.Tracing;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace _07.Vending
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double money = 0;

            string userInput = Console.ReadLine();
            
            // Read coins
            while (userInput != "Start")
            {
                try
                {
                    double currentValue = double.Parse(userInput);
                    bool isValueValid = currentValue == 0.1 || currentValue == 0.2 || currentValue == 0.5 || currentValue == 1 || currentValue == 2;

                    if (isValueValid)
                        money += currentValue;
                    else
                        Console.WriteLine("Cannot accept {0}", currentValue);
                }
                catch (FormatException e)
                {
                    throw new FormatException("Cannot convert input to double!", e);
                }
                userInput = Console.ReadLine();
            }

            // Read products
            while (userInput != "End")
            { 
                userInput = Console.ReadLine();
                bool isValidProduct = userInput == "Nuts" || userInput == "Water" || userInput == "Crisps" || userInput == "Soda" || userInput == "Coke";

                if (isValidProduct)
                {
                    string product = userInput;
                    double productPrice = 0;
                    switch (product)
                    {
                        case "Nuts":
                            productPrice = 2.0;
                            if (money >= productPrice)
                            {
                                Console.WriteLine("Purchased {0}", product.ToLower());
                                money -= productPrice;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                            break;
                        case "Water":
                             productPrice = 0.7;
                            if (money >= productPrice)
                            {
                                Console.WriteLine("Purchased {0}", product.ToLower());
                                money -= productPrice;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                            break;
                        case "Crisps":
                            productPrice = 1.5;
                            if (money >= productPrice)
                            {
                                Console.WriteLine("Purchased {0}", product.ToLower());
                                money -= productPrice;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                            break;
                        case "Soda":
                            productPrice = 0.8;
                            if (money >= productPrice)
                            {
                                Console.WriteLine("Purchased {0}", product.ToLower());
                                money -= productPrice;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                            break;
                        case "Coke":
                            productPrice = 1.0;
                            if (money >= productPrice)
                            {
                                Console.WriteLine("Purchased {0}", product.ToLower());
                                money -= productPrice;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                            break;
                    }
                }
                else if (userInput != "End")
                {
                    Console.WriteLine("Invalid product");
                }
            }

            Console.WriteLine("Change: {0:f2}", money);
        }   
    }
}