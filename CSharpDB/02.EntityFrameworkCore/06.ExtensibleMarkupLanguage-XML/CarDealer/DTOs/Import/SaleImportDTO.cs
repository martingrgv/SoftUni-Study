﻿using System.Xml.Serialization;

namespace CarDealer;

[XmlType("Sale")]
public class SaleImportDTO
{
    [XmlElement("carId")]
    public int CarId { get; set; }

    [XmlElement("customerId")]
    public int CustomerId { get; set; }

    [XmlElement("discount")]
    public decimal Discount { get; set; }
}
