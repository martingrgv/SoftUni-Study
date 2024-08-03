using Cadastre.Utilities;
using TravelAgency.Data;
using TravelAgency.Data.Models.Enums;
using TravelAgency.DataProcessor.ExportDtos;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            var guideDTOs = context.Guides
                .Where(g => g.Language == Language.Spanish)
                .Select(g => new GuideExportDTO
                {
                    FullName = g.FullName,
                    TourPackages = g.TourPackagesGuides.Select(tpg => new TourPackageExportDTO
                    {
                        Name = tpg.TourPackage.PackageName,
                        Description = tpg.TourPackage.Description,
                        Price = tpg.TourPackage.Price
                    })
                    .OrderByDescending(tp => tp.Price)
                    .ThenBy(tp => tp.Name)
                    .ToArray()
                })
                .OrderByDescending(g => g.TourPackages.Length)
                .ThenBy(g => g.FullName)
                .ToArray();

            return XmlSerializerHelper.Serialize(guideDTOs, "Guides");
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            throw new NotImplementedException();
        }
    }
}
