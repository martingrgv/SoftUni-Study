namespace _04.ReverseArrayOfStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split(" ").ToArray();

            foreach (var element in arr.Reverse())
            {
                Console.Write(element + " ");
            }
        }
    }
}