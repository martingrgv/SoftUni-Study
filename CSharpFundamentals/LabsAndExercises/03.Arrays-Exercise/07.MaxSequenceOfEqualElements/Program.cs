using System.ComponentModel.Design;
using System.Diagnostics.Tracing;

namespace _07.MaxSequenceOfEqualElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int longestSequenceCount = 0;
            int longestSequenceNum = 0;

            int sequenceCount = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    sequenceCount++;
                    
                    if (sequenceCount > longestSequenceCount)
                    {
                        longestSequenceCount = sequenceCount;
                        longestSequenceNum = numbers[i];
                    }
                }
                else
                {
                    sequenceCount = 0;
                }
            }
            
            for (int i = 0; i <= longestSequenceCount; i++)
            {
                Console.Write(longestSequenceNum + " ");
            }
        }
    }
}