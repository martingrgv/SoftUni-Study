namespace _04.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            var openingBracketIndexes = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    openingBracketIndexes.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int startIndex = openingBracketIndexes.Pop();
                    int endIndex = i;

                    string substring = expression.Substring(startIndex, endIndex - startIndex + 1);
                    Console.WriteLine(substring);
                }
            }
        }
    }
}
