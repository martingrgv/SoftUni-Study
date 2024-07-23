﻿using System.Xml.Serialization;

namespace CarDealer;

[XmlType("Customer")]
public class CustomerImportDTO
{
    [XmlElement("name")]
    public string Name { get; set; } = null!;

    [XmlElement("birthDate")]
    public DateTime BirthDate { get; set; }

    [XmlElement("isYoungDriver")]
    public bool IsYoungDriver { get; set; }
}
