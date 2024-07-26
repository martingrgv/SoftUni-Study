using System.Text;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.Models;
using ProductShop.Utilities;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();

            // string datasetsDirectory = "Datasets/";
            // Console.WriteLine(ImportAllDatasets(context, datasetsDirectory));

            Console.WriteLine(GetProductsInRange(context));
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ProductDTO{
                    Name = p.Name,
                    Price = p.Price,
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .OrderBy(p => p.Price)
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(products, Formatting.Indented);

            return jsonResult;
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

        public static string ImportCategories(ProductShopContext context, string inputJson) 
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson)!
                .Where(c => c.Name != null)
                .ToArray();

            if (categories == null || categories.Length == 0)
            {
                throw new InvalidOperationException(
                    $"No {nameof(categories)} were extracted from JSON file."
                );
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            if (categoriesProducts == null || categoriesProducts.Length == 0)
            {
                throw new InvalidOperationException(
                    $"No {nameof(categoriesProducts)} were extracted from JSON file."
                );
            }

            context.CategoriesProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Length}";
            
        }

        private static string ImportAllDatasets(ProductShopContext context, string datasetsDirectory)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            StringBuilder stringBuilder = new StringBuilder();

            try
            {
                string inputJsonUsers = JsonHelper.GetJson(datasetsDirectory, "users");
                string resultUsers = ImportUsers(context, inputJsonUsers);

                stringBuilder.AppendLine(resultUsers);

                string inputJsonProducts = JsonHelper.GetJson(datasetsDirectory, "products");
                string resultProducts = ImportProducts(context, inputJsonProducts);

                stringBuilder.AppendLine(resultProducts);

                string inputJsonCategories = JsonHelper.GetJson(datasetsDirectory, "categories");
                string resultCategories = ImportCategories(context, inputJsonCategories);

                stringBuilder.AppendLine(resultCategories);

                string inputJsonCategoriesProducts = JsonHelper.GetJson(datasetsDirectory, "categories-products");
                string resultCategoriesProducts = ImportCategoryProducts(context, inputJsonCategoriesProducts);

                stringBuilder.AppendLine(resultCategoriesProducts);
            }
            catch (Exception e)
            {
                stringBuilder.AppendLine("Exception has been thrown: " +
                    Environment.NewLine + 
                    e.Message);
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
