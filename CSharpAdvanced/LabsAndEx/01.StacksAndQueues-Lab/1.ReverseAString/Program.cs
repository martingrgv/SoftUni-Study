namespace _1.ReverseAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            // Add to stack
            foreach (var ch in input)
            {
                stack.Push(ch);
            }

            // Read stack
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }    
        }
    }
}
