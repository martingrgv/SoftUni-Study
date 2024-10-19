using DeskMarket.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace DeskMarket.Data.Seed
{
    public static class DbSeeder
    {
        public static ICollection<IdentityUser> SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            var guestUser = new IdentityUser
            {
                Id = "5067afe2-1093-4328-ac98-34ecfdf90937",
                UserName = "guest@mail.com",
                NormalizedUserName = "GUEST@MAIL.COM",
                Email = "guest@mail.com",
                NormalizedEmail = "GUEST@MAIL.COM",
            };

            var sellerUser = new IdentityUser
            {
                Id = "5615c548-7c51-4df4-8630-187395bc1c01",
                UserName = "seller@mail.com",
                NormalizedUserName = "SELLER@MAIL.COM",
                Email = "seller@mail.com",
                NormalizedEmail = "SELLER@MAIL.COM",
            };
            
            guestUser.PasswordHash = hasher.HashPassword(guestUser, "guest123!");
            sellerUser.PasswordHash = hasher.HashPassword(sellerUser, "seller123!");

            return new List<IdentityUser> 
            { 
                guestUser, 
                sellerUser 
            };
        }

        public static ICollection<Category> SeedCategories()
        {
            return new List<Category>()
            {
				new Category { Id = 1, Name = "Laptops" },
				new Category { Id = 2, Name = "Workstations" },
				new Category { Id = 3, Name = "Accessories" },
				new Category { Id = 4, Name = "Desktops" },
				new Category { Id = 5, Name = "Monitors" }
            };
        }

        public static ICollection<Product> SeedProducts()
        {
            return new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    ProductName = "ALIENWARE M15 R6",
                    Description = "The best gaming laptop on the market!",
                    Price = 2100,
                    ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fmac24h.vn%2Fimages%2Fcompanies%2F1%2FLaptop%25201%2FAlienware%2520m15x%2Falienware%2520m16%2520r1.jpeg%3F1687623368228&f=1&nofb=1&ipt=31a2688bb6806164bc21e1ad12ee22fc66fc6a4886b17d32710cc760735a5b86&ipo=images",
                    SellerId = "5615c548-7c51-4df4-8630-187395bc1c01",
                    AddedOn = new DateTime(2024, 10, 19),
                    CategoryId = 1,
                    IsDeleted = false
                }
            };
        }
    }
}
