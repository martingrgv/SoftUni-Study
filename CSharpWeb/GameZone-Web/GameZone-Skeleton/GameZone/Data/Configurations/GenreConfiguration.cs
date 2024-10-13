using GameZone.Data.Models;
using GameZone.Data.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameZone.Data.Configurations
{
	public class GenreConfiguration : IEntityTypeConfiguration<Genre>
	{
		public void Configure(EntityTypeBuilder<Genre> builder)
		{
			DbSeeder.SeedGenres();
			builder.HasData(DbSeeder.Genres);
		}
	}
}
