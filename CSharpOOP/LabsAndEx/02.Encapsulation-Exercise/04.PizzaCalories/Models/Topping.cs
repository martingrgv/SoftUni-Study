namespace PizzaCalories.Models
{
    public class Topping
    {
        private ToppingType type;
        private double grams;

        private double typeCalories;

        public ToppingType Type
        {
            get { return type; }
            private set
            {
                switch (value)
                {
                    case ToppingType.Meat:
                        typeCalories = 1.2;
                        break;
                    case ToppingType.Veggies:
                        typeCalories = 0.8;
                        break;
                    case ToppingType.Cheese:
                        typeCalories = 1.1;
                        break;
                    case ToppingType.Sauce:
                        typeCalories = 0.9;
                        break;
                    default:
                        throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                type = value;
            }
        }

        public double Grams
        {
            get { return grams; }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }

                grams = value;
            }
        }

        public double Calories
        {
            get
            {
                return Grams * typeCalories;
            }
        }
    }
}
