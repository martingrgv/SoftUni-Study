using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgency.Data.Models;

namespace TravelAgency.Data.Configurations
{
    public class TourPackageGuideConfiguration : IEntityTypeConfiguration<TourPackageGuide>
    {
        public void Configure(EntityTypeBuilder<TourPackageGuide> builder)
        {
            builder.HasKey(e =>
                new { e.TourPackageId, e.GuideId }
            );
        }
    }
}
