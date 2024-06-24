using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string input;
            while ((input = Console.ReadLine()) != "Beast!")
            {
                string type = input;

                try
                {
                    Animal animal = GetAnimalByType(type);

                    if (animal != null)
                    {
                        animals.Add(animal);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Animal GetAnimalByType(string type)
        {
            string[] parameters = Console.ReadLine().Split();

            string name = parameters[0];
            int age = int.Parse(parameters[1]);
            string gender = parameters[2];

            switch (type)
            {
                case "Cat":
                    return new Cat(name, age, gender);
                case "Tomcat":
                    return new Tomcat(name, age);
                case "Kitten":
                    return new Kitten(name, age);
                case "Dog":
                    return new Dog(name, age, gender);
                case "Frog":
                    return new Frog(name, age, gender);
            }

            return null;
        }
    }
}
