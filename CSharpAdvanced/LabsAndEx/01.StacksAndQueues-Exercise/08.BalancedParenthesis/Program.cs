namespace _08.BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] sequence = Console.ReadLine().ToCharArray();

            if (sequence.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            Stack<char> charStack = new Stack<char>();

            foreach (char ch in sequence)
            {
                if ("{([".Contains(ch)) // Opening
                {
                    charStack.Push(ch);
                }
                else if (ch == ')' && charStack.Peek() == '(')
                {
                    charStack.Pop();
                }
                else if (ch == ']' && charStack.Peek() == '[')
                {
                    charStack.Pop();
                }
                else if (ch == '}' && charStack.Peek() == '{')
                {
                    charStack.Pop();
                }
            }

            Console.WriteLine(charStack.Any() ? "NO" : "YES");
        }
    }
}
