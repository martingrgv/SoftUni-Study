namespace _01.ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strCollection = Console.ReadLine()
                                     .Split(' ',
                                     StringSplitOptions.RemoveEmptyEntries);

            Action<string> printer = s => Console.WriteLine(s);

            foreach (var str in strCollection)
            {
                printer(str);
            }
        }
    }
}
