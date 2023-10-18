using System.Runtime.ExceptionServices;

namespace _04.ListOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split(" ");

            while (command[0] != "End")
            {
                if (command[0] == "Add")
                {
                    int number = int.Parse(command[1]);
                    numbers.Add(number);
                }
                else if (command[0] == "Insert")
                {
                    int index = int.Parse(command[2]);
                    bool canChange = index <= numbers.Count && index >= 0 ? true : false;

                    int number = int.Parse(command[1]);

                    if (canChange)
                    {
                        numbers.Insert(index, number);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (command[0] == "Remove")
                {
                    int index = int.Parse(command[1]);
                    bool canChange = index < numbers.Count && index >= 0 ? true : false;

                    if (canChange)
                    {
                        numbers.RemoveAt(index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (command[0] == "Shift") // Shift
                {
                    int count = int.Parse(command[2]);

                    if (command[1] == "left")
                    {
                        ShiftLeft(numbers, count);   
                    }
                    else if (command[1] == "right")// right
                    {
                        ShiftRight(numbers, count);
                    }
                }

                command = Console.ReadLine().Split(" ");
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        static void ShiftLeft(List<int> numbers, int count)
        {
            for (int i = 0; i < count; i++)
            {
                numbers.Add(numbers[0]);
                numbers.RemoveAt(0);
            }
        }

        static void ShiftRight(List<int> numbers, int count)
        {
            for (int i = 0; i < count; i++)
            {
                numbers.Insert(0, numbers[numbers.Count - 1]);
                numbers.RemoveAt(numbers.Count - 1);
            }
        }
    }
}