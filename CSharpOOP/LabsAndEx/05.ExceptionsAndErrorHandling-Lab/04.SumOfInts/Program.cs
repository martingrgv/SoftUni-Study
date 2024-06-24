﻿namespace SumOfInts;

public class Program
{
    public static void Main(string[] args)
    {
        int sum = 0;
        string[] data = Console.ReadLine()
                                .Split(' ');

        foreach (var element in data)
        {
            try
            {
                sum += int.Parse(element);
            }
            catch (FormatException)
            {
                Console.WriteLine($"The element '{element}' is in wrong format!");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The element '{element}' is out of range!");
            }
            finally
            {
                Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
            }
        }

        Console.WriteLine($"The total sum of all integers is: {sum}");
    }
}