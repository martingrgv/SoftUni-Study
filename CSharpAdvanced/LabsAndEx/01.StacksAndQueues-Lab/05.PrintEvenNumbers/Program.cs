namespace _05.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(numbers);

            int number;

            while (queue.Count > 1)
            {
                number = queue.Dequeue();

                if (number % 2 == 0)
                {
                    Console.Write(number + ", ");
                }
            }

            number = queue.Dequeue();

            if (number % 2 == 0)
            {
                Console.Write(number);
            }
        }
    }
}
