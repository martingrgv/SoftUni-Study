using System.Threading.Channels;

namespace _05.BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                       .Split(" ")
                                       .Select(int.Parse)
                                       .ToList();
            int[] bombNumbers = Console.ReadLine()
                                       .Split(" ")
                                       .Select(int.Parse)
                                       .ToArray();

            int specialNumber = bombNumbers[0];
            int powerNumber = bombNumbers[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == specialNumber)
                {
                    for (int j = 0; j < powerNumber; j++)
                    {
                        int leftIndex = i - 1;

                        if (leftIndex == 0)
                        {
                            numbers.RemoveAt(0);
                            i--;
                            break;
                        }
                        else if (leftIndex < 0)
                        {
                            break;
                        }
                        else if (leftIndex > 0)
                        {
                            numbers.RemoveAt(leftIndex);
                            i--;
                        }

                    }

                    for (int j = 0; j < powerNumber; j++)
                    {
                        int rightIndex = i + 1;

                        if (rightIndex == numbers.Count - 1)
                        {
                            numbers.RemoveAt(rightIndex);
                            break;
                        }
                        else if (rightIndex > numbers.Count - 1)
                        {
                            break;
                        }
                        else if (rightIndex < numbers.Count - 1)
                        {
                            numbers.RemoveAt(rightIndex);
                        }

                        numbers.RemoveAt(specialNumber);
                        i = -1;
                    }
                }
            }

            int sum = 0;
            numbers.ForEach(n => sum += n);
            Console.WriteLine(sum);
        }
    }
}