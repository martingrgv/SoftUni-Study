using Castle.Core.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductShop.Data;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddDbContext<ProductShopContext>(options => options.UseSqlServer(Configuration.ConnectionString))
                .BuildServiceProvider();

            using var scope = serviceProvider.CreateScope();
            


            string result = ImportUsers(context);

            Console.WriteLine(result); 
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
    }
}