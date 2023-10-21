using System.Net;
using System.Reflection.PortableExecutable;

namespace _03.MemoryGame;

class Program
{
    static void Main(string[] args)
    {
        List<string> elements = Console.ReadLine()
                             .Split(" ")
                             .ToList();
        string[] command = Console.ReadLine().Split(" ");

        int turnsCount = 0;

        while (command[0] != "end" && elements.Count > 0)
        {
            int firstIndex = int.Parse(command[0]);
            int secondIndex = int.Parse(command[1]);

            if (firstIndex == secondIndex
                || firstIndex < 0
                || firstIndex >= elements.Count
                || secondIndex < 0
                || secondIndex >= elements.Count)
            {
                HandleCheat(turnsCount, elements);
            }
            else if (elements[firstIndex] == elements[secondIndex])
            {
                string element = elements[firstIndex];
                System.Console.WriteLine($"Congrats! You have found matching elements - {element}!");

                elements.RemoveAt(firstIndex);

                if (secondIndex > 0)
                {
                    elements.RemoveAt(secondIndex - 1);
                }
                else
                {
                    elements.RemoveAt(secondIndex);
                }
            }
            else if (elements[firstIndex] != elements[secondIndex])
            {
                System.Console.WriteLine("Try again!");
            }

            turnsCount++;
            command = Console.ReadLine().Split(" ");
        }

        if (elements.Count == 0)
        {
            System.Console.WriteLine($"You have won in {turnsCount} turns!");
        }
        else
        {
            System.Console.WriteLine("Sorry you lose :(");
            System.Console.WriteLine(String.Join(" ", elements));
        }
    }

    static void HandleCheat(int count, List<string> elements)
    {
        elements.Insert(elements.Count / 2, $"-{count + 1}a");
        elements.Insert((elements.Count / 2) + 1, $"-{count + 1}a");

        System.Console.WriteLine("Invalid input! Adding additional elements to the board");
    }
}
