namespace GenericBoxOfInt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var box = new Box<int>();

            for (int i = 0; i < lines; i++)
                box.Add(int.Parse(Console.ReadLine()));

            Console.WriteLine(box.ToString());
        }
    }
}
