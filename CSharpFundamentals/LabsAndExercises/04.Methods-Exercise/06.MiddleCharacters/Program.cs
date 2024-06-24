namespace _06.MiddleCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] middleChars = GetMiddleChar(input);

            foreach (char ch in middleChars)
            {
                Console.Write(ch);
            }
        }

        static char[] GetMiddleChar(string s)
        {
            if (s.Length % 2 == 0) // Is even
            {
                char[] arr = new char[2];

                arr[0] = s[s.Length / 2 - 1];
                arr[1] = s[s.Length / 2];

                return arr;
            }
            else // Is odd
            {
                char[] arr = new char[1];

                arr[0] = s[s.Length / 2];

                return arr;
            }
        }
    }
}