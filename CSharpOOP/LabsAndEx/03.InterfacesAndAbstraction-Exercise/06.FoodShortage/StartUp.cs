using System.IO.Pipes;
using System.Xml.Schema;
using FoodShortage.Interfaces;
using FoodShortage.Models;

namespace FoodShortage;
public class StartUp
{
    static void Main(string[] args)
    {
        List<Person> people = GetPeople();
        
        while (ManageFood(people));
        Console.WriteLine(people.Sum(p => p.Food));
    }

    private static List<Person> GetPeople()
    {
        int peopleCount = int.Parse(Console.ReadLine());
        List<Person> people = new List<Person>();       

        for (int i = 0; i < peopleCount; i++)
        {
            string[] personData = Console.ReadLine()
                                  .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (personData.Length == 4)
            {
                people.Add(new Citizen(personData[0], int.Parse(personData[1]), personData[2], DateOnly.ParseExact(personData[3], "dd/MM/yyyy")));
            }
            else
            {
                people.Add(new Rebel(personData[0], int.Parse(personData[1]), personData[2]));
            }
        }

        return people;
    }

    private static bool ManageFood(List<Person> people)
    {
        string input = Console.ReadLine();

        if (input == "End")
        {
            return false;
        }
        
        string name = input;
        Person person = people.FirstOrDefault(p => p.Name == name);

        if (person != null)
        {
            person.BuyFood();
        }

        return true;
    }
}