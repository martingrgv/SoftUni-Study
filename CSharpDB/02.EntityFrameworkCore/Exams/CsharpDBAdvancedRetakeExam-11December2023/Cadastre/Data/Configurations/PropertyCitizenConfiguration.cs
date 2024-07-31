using Cadastre.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadastre.Data.Configurations 
{
    public class PropertyCitizenConfiguration : IEntityTypeConfiguration<PropertyCitizen>
    {
        public void Configure(EntityTypeBuilder<PropertyCitizen> builder)
        {
            builder
                .HasKey(e => new { e.PropertyId, e.CitizenId });
        }
    }
}
