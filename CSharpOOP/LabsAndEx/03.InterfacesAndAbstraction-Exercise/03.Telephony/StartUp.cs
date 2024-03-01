using PhoneManufactory.Models;

namespace PhoneManufactory;
class StartUp
{
    static void Main(string[] args)
    {
        string[] numbers = Console.ReadLine()
                           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                           .ToArray();
        string[] webLinks = Console.ReadLine()
                           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                           .ToArray();

        for (int i = 0; i < numbers.Length; i++)
        {
            try
            {
                if (numbers[i].Length == 7)
                {
                    StationaryPhone phone = new StationaryPhone();
                    phone.Call(numbers[i]);
                }
                else if (numbers[i].Length == 10)
                {
                    Smartphone phone = new Smartphone();
                    phone.Call(numbers[i]);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        for (int i = 0; i < webLinks.Length; i++)
        {
            try
            {
                Smartphone phone = new Smartphone();
                phone.WebBrowse(webLinks[i]);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

