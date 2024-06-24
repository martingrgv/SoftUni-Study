using PizzaCalories;

namespace PizzaCalories.Models
{
    public class Dough
    {
        private Flour? flourType;
        private PizzaTechnique? bakingTechnique;
        private double grams;

        private double flourCalories;
        private double bakingCalories;

        public Dough()
        {
            // Empty constructor
        }

        public Dough(Flour? flourType, PizzaTechnique? bakingTechnique, double grams)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }

        public Flour? FlourType
        {
            get { return flourType; }
            private set
            {
                switch (value)
                {
                    case Flour.White:
                        flourCalories = 1.5;
                        break;
                    case Flour.Wholegrain:
                        flourCalories = 1;
                        break;
                    default:
                        throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value;
            }
        }

        public PizzaTechnique? BakingTechnique
        {
            get { return bakingTechnique; }
            private set
            {
                switch (value)
                {
                    case PizzaTechnique.Crispy:
                        bakingCalories = 0.9;
                        break;
                    case PizzaTechnique.Chewy:
                        bakingCalories = 1.1;
                        break;
                    case PizzaTechnique.Homemade:
                        bakingCalories = 1;
                        break;
                    default:
                        throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value;
            }
        }

        public double Grams
        {
            get { return grams; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                grams = value;
            }
        }

        public double Calories 
        {
            get
            {
                return (2 * Grams) * flourCalories * bakingCalories;
            }
        }

    }
}
