using Cadastre.Data;
using Cadastre.DataProcessor.ExportDtos;
using Cadastre.Utilities;
using System.Globalization;

namespace Cadastre.DataProcessor
{
    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)
        {
            var filterDate = new DateTime(2000, 1, 1);
            var filteredProperties = dbContext.Properties
                .Where(p => p.DateOfAcquisition >= filterDate)
                .OrderByDescending(p => p.DateOfAcquisition)
                .ThenBy(p => p.PropertyIdentifier)
                .Select(p => new PropertyOwnerExportDTO
                {
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    Address = p.Address,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Owners = p.PropertiesCitizens.Select(pc => new OwnerDTO
                    {
                        LastName = pc.Citizen.LastName,
                        MaritalStatus = pc.Citizen.MaritalStatus.ToString()
                    })
                    .OrderBy(c => c.LastName)
                    .ToList()
                })
                .ToList();

            return JsonSerializerHelper.Serialize(filteredProperties);
        }

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
        {
            int filterArea = 100;
            var properties = dbContext.Properties
                .Where(p => p.Area >= filterArea)
                .OrderByDescending(p => p.Area)
                .ThenBy(p => p.DateOfAcquisition)
                .Select(p => new PropertyDistrictDTO
                {
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    PostalCode = p.District.PostalCode
                })
                .ToList();

            return XmlSerializerHelper.Serialize(properties, "Properties");
        }
    }
}
