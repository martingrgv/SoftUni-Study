using System.Xml.Serialization;

namespace CarDealer;

[XmlType("Car")]
public class CarsWithDistanceDTO
{
    [XmlElement("make")]
    public string Make { get; set; } = null!;

    [XmlElement("model")]
    public string Model { get; set; } = null!;

    [XmlElement("traveledDistance")]
    public long TraveledDistance { get; set; }
}
