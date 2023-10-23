namespace _01.RandomizeWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                                .Split(" ");
            Random rnd = new();
            
            for (int pos1 = 0; pos1 < words.Length; pos1++)
            {
                int pos2 = rnd.Next(0, words.Length);
                string temp = words[pos1];

                words[pos1] = words[pos2];
                words[pos2] = temp;
            }

            Console.WriteLine(String.Join(Environment.NewLine, words));
        }
    }
}