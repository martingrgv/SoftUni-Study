using System.Text;

namespace _01.PasswordValidator;
class Program
{
    static string password;

    static void Main(string[] args)
    {
        password = Console.ReadLine();

        string input;
        while ((input = Console.ReadLine()) != "Complete")
        {
            string[] inArgs = input.Split();
            string command = inArgs[0];

            switch (command)
            {
                case "Make":
                    string casing = inArgs[1];
                    int index = int.Parse(inArgs[2]);

                    password = ChangeCasing(index, casing);
                    System.Console.WriteLine(password);
                    break;
                case "Insert":
                    index = int.Parse(inArgs[1]);
                    string ch = inArgs[2];

                    if (index > password.Length) // MIGHT BE >= INSTEAD
                        break;

                    password = password.Insert(index, ch);
                    System.Console.WriteLine(password);
                    break;
                case "Replace":
                    char replaceChar = char.Parse(inArgs[1]);
                    int value = int.Parse(inArgs[2]);

                    if (!password.Contains(replaceChar))
                        break;
                    
                    char newSymbol = (char)(replaceChar + value);
                    password = password.Replace(replaceChar, newSymbol);

                    System.Console.WriteLine(password);
                    break;
                case "Validation":
                    ValidatePassword();
                    break;
            }
        }
    }

    static string ChangeCasing(int index, string casingType)
    {
        StringBuilder sb = new StringBuilder(password);

        switch (casingType)
        {
            case "Upper":
                sb[index] = char.ToUpper(sb[index]);
                break;
            case "Lower":
                sb[index] = char.ToLower(sb[index]);
                break;
        }

        return sb.ToString();
    }

    static void ValidatePassword()
    {
        if (password.Length < 8)
            System.Console.WriteLine("Password must be at least 8 characters long!");

        if (!IsStringLettersOrDigits(password))
            System.Console.WriteLine("Password must consist only of letters, digits and _!");
        
        if (!ContainsUppercasing(password))
            System.Console.WriteLine("Password must consist at least one uppercase letter!");

        if (!ContainsLowercasing(password))
            System.Console.WriteLine("Password must consist at least one lowercase letter!");

        if (!ContainsDigit(password))
            System.Console.WriteLine("Password must consist at least one digit!");
    }

    static bool IsStringLettersOrDigits(string s)
    {
        bool isDigitsAndLetters = false;

        foreach (char ch in s)
        {
            if (char.IsLetterOrDigit(ch))
                isDigitsAndLetters = true;
            else
                isDigitsAndLetters = false;
        }

        return isDigitsAndLetters;
    }

    static bool ContainsUppercasing(string s)
    {
        foreach (char ch in s)
        {
            if (char.IsUpper(ch))
                return true;
        }

        return false;
    }

    static bool ContainsLowercasing(string s)
    {
        foreach (char ch in s)
        {
            if (char.IsLower(ch))
                return true;
        }

        return false;
    }

    static bool ContainsDigit(string s)
    {
        foreach (char ch in s)
        {
            if (char.IsDigit(ch))
                return true;
        }

        return false;
    }
}
