using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace _02.ArrayModifier;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine()
                        .Split(" ")
                        .Select(int.Parse)
                        .ToArray();

        ArrayModifier arrayModifier = new ArrayModifier(numbers);
        string[] command = Console.ReadLine().Split(" ");

        while (command[0] != "end")
        {
            switch(command[0])
            {
                case "swap":
                    int index1 = int.Parse(command[1]);
                    int index2 = int.Parse(command[2]);
                    arrayModifier.Swap(index1, index2);
                    break;
                case "multiply":
                    index1 = int.Parse(command[1]);
                    index2 = int.Parse(command[2]);
                    arrayModifier.Multiply(index1, index2);
                    break;
                case "decrease":
                    arrayModifier.DecreaseArray();
                    break;
            }

            command = Console.ReadLine().Split(" ");
        }

        Console.WriteLine(string.Join(", ", arrayModifier.GetArray()));
    }
}

class ArrayModifier
{
    int[] arr;
    public int[] GetArray() => arr;

    public ArrayModifier(int[] arr)
    {
        this.arr = arr;
    }

    public void Swap(int index1, int index2)
    {
        int staticIndexNumber = arr[index1];

        arr[index1] = arr[index2];
        arr[index2] = staticIndexNumber;
    }

    public void Multiply(int index1, int index2)
    {
        arr[index1] = arr[index1] * arr[index2];
    }

    public void DecreaseArray()
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i]--;
        }
    }
}
