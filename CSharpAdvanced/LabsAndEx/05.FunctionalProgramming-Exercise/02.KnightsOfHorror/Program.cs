namespace _02.KnightsOfHorror
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                             .Split(' ',
                             StringSplitOptions.RemoveEmptyEntries);

            Func<string, string> appender = s => s = "Sir " + s;
            Action<string> printer = s => Console.WriteLine(s);

            for (int i = 0; i < names.Length; i++)
            {
                string name = names[i];

                printer(appender(name));
            }
        }
    }
}
