namespace Catch;

public class ManipulativeIntArray
{
    private int[] numbers;
    private ArgumentException outOfRangeException = new ArgumentException("The index does not exist!");

    public ManipulativeIntArray(int[] intArray)
    {
        numbers = intArray;
    }

    public void Replace(int index, int number)
    {
        try
        {
            numbers[index] = number;
        }
        catch (IndexOutOfRangeException ex)
        {
            throw outOfRangeException;
        }
    }

    public void Show(int index)
    {
        try
        {
            Console.WriteLine(numbers[index]);
        }
        catch (IndexOutOfRangeException ex)
        {
            throw outOfRangeException;
        }
    }

    public void Print(int startIndex, int endIndex)
    {
        if (startIndex < 0 || endIndex > numbers.Length - 1)
        {
            throw outOfRangeException;
        }

        for (int i = startIndex; i < endIndex; i++)
        {
            Console.Write(numbers[i] + ", ");
        }
        
        Console.WriteLine(numbers[endIndex]);
    }

    public override string ToString()
    {
        return string.Join(", ", numbers);
    }
}