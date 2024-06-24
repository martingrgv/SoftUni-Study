namespace _04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] orderQuantity = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> orders = new Queue<int>(orderQuantity);

            int biggestOrder = 0;

            while (orders.Count > 0)
            {
                int firstOrder = orders.Peek();

                if (biggestOrder < firstOrder) // Get biggest order
                {
                    biggestOrder = firstOrder;
                }

                if (foodQuantity - firstOrder >= 0) // Serve customer
                {
                    int order = orders.Dequeue();
                    foodQuantity -= order;
                }
                else
                {
                    Console.WriteLine(biggestOrder);
                    Console.Write("Orders left: ");

                    while (orders.Count > 0)
                    {
                        Console.Write(orders.Dequeue() + " ");
                    }

                    return;
                }
            }

            Console.WriteLine(biggestOrder);
            Console.WriteLine("Orders complete");
        }
    }
}
