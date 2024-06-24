using System.Net.Http.Headers;
using System.Security.Cryptography;

namespace _03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input 
            int personCount = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string day = Console.ReadLine();
            double pricePerPerson = 0;
            double totalPrice = 0;

            // Set price per person
            if (groupType == "Students")
            {
                switch (day)
                {
                    case "Friday":
                        pricePerPerson = 8.45;
                        break;
                    case "Saturday":
                        pricePerPerson = 9.80;
                        break;
                    case "Sunday":
                        pricePerPerson = 10.46;
                        break;
                }

                totalPrice = personCount * pricePerPerson;

                // Set discount
                if (personCount >= 30)
                    totalPrice =  totalPrice - (totalPrice * 0.15);
            }
            else if (groupType == "Business")
            {
                switch (day)
                {
                    case "Friday":
                        pricePerPerson = 10.90;
                        break;
                    case "Saturday":
                        pricePerPerson = 15.60;
                        break;
                    case "Sunday":
                        pricePerPerson = 16;
                        break;
                }

                totalPrice = personCount * pricePerPerson; 

                // Set discount
                if (personCount >= 100)
                    totalPrice = totalPrice - pricePerPerson * 10;
            }
            else
            {
                switch (day)
                {
                    case "Friday":
                        pricePerPerson = 15;
                        break;
                    case "Saturday":
                        pricePerPerson = 20;
                        break;
                    case "Sunday":
                        pricePerPerson = 22.50;
                        break;
                }

                totalPrice = personCount * pricePerPerson;

                // Set discount
                if (personCount >= 10 && personCount <= 20)
                    totalPrice = totalPrice - (totalPrice * 0.05);
            }

            Console.WriteLine("Total price: {0:f2}", totalPrice);
        }
    }
}