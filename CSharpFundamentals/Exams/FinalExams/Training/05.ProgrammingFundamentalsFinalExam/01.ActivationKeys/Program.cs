using System.Text;

namespace _01.ActivationKeys;
class Program
{
    static void Main(string[] args)
    {
        string key = Console.ReadLine();

        string input;
        while ((input = Console.ReadLine()) != "Generate")
        {
            string[] inputArgs = input.Split(">>>");
            string command = inputArgs[0];

            switch (command)
            {
                case "Contains":
                    string substring = inputArgs[1];

                    if (key.Contains(substring))
                    {
                        System.Console.WriteLine($"{key} contains {substring}");
                    }
                    else
                    {
                        System.Console.WriteLine("Substring not found!");
                    }
                    break;
                case "Flip":
                    string casing = inputArgs[1];
                    int startIndex = int.Parse(inputArgs[2]);
                    int endIndex = int.Parse(inputArgs[3]);
                    char[] keyArr = key.ToCharArray();

                    for (int i = startIndex; i < endIndex; i++)
                    {
                        switch (casing)
                        {
                            case "Upper":
                                keyArr[i] = char.ToUpper(keyArr[i]);
                                break;
                            case "Lower":
                                keyArr[i] = char.ToLower(keyArr[i]);
                                break;
                        }
                    }

                    key = new string(keyArr);
                    System.Console.WriteLine(key);
                    break;
                case "Slice":
                    startIndex = int.Parse(inputArgs[1]);
                    endIndex = int.Parse(inputArgs[2]);
                    int length = endIndex - startIndex;

                    if (length <= 0)
                    {
                        length = 1;
                    }

                    StringBuilder sb = new StringBuilder(key);
                    sb.Remove(startIndex, length);

                    key = sb.ToString();
                    System.Console.WriteLine(key);
                    break;
            }
        }

        System.Console.WriteLine($"Your activation key is: {key}");
    }
}
