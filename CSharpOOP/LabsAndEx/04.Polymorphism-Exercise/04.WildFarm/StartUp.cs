using WildFarm.Models;

namespace WildFarm;

public class StartUp
{
    public static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();
        
        string input; 
        while ((input = Console.ReadLine()) != "End")
        {
            Animal animal = GetAnimal(input);

            input = Console.ReadLine();
            if (input == "End")
                break;

            Food food = GetFood(input);

            if (animal == null)
            {
                continue;
            }
            
            Console.WriteLine(animal.ProduceSound());
            
            try
            {
                animal.Eat(food);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            animals.Add(animal);
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }

    private static Animal GetAnimal(string input)
    {
        string[] animalData = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        switch (animalData[0]) // Type
        {
            case "Hen":
                return new Hen(animalData[1], double.Parse(animalData[2]), double.Parse(animalData[3]));
            case "Owl":
                return new Owl(animalData[1], double.Parse(animalData[2]), double.Parse(animalData[3]));
            case "Mouse":
                return new Mouse(animalData[1], double.Parse(animalData[2]), animalData[3]);
            case "Cat":
                return new Cat(animalData[1], double.Parse(animalData[2]), animalData[3], animalData[4]);
            case "Dog":
                return new Dog(animalData[1], double.Parse(animalData[2]), animalData[3]);
            case "Tiger":
                return new Tiger(animalData[1], double.Parse(animalData[2]), animalData[3], animalData[4]);
            default:
                return null;
        }
    }

    private static Food GetFood(string input)
    {
        string[] foodData = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        switch (foodData[0]) // Type
        {
            case "Vegetable":
                return new Vegetable(int.Parse(foodData[1]));
            case "Fruit":
                return new Fruit(int.Parse(foodData[1]));
            case "Meat":
                return new Meat(int.Parse(foodData[1]));
            case "Seeds":
                return new Seeds(int.Parse(foodData[1]));
            default:
                return null;
        }
    }
}