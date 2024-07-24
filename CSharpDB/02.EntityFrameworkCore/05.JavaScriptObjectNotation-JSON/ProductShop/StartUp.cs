using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using ProductShop.Utilities;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string searchDirectory = "Datasets/";

            string inputJsonUsers = JsonHelper.GetJson(searchDirectory, "users");
            string resultUsers = ImportUsers(context, inputJsonUsers);

            string inputJsonProducts = JsonHelper.GetJson(searchDirectory, "products");
            string resultProducts = ImportProducts(context, inputJsonProducts);

            Console.WriteLine(resultUsers);
            Console.WriteLine(resultProducts);
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            if (users == null || users.Length == 0)
            {
                throw new InvalidOperationException(
                    $"No {nameof(users)} were extracted from JSON file."
                );
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            if (products == null || products.Length == 0)
            {
                throw new InvalidOperationException(
                    $"No {nameof(products)} were extracted from JSON file."
                );
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }
    }
}
