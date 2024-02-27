using PizzaCalories.Models;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dough dough = new Dough();

            try
            {
                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    dough = GetDough(input);
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
            BakingTechnique? bakingTechnique = GetBakingTechnique(doughData[2]);
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
        
        private static BakingTechnique? GetBakingTechnique(string techniqueName)
        {
            switch(techniqueName)
            {
                case "Crispy":
                    return BakingTechnique.Crispy;
                case "Chewy":
                    return BakingTechnique.Chewy;
                case "Homemade":
                    return BakingTechnique.Homemade;
                default:
                    return null;
            }
        }
    }
}
