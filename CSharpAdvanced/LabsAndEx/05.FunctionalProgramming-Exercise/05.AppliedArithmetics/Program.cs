namespace _05.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToArray();

            Func<int, int> act = n => n;
            Action<int[]> print = n => Console.WriteLine(string.Join(' ', n));

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        act = n => ++n;                       
                        break;
                    case "subtract":
                        act = n => --n;                       
                        break;
                    case "multiply":
                        act = n => n * 2;
                        break;
                    case "print":
                        print(numbers);
                        continue;
                }

                numbers = numbers.Select(n => act(n)).ToArray();
            }
        }
    }
}
