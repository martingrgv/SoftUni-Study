using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string inputJsonUsers = GetJsonTextFromFile("users");
            string resultUsers = ImportUsers(context, inputJsonUsers);

            Console.WriteLine(resultUsers);
            
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);
            
            if (users == null || users.Length == 0)
            {
                throw new InvalidOperationException("No users were extracted from JSON file.");
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        private static string GetJsonTextFromFile(string filename)
        {
            string searchDirectory = "Datasets/";
            return File.ReadAllText($"{searchDirectory}{filename}.json");
        }
    }
}