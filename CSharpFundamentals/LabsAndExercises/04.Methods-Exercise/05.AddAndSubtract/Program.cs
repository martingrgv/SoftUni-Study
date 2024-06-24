using System.Linq.Expressions;

namespace _05.AddAndSubtract;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = GetNumbers();

        int sum = AddFirstNumbers(numbers[0], numbers[1]);
        int result = SubtractLastNumbers(sum, numbers[2]);

        Console.WriteLine(result);
    }

    static int[] GetNumbers()
    {
        int[] numbers = new int[3];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        return numbers;
    }

    static int AddFirstNumbers(int fNum, int sNum) => fNum + sNum;

    static int SubtractLastNumbers(int sum, int lNum) => sum - lNum;
}
