using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;

namespace MusicHub.Data
{
    /// <summary>
    /// Database context
    /// </summary>
    public class MusicHubDbContext : DbContext
    {
        /// <summary>
        /// Database context connection string
        /// </summary>
        private const string connectionString = "Server=WILLSONSCODER;Database=MusicHub;Integrated Security=True;";

        /// <summary>
        /// Database context constructor
        /// </summary>
        public MusicHubDbContext()
        {

        }

        /// <summary>
        /// Constructs context with options
        /// </summary>
        /// <param name="options">Context options</param>
        public MusicHubDbContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Songs
        /// </summary>
        public DbSet<Song> Songs { get; set; }

        /// <summary>
        /// Albums
        /// </summary>
        public DbSet<Album> Albums { get; set; }

        /// <summary>
        /// Performers
        /// </summary>
        public DbSet<Performer> Performers { get; set; }

        /// <summary>
        /// Producers
        /// </summary>
        public DbSet<Producer> Producers { get; set; }

        /// <summary>
        /// Writers
        /// </summary>
        public DbSet<Writer> Writers { get; set; }

        /// <summary>
        /// Song performers
        /// </summary>
        public DbSet<SongPerformer> SongPerformers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MusicHubDbContext).Assembly);
        }
    }
}
