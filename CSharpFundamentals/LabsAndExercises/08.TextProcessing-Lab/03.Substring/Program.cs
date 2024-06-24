namespace _03.Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordToRemove = Console.ReadLine();
            string sentance = Console.ReadLine();

            while (sentance.Contains(wordToRemove))
                sentance = sentance.Replace(wordToRemove, "");

            Console.WriteLine(sentance);
        }
    }
}