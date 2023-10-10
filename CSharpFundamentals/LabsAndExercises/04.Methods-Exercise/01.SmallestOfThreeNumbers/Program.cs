namespace _01.SmallestOfThreeNumbers;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = new int[3];
        ReadInput(numbers);

        int lowestNum = GetLowestInt(numbers);
        Console.WriteLine(lowestNum);
    }

    static void ReadInput(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }
    }

    static int GetLowestInt(int[] numbers)
    {
        int lowestNum = numbers[0];
        
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < lowestNum)
            {
                lowestNum = numbers[i];
            }
        }

        return lowestNum;
    }
}