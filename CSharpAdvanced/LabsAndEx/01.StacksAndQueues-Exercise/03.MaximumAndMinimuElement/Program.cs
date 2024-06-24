namespace _03.MaximumAndMinimuElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int[] query = Console.ReadLine().Split().Select(int.Parse).ToArray();

                switch (query[0])
                {
                    case 1:
                        stack.Push(query[1]);
                        break;
                    case 2:
                        if (stack.Count > 0)
                            stack.Pop();
                        break;
                    case 3: // Max
                        if (stack.Count > 0)
                        {
                            Stack<int> maxSearch = new Stack<int>(stack);

                            int num = maxSearch.Pop();
                            while (maxSearch.Count > 0)
                            {
                                int popNum = maxSearch.Pop();
                                if (popNum > num)
                                {
                                    num = popNum;
                                }
                            }

                            Console.WriteLine(num);
                        }
                        break;
                    case 4: // Min
                        if (stack.Count > 0)
                        {
                            Stack<int> minSearch = new Stack<int>(stack);

                            int num = minSearch.Pop();
                            while (minSearch.Count > 0)
                            {
                                int popNum = minSearch.Pop();
                                if (popNum < num)
                                {
                                    num = popNum;
                                }
                            }

                            Console.WriteLine(num);
                        }
                        break;
                }
            }

            if (stack.Count > 0)
            {
                while (stack.Count > 1)
                {
                    Console.Write(stack.Pop() + ", ");
                }

                Console.Write(stack.Pop());
            }
        }

    }
}
