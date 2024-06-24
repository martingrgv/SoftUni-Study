using System.Numerics;
using System.Text;

namespace _01.TheImitationGame
{
    internal class Program
    {
        static string message;
        static void Main(string[] args)
        {
            message = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "Decode")
            {
                string[] inArgs = input.Split("|");
                string command = inArgs[0];

                switch (command)
                {
                    case "Move":
                        int count = int.Parse(inArgs[1]);
                        Move(count);
                        break;
                    case "Insert":
                        int index = int.Parse(inArgs[1]);
                        string value = inArgs[2];
                        Insert(index, value);
                        break;
                    case "ChangeAll":
                        string substring = inArgs[1];
                        string replacement = inArgs[2];
                        ChangeAll(substring, replacement);
                        break;
                }
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }

        static void Move(int lettersCount)
        {
            for (int i = 0; i < lettersCount; i++)
            {
                message += message[i];
            }

            message = message.Remove(0, lettersCount);
        }
        
        static void Insert(int index, string value)
        {
            message = message.Insert(index, value);
        }

        static void ChangeAll(string substring, string replacement)
        {
            message = message.Replace(substring, replacement);
        }
    }
}