namespace _06.Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> people = new Queue<string>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid")
                {
                    RemovePeople(people);
                }
                else // Add person to queue
                {
                    people.Enqueue(input);
                }
            }

            Console.WriteLine(people.Count + " people remaining.");
        }

        static void RemovePeople(Queue<string> people)
        {
            while (people.Count > 0)
            {
                Console.WriteLine(people.Dequeue());
            }
        }
    }
}
