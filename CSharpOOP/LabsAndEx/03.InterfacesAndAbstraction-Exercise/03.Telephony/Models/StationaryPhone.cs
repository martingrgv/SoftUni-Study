using PhoneManufactory.Interfaces;

namespace PhoneManufactory.Models;
public class StationaryPhone : ICallable
{
    public void Call(string number)
    {
        if (isNumberValid(number))
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }

    public bool isNumberValid(string number)
    {
        foreach (char ch in number)
        {
            if (char.IsLetter(ch))
            {
                throw new ArgumentException("Invalid number!");
            }
        }

        return true;
    }
}

