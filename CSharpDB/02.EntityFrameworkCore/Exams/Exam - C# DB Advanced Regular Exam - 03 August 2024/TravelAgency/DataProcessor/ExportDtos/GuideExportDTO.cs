using System.Xml.Serialization;

namespace TravelAgency.DataProcessor.ExportDtos
{
    [XmlType("Guide")]
    public class GuideExportDTO
    {
        [XmlElement(nameof(FullName))]
        public string FullName { get; set; } = null!;

        [XmlArray(nameof(TourPackages))]
        public TourPackageExportDTO[] TourPackages { get; set; } = null!;
    }
}
