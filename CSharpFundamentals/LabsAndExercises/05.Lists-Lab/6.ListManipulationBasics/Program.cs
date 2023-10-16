namespace _6.ListManipulationBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            string[] userInput = Console.ReadLine().Split(" ");

            while (userInput[0] != "end")
            {
                if (userInput[0] == "Add")
                {
                    int number = int.Parse(userInput[1]);
                    numbers.Add(number);
                }
                else if (userInput[0] == "Remove")
                {
                    int number = int.Parse(userInput[1]);
                    numbers.Remove(number);
                }
                else if (userInput[0] == "RemoveAt")
                {
                    int index = int.Parse(userInput[1]);
                    numbers.RemoveAt(index);
                }
                else if (userInput[0] == "Insert")
                {
                    int number = int.Parse(userInput[1]);
                    int index = int.Parse(userInput[2]);
                    numbers.Insert(index, number);
                }


                userInput = Console.ReadLine().Split(" ");
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}