using System.Xml.Serialization;

namespace CarDealer;

[XmlType("car")]
public class CarBMWMakeDTO
{
    [XmlAttribute("id")]
    public int Id { get; set; }

    [XmlAttribute("model")]
    public string Model { get; set; } = null!;

    [XmlAttribute("traveled-distance")]
    public long TraveledDistance { get; set; }
}
