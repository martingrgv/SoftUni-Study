using System.Security.Cryptography;

namespace _7.ListManipulationAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split(" ");

            bool listChanged = false;

            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    int number = int.Parse(command[1]);
                    numbers.Add(number);

                    listChanged = true;
                }
                else if (command[0] == "Remove")
                {
                    int number = int.Parse(command[1]);
                    numbers.Remove(number);

                    listChanged = true;
                }
                else if (command[0] == "RemoveAt")
                {
                    int index = int.Parse(command[1]);
                    numbers.RemoveAt(index);

                    listChanged = true;
                }
                else if (command[0] == "Insert")
                {
                    int number = int.Parse(command[1]);
                    int index = int.Parse(command[2]);
                    numbers.Insert(index, number);

                    listChanged = true;
                }
                else if (command[0] == "Contains")
                {
                    int number = int.Parse(command[1]);
                    
                    if (numbers.Contains(number))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (command[0] == "PrintEven")
                {
                    List<int> evenNumbers = new List<int>();

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] % 2 == 0)
                        {
                            evenNumbers.Add(numbers[i]);
                        }
                    }

                    Console.WriteLine(string.Join(" ", evenNumbers));
                }
                else if (command[0] == "PrintOdd")
                {
                    List<int> oddNumbers = new List<int>();

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] % 2 != 0)
                        {
                            oddNumbers.Add(numbers[i]);
                        }
                    }

                    Console.WriteLine(string.Join(" ", oddNumbers));
                }
                else if (command[0] == "GetSum")
                {
                    int sum = 0;

                    foreach (int num in numbers)
                    {
                        sum += num;
                    }

                    Console.WriteLine(sum);
                }
                else if (command[0] == "Filter") 
                {
                    List<int> conditionNumbers = new List<int>();

                    string @operator = command[1];
                    int conditionNumber = int.Parse(command[2]);

                    foreach (int num in numbers)
                    {
                        bool isConditionTrue = GetCondition(num, @operator, conditionNumber);

                        if (isConditionTrue)
                        {
                            conditionNumbers.Add(num);
                        }
                    }

                    Console.WriteLine(string.Join(" ", conditionNumbers));
                }

                command = Console.ReadLine().Split(" ");
            }

            if (listChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        static bool GetCondition(int currentNum, string @operator, int conditionNum)
        {
            if (@operator == "<")
            {
                return currentNum < conditionNum;
            }
            else if (@operator == ">")
            {
                return currentNum > conditionNum;
            }
            else if (@operator == ">=")
            {
                return currentNum >= conditionNum;
            }
            else if (@operator == "<=")
            {
                return currentNum <= conditionNum;
            }
            else
            {
                return false;
            }
        }
    }
}