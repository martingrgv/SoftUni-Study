namespace GenericBoxOfString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var box = new Box<string>();

            for (int i = 0; i < lines; i++)
                box.Add(Console.ReadLine());

            Console.WriteLine(box.ToString());
        }
    }
}
