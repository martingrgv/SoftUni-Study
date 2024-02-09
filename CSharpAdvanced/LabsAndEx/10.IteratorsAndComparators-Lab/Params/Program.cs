namespace Params
{
    public class Program
    {
        static void Main(string[] args)
        {
            PrintNames(new string[] { "String", "Arr" });
            Console.WriteLine();
            PrintNames("Sending", "params", "in", "method");
        }

        // params keywords allows passing multiple arguments and stores them into an array
        private static void PrintNames(params string[] arr)
        {
            foreach (var str in arr)
                Console.Write(str + " ");
        }
    }
}
