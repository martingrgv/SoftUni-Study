using PizzaCalories.Models;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dough dough = new Dough();
            Topping topping = new Topping();

            try
            {
                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    dough = GetDough(input);
                    topping = GetTopping(input);
                }

                Console.WriteLine($"{dough.Calories:f2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static Dough GetDough(string input)
        {
            string[] doughData = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Flour? flour = GetFlour(doughData[1]);
            PizzaTechnique? bakingTechnique = GetBakingTechnique(doughData[2]);
            double grams = double.Parse(doughData[3]);

            return new Dough(flour, bakingTechnique, grams);
        }

        private static Flour? GetFlour(string flourName)
        {
            switch(flourName)
            {
                case "White":
                    return Flour.White;
                case "Wholegrain":
                    return Flour.Wholegrain;
                default:
                    return null;
            }
        }
        
        private static PizzaTechnique? GetBakingTechnique(string techniqueName)
        {
            switch(techniqueName)
            {
                case "Crispy":
                    return PizzaTechnique.Crispy;
                case "Chewy":
                    return PizzaTechnique.Chewy;
                case "Homemade":
                    return PizzaTechnique.Homemade;
                default:
                    return null;
            }
        }

        private static Topping GetTopping(string input)
        {
            string[] toppingData = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            ToppingType? toppingType = GetToppingType(toppingData[1]);
            PizzaTechnique? bakingTechnique = GetBakingTechnique(doughData[2]);
            double grams = double.Parse(doughData[3]);

            return new Dough(flour, bakingTechnique, grams);
        }

        private static ToppingType? GetToppingType()
        {

        }
    }
}
