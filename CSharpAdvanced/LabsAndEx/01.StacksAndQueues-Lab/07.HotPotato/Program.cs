namespace _07.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split().ToArray();
            int n = int.Parse(Console.ReadLine());

            Queue<string> children = new Queue<string>(names);

            while (children.Count > 1)
            {
                for (int i = 1; i < n; i++)
                {
                    string currentChild = children.Dequeue();
                    children.Enqueue(currentChild);
                }

                Console.WriteLine("Removed " + children.Dequeue());
            }

            Console.WriteLine("Last is " + children.Dequeue());
        }
    }
}
