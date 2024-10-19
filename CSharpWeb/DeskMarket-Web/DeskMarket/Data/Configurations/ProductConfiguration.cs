using DeskMarket.Data.Models;
using DeskMarket.Data.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeskMarket.Data.Configurations
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder
				.Property(p => p.IsDeleted)
				.HasDefaultValue(false);

			builder.HasData(DbSeeder.SeedProducts());
		}
	}
}
