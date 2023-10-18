namespace _02.ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split(" ");

            while (command[0] != "end")
            {
                if (command[0] == "Delete")
                {
                    int number = int.Parse(command[1]);
                    Delete(numbers, number);
                }
                else // Insert
                {
                    int number = int.Parse(command[1]);
                    int index = int.Parse(command[2]);
                    numbers.Insert(index, number);
                }

                command = Console.ReadLine().Split(" ");
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        static void Delete(List<int> numbers, int number)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == number)
                {
                    numbers.RemoveAt(i);
                }
            }
        }
    }
}