using PhoneManufactory.Interfaces;

namespace PhoneManufactory.Models;
public class Smartphone : ICallable, IWebBrowsable
{
    public void Call(string number)
    {
        if (isNumberValid(number))
        {
            Console.WriteLine($"Calling... {number}"); ;
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

    public void WebBrowse(string URL)
    {
        if (IsURLValid(URL))
        {
            Console.WriteLine($"Browsing: {URL}!");
        }
    }

    private bool IsURLValid(string URL)
    {
        foreach (char ch in URL)
        {
            if (char.IsDigit(ch))
            {
                throw new ArgumentException("Invalid URL!");
            }
        }

        return true;
    }
}

