namespace CustomTuples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] inArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var nameAddress = new CustomTuple<string, string>();
            nameAddress.Item1 = inArgs[0] + ' ' + inArgs[1];
            nameAddress.Item2 = inArgs[2];


            input = Console.ReadLine();
            inArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var nameBeer = new CustomTuple<string, int>();
            nameBeer.Item1 = inArgs[0];
            nameBeer.Item2 = int.Parse(inArgs[1]);

            input = Console.ReadLine();
            inArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var intDouble = new CustomTuple<int, double>();
            intDouble.Item1 = int.Parse(inArgs[0]);
            intDouble.Item2 = double.Parse(inArgs[1]);

            Console.WriteLine($"{nameAddress.Item1} -> {nameAddress.Item2}");
            Console.WriteLine($"{nameBeer.Item1} -> {nameBeer.Item2}");
            Console.WriteLine($"{intDouble.Item1} -> {intDouble.Item2}");
        }
    }
}
