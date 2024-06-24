namespace _02.BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            int enqueueCount = int.Parse(input[0]);
            int dequeueCount = int.Parse(input[1]);
            int searchElement = int.Parse(input[2]);

            input = Console.ReadLine().Split();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < enqueueCount; i++) // Push to stack
            {
                queue.Enqueue(int.Parse(input[i]));
            }

            for (int i = 0; i < dequeueCount; i++) // Pop from stack
            {
                if (queue.Count > 0)
                    queue.Dequeue();
            }


            Queue<int> searchQueue = new Queue<int>(queue);
            while (searchQueue.Count > 0) // Search for element
            {
                int element = searchQueue.Dequeue();

                if (element == searchElement)
                {
                    Console.WriteLine("true");
                    return;
                }
            }

            if (queue.Count > 0)
            {
                int smallestElement = queue.Dequeue();
                while (queue.Count > 0) // Get smallest element
                {
                    int element = queue.Dequeue();

                    if (element < smallestElement)
                    {
                        smallestElement = element;
                    }
                }

                Console.WriteLine(smallestElement);
                return;
            }

            Console.WriteLine(0);
        }
    }
}
