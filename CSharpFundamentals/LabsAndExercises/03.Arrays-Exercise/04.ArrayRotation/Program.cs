using System.Globalization;

namespace _04.ArrayRotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            // Rotate array
            arr = RotateArray(arr, rotations);

            // Print array
            Console.WriteLine(GetArrayElements(arr));
        }

        static int[] RotateArray(int[] arr, int rotations = 1)
        {
            for (int i = 0; i < rotations; i++)
            {
                int firstElement = arr[0];

                for (int j = 0; j < arr.Length - 1; j++)
                {
                    arr[j] = arr[j + 1];
                }

                arr[arr.Length - 1] = firstElement;
            }

            return arr;
        }

        static string GetArrayElements(int[] arr)
        {
            return String.Join(" ", arr);
        }
    }
}