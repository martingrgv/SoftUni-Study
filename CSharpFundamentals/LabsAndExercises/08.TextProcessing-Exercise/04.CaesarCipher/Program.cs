namespace _04.CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string encryptedMessage = string.Empty;

            foreach (char ch in input)
            {
                encryptedMessage += SwitchChar(ch);
            }

            Console.WriteLine(encryptedMessage);
        }

        static char SwitchChar(char ch)
        {
            return (char)(ch + 3);
        }
    }
}