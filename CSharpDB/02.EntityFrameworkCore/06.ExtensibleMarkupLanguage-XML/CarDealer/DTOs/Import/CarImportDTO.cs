using CarDealer.Models;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("Car")]
    public class CarImportDTO
    {
        [XmlElement("make")]
        public string Make { get; set; } = null!;

        [XmlElement("model")]
        public string Model { get; set; } = null!;

        [XmlElement("traveledDistance")]
        public long TraveledDistance { get; set; }

        [XmlArray("parts")]
        public PartsCarImportDTO[] PartsIds { get; set; } = null!;

        [XmlType("partId")]
        public class PartsCarImportDTO
        {
            [XmlAttribute("id")]
            public int Id { get; set; }
        }
    }
}
