using GameZone.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace GameZone.Data.Seed
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

            var publisherUser = new IdentityUser
            {
                Id = "5615c548-7c51-4df4-8630-187395bc1c01",
                UserName = "publisher@mail.com",
                NormalizedUserName = "PUBLISHER@MAIL.COM",
                Email = "publisher@mail.com",
                NormalizedEmail = "PUBLISHER@MAIL.COM",
            };
            
            guestUser.PasswordHash = hasher.HashPassword(guestUser, "guest123!");
            publisherUser.PasswordHash = hasher.HashPassword(publisherUser, "publisher123!");

            return new List<IdentityUser> 
            { 
                guestUser, 
                publisherUser 
            };
        }

        public static ICollection<Genre> SeedGenres()
        {
            return new List<Genre>()
            {
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Adventure" },
                new Genre { Id = 3, Name = "Fighting" },
                new Genre { Id = 4, Name = "Sports" },
                new Genre { Id = 5, Name = "Racing" },
                new Genre { Id = 6, Name = "Strategy" }
            };
        }

        public static ICollection<Game> SeedGames()
        {
            return new List<Game>()
            {
                new Game
                {
                    Id = 1,
                    Title = "Assassin's Creed Mirage",
                    ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fimages.wallpapersden.com%2Fimage%2Fdownload%2Fofficial-assassin-s-creed-mirage-hd_bWtoZmiUmZqaraWkpJRobWllrWdma2VnZWc.jpg&f=1&nofb=1&ipt=72fbe60bee574d188b5189ac5f601188088d9beaf9d22af8f42488f8bf052da9&ipo=images",
                    Description = "Assassin's Creed Mirage is a 2023 action-adventure game developed by Ubisoft Bordeaux and published by Ubisoft.The game is the thirteenth major installment in the Assassin's Creed series and the successor to 2020's Assassin's Creed Valhalla.While its historical timeframe precedes that of",
                    ReleasedOn = new DateTime(2023, 10, 5),
                    GenreId = 1,
                    PublisherId = "5615c548-7c51-4df4-8630-187395bc1c01"
                }
            };
        }
    }
}
