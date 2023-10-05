namespace _03.Zig_ZagArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr1 = new int[n];
            int[] arr2 = new int[n];

            // Write to array
            for (int i = 0; i < n; i++)
            {
                int[] currentArr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                if (i % 2 == 0) // Is not even
                {
                    arr1[i] = currentArr[0];
                    arr2[i] = currentArr[1];
                }
                else // Is even
                {
                    arr2[i] = currentArr[0];
                    arr1[i] = currentArr[1];
                }
            }

            // Read array
            foreach (int num in arr1)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            foreach (int num in arr2)
            {
                Console.Write(num + " ");
            }
        }
    }
}