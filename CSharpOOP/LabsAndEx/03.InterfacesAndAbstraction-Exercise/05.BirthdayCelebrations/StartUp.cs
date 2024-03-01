using Celebration.Interfaces;
using Celebration.Models;

namespace Celebration;
public class StartUp
{
    static void Main(string[] args)
    {
        List<ILiving> livingBeings = new List<ILiving>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] beingData = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string beingType = beingData[0];

            try
            {
                switch(beingType)
                {
                    case "Citizen":
                        livingBeings.Add(new Citizen(beingData[1], int.Parse(beingData[2]), beingData[3], DateOnly.ParseExact(beingData[4], "dd/MM/yyyy")));
                        break;
                    case "Pet":
                        livingBeings.Add(new Pet(beingData[1], DateOnly.ParseExact(beingData[2], "dd/MM/yyyy")));
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                continue;
            }
        }

        try
        {
            DateOnly searchDate = DateOnly.ParseExact(Console.ReadLine(), "yyyy");

            if (livingBeings.Any(b => b.Birthdate.Year == searchDate.Year))
            {
                foreach (var being in livingBeings)
                {
                    if (being.Birthdate.Year == searchDate.Year)
                    {
                        Console.WriteLine(being.Birthdate.ToString($"dd/MM/yyyy"));
                    }
                }
            }
            else
            {
                return;
            }
        }
        catch (Exception ex)
        {
            return;
        }
    }
}