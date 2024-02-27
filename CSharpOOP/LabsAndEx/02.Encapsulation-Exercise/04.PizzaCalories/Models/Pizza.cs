namespace PizzaCalories.Models
{
    public class Pizza
    {
        private Dough dough;

        public Pizza(Dough dough)
        {
            
        }

        public Dough Dough
        {
            get { return dough; }
            set
            {
                dough = value;
            }
        }
    }
}
