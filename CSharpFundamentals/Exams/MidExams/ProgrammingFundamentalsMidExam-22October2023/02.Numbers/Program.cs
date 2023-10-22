using System.Data;

namespace _02.Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                .Split(" ")
                                .Select(int.Parse)
                                .ToList();
            string[] command = Console.ReadLine().Split(" ");

            while (command[0] != "Finish")
            {
                if (command[0] == "Add")
                {
                    int value = int.Parse(command[1]);
                    numbers.Add(value);
                }
                else if (command[0] == "Remove")
                {
                    int value = int.Parse(command[1]);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] == value)
                        {
                            numbers.RemoveAt(i);
                            break;
                        }
                    }
                }
                else if (command[0] == "Replace")
                {
                    int value = int.Parse(command[1]);
                    int replacement = int.Parse(command[2]);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] == value)
                        {
                            numbers[i] = replacement;
                            break;
                        }
                    }
                }
                else if (command[0] == "Collapse")
                {
                    int value = int.Parse(command[1]);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] < value)
                        {
                            numbers.RemoveAt(i);
                            i--;
                        }
                    }
                }

                command = Console.ReadLine().Split(" ");
            }

            Console.WriteLine(String.Join(' ', numbers));
        }
    }
}