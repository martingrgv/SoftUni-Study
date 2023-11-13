namespace _02.CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string firstWord = input[0];
            string lastWord = input[1];

            int sum = Sum(firstWord, lastWord);

            Console.WriteLine(sum);
        }

        private static int Sum(string firstWord, string lastWord)
        {
            int fLength = firstWord.Length;
            int lLength = lastWord.Length;
            int length = Math.Max(firstWord.Length, lastWord.Length);

            int sum = 0;

            for (int i = 0; i < length; i++)
            {
                if (i >= fLength) { sum += lastWord[i]; } else
                if (i >= lLength) { sum += firstWord[i]; }
                else { sum += firstWord[i] * lastWord[i]; }
            }

            return sum;
        }
    }
}