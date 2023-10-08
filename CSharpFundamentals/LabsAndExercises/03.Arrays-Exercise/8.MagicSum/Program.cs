using System.Diagnostics.Tracing;
using System.Security.Cryptography;

namespace _8.MagicSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Read from console
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int sumNum = int.Parse(Console.ReadLine());

            // 4. Print the pairs that equal to the sum
            GetSums(numbers, sumNum);
        }

        static void GetSums(int[] inArr, int sumNumber)
        {
            int[,] outArr = new int[inArr.Length, 2];
            int insertRowCount = 0;
            int insertColumnCount = 0;

            // 2. Loop through array
            for (int i = 0; i < inArr.Length; i++)
            {
                // 3. Get integer sums with nested loops
                for (int j = i + 1; j < inArr.Length; j++)
                {
                    if (inArr[i] + inArr[j] == sumNumber)
                    {
                        outArr[insertRowCount, insertColumnCount] = inArr[i];

                        insertColumnCount = 1;
                        outArr[insertRowCount, insertColumnCount] = inArr[j];

                        insertColumnCount = 0;
                        insertRowCount++;
                    }
                }
            }

            ReadSumsArray(outArr, insertRowCount);
        }

        static void ReadSumsArray(int[,] arr, int insertedRows = 0)
        {
            for (int i = 0; i < insertedRows; i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}