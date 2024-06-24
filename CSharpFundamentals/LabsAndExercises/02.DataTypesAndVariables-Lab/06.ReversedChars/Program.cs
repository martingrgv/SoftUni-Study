namespace _06.ReversedChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] collectionOfChars = new char[3];
            for (int i = 0; i < 3; i++) // Add chars to array
            {
                collectionOfChars[i] = char.Parse(Console.ReadLine());
            }

            Array.Reverse(collectionOfChars);
            foreach (char letter in collectionOfChars) // Print reversed array
            {
                Console.Write(letter + " ");
            }
        }
    }
}