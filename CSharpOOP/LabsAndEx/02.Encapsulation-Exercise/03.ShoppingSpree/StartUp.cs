using ShoppingSpree.Models;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                List<Person> people = GetPeople();
                List<Product> products = GetProducts();

                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string personName = data[0];
                    string productName = data[1];

                    Person currentPerson = people.FirstOrDefault(p => p.Name == personName);
                    Product currentProduct = products.FirstOrDefault(p => p.Name == productName);

                    if (currentPerson != null && currentProduct != null)
                    {
                        if (currentPerson.Money - currentProduct.Cost >= 0)
                        {
                            currentPerson.AddProductToBag(currentProduct);
                            currentPerson.Money -= currentProduct.Cost;

                            Console.WriteLine($"{currentPerson.Name} bought {currentProduct.Name}");
                        }
                        else
                        {
                            Console.WriteLine($"{currentPerson.Name} can't afford {currentProduct.Name}");
                        }
                    }
                }

                foreach (var person in people)
                {
                    Console.WriteLine(person);
                }
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();
            string[] peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < peopleInput.Length; i++)
            {
                people.Add(GetPerson(peopleInput[i]));
            }

            return people;
        }

        private static Person GetPerson(string personInput)
        {
            string[] personArgs = personInput.Split('=', StringSplitOptions.RemoveEmptyEntries);
            return new Person(personArgs[0], decimal.Parse(personArgs[1]));
        }

        private static List<Product> GetProducts()
        {

            List<Product> products = new List<Product>();
            string[] productsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < productsInput.Length; i++)
            {
                products.Add(GetProduct(productsInput[i]));
            }

            return products;
        }

        private static Product GetProduct(string productInput)
        {
            string[] productArgs = productInput.Split('=', StringSplitOptions.RemoveEmptyEntries);
            return new Product(productArgs[0], decimal.Parse(productArgs[1]));
        }
    }
}
