using System.Text;

namespace _01.SecretChat;
class Program
{
    static void Main(string[] args)
    {
        string concealedMessage = Console.ReadLine();   
        StringBuilder sb = new StringBuilder(concealedMessage);

        string input;
        while ((input = Console.ReadLine()) != "Reveal")
        {
            bool changed = false;
            string[] arguments = input.Split(":|:");

            switch (arguments[0])
            {
                case "InsertSpace":
                    int index = int.Parse(arguments[1]);
                    sb.Insert(index, ' ');

                    changed = true;
                    break;
                case "Reverse":
                    string substring = arguments[1];

                    if (sb.ToString().Contains(substring))
                    {
                        sb.Replace(substring, "");

                        string reversedSubstring = ReverseString(substring);
                        sb.Append(reversedSubstring);

                        changed = true;
                        break;
                    }

                    System.Console.WriteLine("error");
                    break;
                case "ChangeAll":
                    substring = arguments[1];
                    string replacement = arguments[2];
                    sb.Replace(substring, replacement);

                    changed = true;
                    break;
            }

            if (changed)
                System.Console.WriteLine(sb.ToString());
        }

        Console.WriteLine("You have a new text message: " + sb.ToString());
    }

    static string ReverseString(string s)
    {
        char[] chars = s.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }
}