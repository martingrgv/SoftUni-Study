namespace PizzaCalories.Models
{
    public class Pizza
    {
        private Dough dough;
        private Topping topping;

        public Pizza(Dough dough, Topping topping)
        {
            Dough = dough;
            Topping = topping;
        }

        public Dough Dough { get; set; }
        public Topping Topping { get; set; }
    }
}
