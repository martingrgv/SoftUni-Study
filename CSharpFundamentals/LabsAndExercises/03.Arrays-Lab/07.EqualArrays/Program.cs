namespace _07.EqualArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] numbers2 = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            if (Enumerable.SequenceEqual(numbers, numbers2))
            {
                int sum = 0;
                Array.ForEach(numbers, num => sum += num);

                Console.WriteLine("Arrays are identical. Sum: " + sum);
            }
            else
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] != numbers2[i])
                    {
                        Console.WriteLine("Arrays are not identical. Found difference at {0} index", i);
                        break;
                    }
                }
            }
        }
    }
}