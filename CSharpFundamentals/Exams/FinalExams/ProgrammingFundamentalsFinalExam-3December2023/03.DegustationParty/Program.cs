namespace _03.DegustationParty;
class Program
{
    static List<Guest> guests = new List<Guest>();

    static void Main(string[] args)
    {
        string input;
        while ((input = Console.ReadLine()) != "Stop")
        {
            string[] inArgs = input.Split("-");

            string command = inArgs[0];
            string guestName = inArgs[1];
            string meal = inArgs[2];

            switch (command)
            {
                case "Like":
                    LikeMeal(guestName, meal);
                    break;
                case "Dislike":
                    DislikeMeal(guestName, meal);
                    break; 
            }
        }

        PrintOutput();
    }

    static void LikeMeal(string guestName, string meal)
    {
        Guest guest = new Guest();
        guest.Name = guestName;

        if (guests.Exists(g => g.Name == guest.Name)) // if guest exists
        {
            if (guests.Exists(g => g.likedMeals.Contains(meal))) // if guest has the meal already
                return;
            
            guest = guests.FirstOrDefault(g => g.Name == guest.Name); // add the meal
            guest.likedMeals.Add(meal);
        }
        else // if guest does not exist add it
        {
            guest.likedMeals.Add(meal);
            guests.Add(guest);
        }
    }

    static void DislikeMeal(string guestName, string meal)
    {
        Guest guest = new Guest();
        guest.Name = guestName;

        if (guests.Exists(g => g.Name == guest.Name)) // if guest exists
        {
            if (guests.Exists(g => g.likedMeals.Contains(meal))) // if guest has the meal
            {
                guest = guests.FirstOrDefault(g => g.Name == guest.Name);

                guest.likedMeals.Remove(meal);
                guest.unlikedMealsCount++;

                System.Console.WriteLine($"{guest.Name} doesn't like the {meal}.");
            }
            else
            {
                System.Console.WriteLine($"{guest.Name} doesn't have the {meal} in his/her collection.");
            }
        }
        else // if guest doesn't exist print output
        {
            System.Console.WriteLine($"{guest.Name} is not at the party.");
        }
    }

    static int GetUnlikedMeals()
    {
        int count = 0;
        guests.ForEach(g => count += g.unlikedMealsCount);
        return count;
    }

    static void PrintOutput()
    {
        foreach (Guest guest in guests)
        {
            System.Console.WriteLine($"{guest.Name}: {string.Join(", ", guest.likedMeals)}");
        }

        int unlikedMealsCount = GetUnlikedMeals();
        System.Console.WriteLine("Unliked meals: " + unlikedMealsCount);
    }
}
