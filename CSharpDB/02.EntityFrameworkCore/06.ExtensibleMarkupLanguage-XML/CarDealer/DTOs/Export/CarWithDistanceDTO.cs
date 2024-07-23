using System.Xml.Serialization;

namespace CarDealer;

[XmlType("car")]
public class CarsWithDistanceDTO
{
    [XmlElement("make")]
    public string Make { get; set; } = null!;

    [XmlElement("model")]
    public string Model { get; set; } = null!;

    [XmlElement("traveled-distance")]
    public long TraveledDistance { get; set; }
}
