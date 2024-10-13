using GameZone.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace GameZone.Data.Seed
{
    public static class DbSeeder
    {
        public static IdentityUser GuestUser { get; set; } = null!;
        public static List<Genre> Genres { get; set; } = null!;

        public static void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            GuestUser = new IdentityUser
            {
                UserName = "guest@mail.com",
                NormalizedUserName = "GUEST@MAIL.COM",
                Email = "guest@mail.com",
                NormalizedEmail = "GUEST@MAIL.COM",
            };
            
            GuestUser.PasswordHash = hasher.HashPassword(GuestUser, "guest123!");
        }

        public static void SeedGenres()
        {
            Genres = new List<Genre>()
            {
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Adventure" },
                new Genre { Id = 3, Name = "Fighting" },
                new Genre { Id = 4, Name = "Sports" },
                new Genre { Id = 5, Name = "Racing" },
                new Genre { Id = 6, Name = "Strategy" }
            };
        }
    }
}
