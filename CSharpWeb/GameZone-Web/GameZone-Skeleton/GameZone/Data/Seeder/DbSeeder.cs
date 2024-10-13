using Microsoft.AspNetCore.Identity;

namespace GameZone.Data.Seed
{
    public static class DbSeeder
    {
        public static IdentityUser GuestUser { get; set; }

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
    }
}
