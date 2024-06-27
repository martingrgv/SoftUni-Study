using Microsoft.EntityFrameworkCore;

namespace P02_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        private const string connectionString = "Server=.;Database=FootballBookmakerSystem;Integrated Security=True;";

        public FootballBettingContext()
        {
            
        }

        /// <summary>
        /// Constructs context with options
        /// </summary>
        /// <param name="options">Options</param>
        public FootballBettingContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
