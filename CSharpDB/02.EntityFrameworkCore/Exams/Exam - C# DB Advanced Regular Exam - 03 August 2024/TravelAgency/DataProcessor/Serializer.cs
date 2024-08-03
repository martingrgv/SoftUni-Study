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
            var filterPackageName = "Horse Riding Tour";
            var customerDTOs = context.Customers
                .Where(c => c.Bookings
                    .Select(b => b.TourPackage.PackageName)
                    .Contains(filterPackageName)
                )
                .Select(c => new CustomerExportDTO
                {
                    FullName = c.FullName,
                    PhoneNumber = c.PhoneNumber,
                    Bookings = c.Bookings
                    .OrderBy(b => b.BookingDate)
                    .Where(b => b.TourPackage.PackageName == filterPackageName)
                    .Select(b => new BookingExportDTO
                    {
                        TourPackageName = b.TourPackage.PackageName,
                        Date = b.BookingDate.ToString("yyyy-MM-dd")
                    })
                    .ToArray()
                })
                .OrderBy(c => c.Bookings.Length)
                .ThenBy(c => c.FullName)
                .ToArray();

            return JsonSerializerHelper.Serialize(customerDTOs);;
        }
    }
}
